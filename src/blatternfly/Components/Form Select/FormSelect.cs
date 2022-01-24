using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Blatternfly.Components;

public class FormSelect<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue>
    : InputComponentBase<TValue>
{
    public ElementReference Element { get; protected set; }

    /// Custom flag to show that the FormSelect requires an associated id or aria-label.
    [Parameter] public string AriaLabel { get; set; }

    private string CssClass => new CssBuilder("pf-c-form-control")
        .AddClass(ValidationClass)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (string.IsNullOrEmpty(InternalId) && string.IsNullOrEmpty(AriaLabel))
        {
            throw new InvalidOperationException("FormSelect requires either an id or aria-label to be specified.");
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, "select");
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddAttribute(4, "aria-label", AriaLabel);
        builder.AddAttribute(5, "aria-invalid", AriaInvalid);
        builder.AddAttribute(6, "disabled", IsDisabled);
        builder.AddAttribute(7, "required", IsRequired);
        builder.AddAttribute(8, "value", BindConverter.FormatValue(CurrentValueAsString));
        builder.AddAttribute(9, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
        builder.AddElementReferenceCapture(10, __selectReference => Element = __selectReference);
        builder.AddContent(11, ChildContent);
        builder.CloseElement();
    }

    protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
    {
        if (BindConverter.TryConvertTo<TValue>(value, CultureInfo.CurrentCulture, out var parsedValue))
        {
            result = parsedValue;
            validationErrorMessage = null;
            return true;
        }
        else
        {
            result = default;
            validationErrorMessage = $"The {DisplayName ?? FieldIdentifier.FieldName} field is not valid.";
            return false;
        }
    }
}
