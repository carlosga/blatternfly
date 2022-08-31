namespace Blatternfly.Components;

public class Card : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Sets the base component to render. defaults to article.
    /// </summary>
    [Parameter]
    public string Component { get; set; } = "article";

    /// <summary>
    /// Modifies the card to include compact styling.
    /// </summary>
    [Parameter]
    public bool IsCompact { get; set; }

    /// <summary>
    /// Modifies the card to include selectable styling.
    /// </summary>
    [Parameter]
    public bool IsSelectable { get; set; }

    /// <summary>
    /// Specifies the card is selectable, and applies the new raised styling on hover and select.
    /// </summary>
    [Parameter]
    public bool IsSelectableRaised { get; set; }

    /// <summary>
    /// Modifies the card to include selected styling.
    /// </summary>
    [Parameter]
    public bool IsSelected { get; set; }

    /// <summary>
    /// Modifies a raised selectable card to have disabled styling.
    /// </summary>
    [Parameter]
    public bool IsDisabledRaised { get; set; }

    /// <summary>
    /// Modifies the card to include flat styling.
    /// </summary>
    [Parameter]
    public bool IsFlat { get; set; }

    /// <summary>
    /// Modifies the card to include rounded styling.
    /// </summary>
    [Parameter]
    public bool IsRounded { get; set; }

    /// <summary>
    /// Modifies the card to be large. Should not be used with isCompact.
    /// </summary>
    [Parameter]
    public bool IsLarge { get; set; }

    /// <summary>
    /// Cause component to consume the available height of its container.
    /// </summary>
    [Parameter]
    public bool IsFullHeight { get; set; }

    /// <summary>
    /// Modifies the card to include plain styling; this removes border and background.
    /// </summary>
    [Parameter]
    public bool IsPlain { get; set; }

    /// <summary>
    /// Flag indicating if a card is expanded. Modifies the card to be expandable.
    /// </summary>
    [Parameter]
    public bool IsExpanded { get; set; }

    /// <summary>
    /// Flag indicating that the card should render a hidden input to make it selectable.
    /// </summary>
    [Parameter]
    public bool HasSelectableInput { get; set; }

    /// <summary>
    /// Aria label to apply to the selectable input if one is rendered.
    /// </summary>
    [Parameter]
    public string SelectableInputAriaLabel { get; set; }

    /// <summary>
    /// Callback that executes when the selectable input is changed.
    /// </summary>
    [Parameter]
    public EventCallback<ChangeEventArgs> OnSelectableInputChange { get; set; }

    private string CssClass => new CssBuilder("pf-c-card")
        .AddClass("pf-m-compact"              , IsCompact)
        .AddClass("pf-m-expanded"             , IsExpanded)
        .AddClass("pf-m-flat"                 , IsFlat)
        .AddClass("pf-m-rounded"              , IsRounded)
        .AddClass("pf-m-display-lg"           , IsLarge)
        .AddClass("pf-m-full-height"          , IsFullHeight)
        .AddClass("pf-m-plain"                , IsPlain)
        .AddClass("pf-m-non-selectable-raised", IsDisabledRaised)
        .AddClass("pf-m-selectable-raised"    , IsSelectableRaised)
        .AddClass("pf-m-selected-raised"      , IsSelectableRaised && IsSelected)
        .AddClass("pf-m-selectable"           , IsSelectable)
        .AddClass("pf-m-selected"             , IsSelectable && IsSelected)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    internal string CardId { get => AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id); }

    private string SelectableInputAriaLabelledBy { get; set; }

    internal void RegisterTitleId(string titleId)
    {
        SelectableInputAriaLabelledBy = titleId;
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (IsLarge && IsCompact)
        {
            Console.WriteLine("Card: Cannot use isCompact with isLarge.");
            IsLarge = false;
        }
        if (HasSelectableInput && string.IsNullOrEmpty(SelectableInputAriaLabelledBy))
        {
            Console.WriteLine("Card: If no CardTitle component is passed as a child of Card the SelectableInputAriaLabel prop must be passed");
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (HasSelectableInput)
        {
            builder.OpenElement(0, "input");
            builder.AddAttribute(1, "id", $"{CardId}-input");
            builder.AddAttribute(2, "class", "pf-screen-reader");
            builder.AddAttribute(3, "type", "checkbox");
            builder.AddAttribute(4, "aria-label", SelectableInputAriaLabel);
            builder.AddAttribute(5, "aria-labelledby", SelectableInputAriaLabelledBy);
            builder.AddAttribute(6, "checked", BindConverter.FormatValue(IsSelected));
            builder.AddAttribute(7, "onchange", EventCallback.Factory.CreateBinder<bool>(this, __value => IsSelected = __value, IsSelected));
            builder.AddAttribute(8, "disabled", IsDisabledRaised);
            builder.AddAttribute(9, "tabindex", -1);
            builder.CloseElement();
        }

        builder.OpenElement(10, Component);
        builder.AddMultipleAttributes(11, AdditionalAttributes);
        builder.AddAttribute(12, "class", CssClass);
        builder.AddAttribute(13, "tabindex", IsSelectableRaised || IsSelectable ? "0" : null);
        builder.OpenComponent<CascadingValue<Card>>(14);
        builder.AddAttribute(15, "Value", this);
        builder.AddAttribute(16, "IsFixed", true);
        builder.AddAttribute(17, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
        {
            innerBuilder.AddContent(8, ChildContent);
        });
        builder.CloseElement();
        builder.CloseElement();
    }
}
