namespace Blatternfly.Components;

public class Checkbox : InputComponentBase<bool>
{
    /// <summary>
    /// Html element referece.
    /// </summary>
    public ElementReference Element { get; protected set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Flag indicating whether the Form Control is disabled.
    /// </summary>
    [Parameter]
    public bool IsDisabled { get; set; }

    /// <summary>
    /// Label text of the checkbox.
    /// </summary>
    [Parameter]
    public string Label { get; set; }

    /// <summary>
    /// Aria-label of the checkbox.
    /// </summary>
    [Parameter]
    public string AriaLabel { get; set; }

    /// <summary>
    /// Description text of the checkbox.
    /// </summary>
    [Parameter]
    public RenderFragment Description { get; set; }

    /// <summary>
    /// Description text of the checkbox.
    /// </summary>
    [Parameter]
    public RenderFragment Body { get; set; }

    /// <summary>
    /// Sets the input wrapper component to render. Defaults to <div>.
    /// </summary>
    [Parameter]
    public string Component { get; set; } = "div";

    private string CssClass => new CssBuilder("pf-c-check")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string LabelCssClass => new CssBuilder("pf-c-check__label")
        .AddClass("pf-m-disabled", IsDisabled)
        .Build();

    private string InternalId { get => AdditionalAttributes.GetPropertyValue(HtmlElement.Id); }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (string.IsNullOrEmpty(InternalId))
        {
            throw new InvalidOperationException("Checkbox: id is required to make input accessible.");
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component);
        builder.AddAttribute(1, "class", CssClass);

        builder.OpenElement(2, "input");
        builder.AddMultipleAttributes(3, AdditionalAttributes);
        builder.AddAttribute(4, "class", "pf-c-check__input");
        builder.AddAttribute(5, "type", "checkbox");
        builder.AddAttribute(6, "aria-invalid", AriaInvalid);
        builder.AddAttribute(7, "aria-label", AriaLabel);
        builder.AddAttribute(8, "disabled", IsDisabled);
        builder.AddAttribute(9, "checked", BindConverter.FormatValue(CurrentValue));
        builder.AddAttribute(10, "onchange", EventCallback.Factory.CreateBinder<bool>(this, __value => CurrentValue = __value, CurrentValue));
        builder.AddElementReferenceCapture(11, __inputReference => Element = __inputReference);
        builder.CloseElement();

        if (Label is not null)
        {
            builder.OpenElement(12, "label");
            builder.AddAttribute(13, "class", LabelCssClass);
            if (!string.IsNullOrEmpty(InternalId))
            {
                builder.AddAttribute(14, "for", InternalId);
            }
            builder.AddContent(15, Label);
            builder.CloseElement();
        }

        if (Description is not null)
        {
            builder.OpenElement(16, "span");
            builder.AddAttribute(17, "class", "pf-c-check__description");
            builder.AddContent(18, Description);
            builder.CloseElement();
        }

        if (Body is not null)
        {
            builder.OpenElement(19, "span");
            builder.AddAttribute(20, "class", "pf-c-check__body");
            builder.AddContent(21, Body);
            builder.CloseElement();
        }

        builder.CloseElement();
    }

    /// <inheritdoc />
    protected override bool TryParseValueFromString(string value, out bool result, out string validationErrorMessage)
        => throw new NotSupportedException();
}
