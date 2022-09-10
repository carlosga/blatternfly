namespace Blatternfly.Components;

public partial class AccordionToggle : ComponentBase
{
    /// <summary>
    /// Parent Accordion
    /// </summary>
    [CascadingParameter]
    private Accordion ParentAccordion { get; set; }

    /// <summary>
    /// Parent Accordion Item
    /// </summary>
    [CascadingParameter]
    private AccordionItem ParentItem { get; set; }

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

    private string InternalId   { get => AdditionalAttributes?.GetPropertyValue(HtmlAttributes.Id); }
    private string Container    { get => Component ?? ParentAccordion.ToggleContainer; }
    private string AriaExpanded { get => IsExpanded ? "true" : "false"; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (string.IsNullOrEmpty(InternalId))
        {
            throw new InvalidOperationException("Accordion: Accordion Toggle requires an id to be specified");
        }

        ParentItem.RegisterToggle(this);
    }

    private async Task ToggleHandler(MouseEventArgs args)
    {
        await OnToggle.InvokeAsync(args);
        ParentAccordion.Toggle(InternalId);
    }
}
