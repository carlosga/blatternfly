namespace Blatternfly.Components;

public class TextArea : InputComponentBase<string>
{
    public ElementReference Element { get; protected set; }

    /// <summary>Custom flag to show that the text area requires an associated id or aria-label.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Flag indicating whether the text area is disabled.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Flag indicating whether the text area is required.</summary>
    [Parameter] public bool IsRequired { get; set; }

    /// <summary>Flag to show if the text area is read only.</summary>
    [Parameter] public bool IsReadOnly { get; set; }

    /// <summary>Read only variant.</summary>
    [Parameter] public InputReadOnlyVariants? ReadOnlyVariant { get; set; }

    /// <summary>Use the external file instead of a data URI.</summary>
    [Parameter] public bool IsIconSprite { get; set; }

    /// <summary>Placeholder of the text area.</summary>
    [Parameter] public string Placeholder { get; set; }

    /// <summary>Sets the orientation to limit the resize to.</summary>
    [Parameter] public ResizeOrientation? ResizeOrientation { get; set; }

    /// <summary></summary>
    [Parameter] public int? ColumnCount { get; set; }

    /// <summary></summary>
    [Parameter] public int? RowCount { get; set; }

    private string CssClass => new CssBuilder("pf-c-form-control")
        .AddClass("pf-m-plain"             , ReadOnlyVariant is InputReadOnlyVariants.Plain)
        .AddClass("pf-m-icon-sprite"       , IsIconSprite)
        .AddClass("pf-m-resize-both"       , ResizeOrientation is Blatternfly.ResizeOrientation.Both)
        .AddClass("pf-m-resize-horizontal" , ResizeOrientation is Blatternfly.ResizeOrientation.Horizontal)
        .AddClass("pf-m-resize-vertical"   , ResizeOrientation is Blatternfly.ResizeOrientation.Vertical)
        .AddClass(ValidationClass)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string InternalId { get => AdditionalAttributes.GetPropertyValue(HtmlElement.Id); }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (string.IsNullOrEmpty(InternalId) && string.IsNullOrEmpty(AriaLabel))
        {
            throw new InvalidOperationException("TextArea: TextArea requires either an id or aria-label to be specified");
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "textarea");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "cols", ColumnCount);
        builder.AddAttribute(4, "rows", RowCount);
        builder.AddAttribute(5, "placeholder", Placeholder);
        builder.AddAttribute(6, "aria-label", AriaLabel);
        builder.AddAttribute(7, "aria-invalid", AriaInvalid);
        builder.AddAttribute(8, "required", IsRequired);
        builder.AddAttribute(9, "disabled", IsDisabled);
        builder.AddAttribute(10, "readOnly", ReadOnlyVariant.HasValue || IsReadOnly);
        builder.AddAttribute(11, "value", BindConverter.FormatValue(CurrentValue));
        builder.AddAttribute(12, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
        builder.AddElementReferenceCapture(13, __inputReference => Element = __inputReference);
        builder.CloseElement();
    }

    protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
    {
        result = value;
        validationErrorMessage = null;
        return true;
    }
}
