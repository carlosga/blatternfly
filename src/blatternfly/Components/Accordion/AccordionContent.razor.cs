namespace Blatternfly.Components;

public partial class AccordionContent : ComponentBase
{
    /// <summary>
    /// Parent Accordion
    /// </summary>
    [CascadingParameter]
    public Accordion ParentAccordion { get; set; }

    /// <summary>
    /// Parent Accordion ITem
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
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Flag to indicate Accordion content is fixed.
    /// </summary>
    [Parameter]
    public bool IsFixed { get; set; }

    /// <summary>
    /// Adds accessible text to the Accordion content.
    /// </summary>
    [Parameter]
    public string AriaLabel { get; set; }

    /// <summary>
    /// Component to use as content container.
    /// </summary>
    [Parameter]
    public string Component { get; set; }

    /// <summary>
    /// Flag indicating content is custom. Expanded content Body wrapper will be removed from children.
    /// This allows multiple bodies to be rendered as content.
    /// </summary>
    [Parameter]
    public bool IsCustomContent { get; set; }

    /// Flag to show if the expanded content of the Accordion item is visible.
    private bool IsHidden { get => !ParentItem.Toggle.IsExpanded; }

    private string Container => Component ?? ParentAccordion.ContentContainer;

    private string CssClass => new CssBuilder("pf-c-accordion__expanded-content")
        .AddClass("pf-m-fixed"   , IsFixed)
        .AddClass("pf-m-expanded", !IsHidden)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
