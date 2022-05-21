namespace Blatternfly.Components;

public class Switch : InputComponentBase<bool>
{
    public ElementReference Element { get; protected set; }

    /// Text value for the label when on.
    [Parameter] public RenderFragment Label { get; set; }

    /// Text value for the label when off.
    [Parameter] public RenderFragment LabelOff { get; set; }

    /// Flag to show if the switch has a check icon.
    [Parameter] public bool HasCheckIcon { get; set; }

    /// Flag to show if the switch is disabled.
    [Parameter] public bool IsDisabled { get; set; }

    /// Adds accessible text to the Switch, and should describe the isChecked="true" state.
    /// When label is defined, aria-label should be set to the text string that is visible when isChecked is true.
    [Parameter] public string AriaLabel { get; set; } = "";

    /// Flag to reverse the layout of toggle and label (toggle on right).
    [Parameter] public bool IsReversed { get; set; }

    private string CssClass => new CssBuilder("pf-c-switch")
        .AddClass("pf-m-reverse", IsReversed)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string InternalId { get => AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id); }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (string.IsNullOrEmpty(InternalId))
        {
            throw new InvalidOperationException("Switch: id is required to make it accessible.");
        }
        if (Label is null && AriaLabel is null)
        {
            throw new InvalidOperationException("Switch: Switch requires either a label or an aria-label to be specified.");
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var isAriaLabelledBy  = string.IsNullOrEmpty(AriaLabel);
        var ariaLabelledByOn  = isAriaLabelledBy ? $"{InternalId}-on" : null;
        var ariaLabelledByOff = isAriaLabelledBy ? $"{InternalId}-off" : null;

        builder.OpenElement(0, "label");
        builder.AddAttribute(1, "class", CssClass);
        builder.AddAttribute(2, "for", InternalId);

        builder.OpenElement(3, "input");
        builder.AddMultipleAttributes(4, AdditionalAttributes);
        builder.AddAttribute(5, "class", "pf-c-switch__input");
        builder.AddAttribute(6, "type", "checkbox");
        builder.AddAttribute(7, "aria-invalid", AriaInvalid);
        builder.AddAttribute(8, "aria-label", AriaLabel);
        builder.AddAttribute(9, "aria-labelledby", ariaLabelledByOn);
        builder.AddAttribute(10, "disabled", IsDisabled);
        builder.AddAttribute(11, "checked", BindConverter.FormatValue(CurrentValue));
        builder.AddAttribute(12, "onchange", EventCallback.Factory.CreateBinder<bool>(this, __value => CurrentValue = __value, CurrentValue));
        builder.AddElementReferenceCapture(13, __inputReference => Element = __inputReference);
        builder.CloseElement();

        if (Label is not null)
        {
            builder.OpenElement(14, "span");
            builder.AddAttribute(15, "class", "pf-c-switch__toggle");

            if (HasCheckIcon)
            {
                builder.OpenElement(21, "div");
                builder.AddAttribute(22, "class", "pf-c-switch__toggle-icon");
                builder.AddAttribute(23, "aria-hidden", "true");

                builder.OpenComponent<CheckIcon>(24);
                builder.AddAttribute(25, "NoVerticalAlign", true);
                builder.CloseComponent();

                builder.CloseElement();
            }

            builder.CloseElement();

            builder.OpenElement(16, "span");
            builder.AddAttribute(17, "class", "pf-c-switch__label pf-m-on");
            builder.AddAttribute(18, "id", ariaLabelledByOn);
            builder.AddAttribute(19, "aria-hidden", "true");
            builder.AddContent(20, Label);
            builder.CloseElement();

            builder.OpenElement(26, "span");
            builder.AddAttribute(27, "class", "pf-c-switch__label pf-m-off");
            builder.AddAttribute(28, "id", ariaLabelledByOff);
            builder.AddAttribute(29, "aria-hidden", "true");
            builder.AddContent(30, LabelOff ?? Label);
            builder.CloseElement();
        }
        else
        {
            builder.OpenElement(31, "span");
            builder.AddAttribute(32, "class", "pf-c-switch__toggle");

            builder.OpenElement(33, "div");
            builder.AddAttribute(34, "class", "pf-c-switch__toggle-icon");
            builder.AddAttribute(35, "aria-hidden", "true");

            builder.OpenComponent<CheckIcon>(36);
            builder.AddAttribute(37, "NoVerticalAlign", true);
            builder.CloseComponent();

            builder.CloseElement();

            builder.CloseElement();
        }

        builder.CloseElement();
    }

    protected override bool TryParseValueFromString(string value, out bool result, out string validationErrorMessage)
        => throw new NotSupportedException();
}
