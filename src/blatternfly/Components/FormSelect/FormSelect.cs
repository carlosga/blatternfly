using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Blatternfly.Components;

public class FormSelect<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : InputComponentBase<TValue>
{
    public ElementReference Element { get; protected set; }

    /// Optional callback for updating when selection loses focus.
    [Parameter] public EventCallback OnBlur { get; set; }

    /// Optional callback for updating when selection gets focus.
    [Parameter] public EventCallback OnFocus { get; set; }

    /// Custom flag to show that the FormSelect requires an associated id or aria-label.
    [Parameter] public string AriaLabel { get; set; }

    /// Use the external file instead of a data URI.
    [Parameter] public bool IsIconSprite { get; set; }

    private string CssClass => new CssBuilder("pf-c-form-control")
        .AddClass("pf-m-icon-sprite", IsIconSprite)
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
        builder.OpenElement(0, "select");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "aria-label", AriaLabel);
        builder.AddAttribute(4, "aria-invalid", AriaInvalid);
        builder.AddAttribute(5, "disabled", IsDisabled);
        builder.AddAttribute(6, "required", IsRequired);
        builder.AddAttribute(7, "value", BindConverter.FormatValue(CurrentValueAsString));
        builder.AddAttribute(8, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
        builder.AddAttribute(9, "onfocus", EventCallback.Factory.Create(this, OnFocus));
        builder.AddAttribute(10, "onblur", EventCallback.Factory.Create(this, OnBlur));
        builder.AddElementReferenceCapture(11, __selectReference => Element = __selectReference);
        builder.AddContent(12, ChildContent);
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
