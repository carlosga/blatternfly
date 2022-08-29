namespace Blatternfly.Components;

public class AccordionToggle : ComponentBase
{
    /// <summary>
    /// Parent Accordion
    /// </summary>
    [CascadingParameter] 
    public Accordion ParentAccordion { get; set; }

    /// <summary>
    /// Parent Accordion Item
    /// </summary>
    [CascadingParameter] 
    public AccordionItem ParentItem { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] 
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Container to override the default for toggle.
    /// </summary>
    [Parameter] 
    public string Component { get; set; }

    /// <summary>
    /// Callback called when toggle is clicked.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnToggle { get; set; }

    // Flag to show if the expanded content of the Accordion item is visible.
    internal bool IsExpanded { get => ParentAccordion?.IsExpanded(InternalId) ?? false; }

    private string CssClass => new CssBuilder("pf-c-accordion__toggle")
        .AddClass("pf-m-expanded", IsExpanded)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string InternalId { get => AdditionalAttributes?.GetPropertyValue(HtmlAttributes.Id); }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (string.IsNullOrEmpty(InternalId))
        {
            throw new InvalidOperationException("Accordion: Accordion Toggle requires an id to be specified");
        }

        ParentItem.RegisterToggle(this);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component ?? ParentAccordion.ToggleContainer);

        builder.OpenElement(1, "button");
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddAttribute(4, "aria-expanded", IsExpanded ? "true" : "false");
        builder.AddAttribute(5, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, ToggleHandler));
        builder.AddAttribute(6, "type", "button");
        builder.AddEventStopPropagationAttribute(7, "onclick", true);

        builder.OpenElement(8, "span");
        builder.AddAttribute(9, "class", "pf-c-accordion__toggle-text");
        builder.AddContent(10, ChildContent);
        builder.CloseElement();

        builder.OpenElement(11, "span");
        builder.AddAttribute(12, "class", "pf-c-accordion__toggle-icon");

        builder.OpenComponent<AngleRightIcon>(13);
        builder.CloseComponent();

        builder.CloseElement();

        builder.CloseElement();

        builder.CloseElement();
    }

    private async Task ToggleHandler(MouseEventArgs args)
    {
        await OnToggle.InvokeAsync(args);
        ParentAccordion.Toggle(InternalId);
    }
}
