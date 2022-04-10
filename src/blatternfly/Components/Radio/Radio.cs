using System;

namespace Blatternfly.Components;

public class Radio : InputComponentBase<string>
{
    public ElementReference Element { get; protected set; }

    /// Flag to show if the radio label is wrapped on small screen.
    [Parameter] public bool IsLabelWrapped { get; set; }

    /// Flag to show if the radio label is shown before the radio button.
    [Parameter] public bool IsLabelBeforeButton { get; set; }

    /// Flag to show if the radio is checked.
    [Parameter] public bool? Checked { get; set; }

    /// Flag to show if the radio is checked.
    [Parameter] public bool? IsChecked { get; set; }

    /// Label text of the radio.
    [Parameter] public RenderFragment Label { get; set; }

    /// Aria label for the radio.
    [Parameter] public string AriaLabel { get; set; }

    /// Description text of the radio.
    [Parameter] public string Description { get; set; }

    /// Body of the radio.
    [Parameter] public RenderFragment Body { get; set; }

    /// Flag to show if the radio is read only.
    [Parameter] public bool IsReadOnly { get; set; }

    private string LabelCssClass => new CssBuilder("pf-c-radio__label")
        .AddClass(DisabledClass)
        .Build();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Label is null && string.IsNullOrEmpty(AriaLabel))
        {
            throw new InvalidOperationException("Radio: Radio requires an aria-label to be specified");
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", "pf-c-radio");

        if (IsLabelBeforeButton)
        {
            BuildLabelRenderTree(builder);
            BuildInputRenderTree(builder);
        }
        else
        {
            BuildInputRenderTree(builder);
            BuildLabelRenderTree(builder);
        }

        if (!string.IsNullOrEmpty(Description))
        {
            builder.OpenElement(21, "span");
            builder.AddAttribute(22, "class", "pf-c-radio__description");
            builder.AddContent(23, Description);
            builder.CloseElement();
        }

        if (Body is not null)
        {
            builder.OpenElement(24, "span");
            builder.AddAttribute(25, "class", "pf-c-radio__body");
            builder.AddContent(26, Body);
            builder.CloseElement();
        }

        builder.CloseElement();
    }

    private void BuildLabelRenderTree(RenderTreeBuilder builder)
    {
        if (Label is not null && IsLabelWrapped)
        {
            builder.OpenElement(2, "span");
            builder.AddAttribute(3, "class", LabelCssClass);
            builder.AddContent(4, Label);
            builder.CloseElement();
        }
        else if (Label is not null)
        {
            builder.OpenElement(5, "label");
            builder.AddAttribute(6, "class", LabelCssClass);
            builder.AddAttribute(7, "for", InternalId);
            builder.AddContent(8, Label);
            builder.CloseElement();
        }
    }

    private void BuildInputRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(9, "input");
        builder.AddMultipleAttributes(10, AdditionalAttributes);
        builder.AddAttribute(11, "class", "pf-c-radio__input");
        builder.AddAttribute(12, "type", "radio");
        builder.AddAttribute(13, "aria-label", AriaLabel);
        builder.AddAttribute(14, "aria-invalid", AriaInvalid);
        builder.AddAttribute(15, "required", IsRequired);
        builder.AddAttribute(16, "disabled", IsDisabled);
        builder.AddAttribute(17, "readOnly", IsReadOnly);
        builder.AddAttribute(18, "value", BindConverter.FormatValue(Value));
        builder.AddAttribute(19, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
        builder.AddElementReferenceCapture(20, __inputReference => Element = __inputReference);
        builder.CloseElement();
    }

    protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
    {
        result = value;
        validationErrorMessage = null;
        return true;
    }
}
