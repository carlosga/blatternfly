namespace Blatternfly.Components;

public class Accordion : ComponentBase
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
    /// Adds accessible text to the Accordion.
    /// </summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>
    /// Heading level to use.
    /// </summary>
    [Parameter] 
    public HeadingLevel HeadingLevel { get; set; } = HeadingLevel.h3;

    /// <summary>
    /// Flag to indicate whether use definition list or div.
    /// </summary>
    [Parameter] 
    public bool AsDefinitionList { get; set; } = true;

    /// <summary>
    /// Flag to indicate the accordion had a border.
    /// </summary>
    [Parameter] 
    public bool IsBordered { get; set; }

    /// <summary>
    /// Display size variant.
    /// </summary>
    [Parameter] public DisplaySize DisplaySize { get; set; } = DisplaySize.Default;

    /// <summary>
    /// Expand behavior.
    /// </summary>
    [Parameter]
    public ExpandBehavior ExpandBehavior
    {
        get => _expandBehavior;
        set
        {
            if (_expandBehavior != value)
            {
                _expandBehavior = value;
                ExpandedItems.Clear();
            }
        }
    }

    private ExpandBehavior _expandBehavior;

    private string CssClass => new CssBuilder("pf-c-accordion")
        .AddClass("pf-m-bordered"   , IsBordered)
        .AddClass("pf-m-display-lg" , DisplaySize is DisplaySize.Large)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var component = AsDefinitionList ? "dl" : "div";

        builder.OpenElement(0, component);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "aria-label", AriaLabel);
        builder.OpenComponent<CascadingValue<Accordion>>(4);
        builder.AddAttribute(5, "Value", this);
        builder.AddAttribute(6, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
        {
            innerBuilder.AddContent(7, ChildContent);
        });
        builder.CloseComponent();
        builder.CloseElement();
    }

    internal string ContentContainer { get => AsDefinitionList ? "dd" : "div"; }

    internal string ToggleContainer { get => AsDefinitionList ? "dt" : HeadingLevel.ToString(); }

    private List<string> ExpandedItems { get; set; } = new(1);

    internal bool IsExpanded(string itemId)
    {
        return ExpandedItems.Contains(itemId);
    }

    internal void Toggle(string id)
    {
        if (ExpandBehavior is ExpandBehavior.Single)
        {
            if (ExpandedItems.Count == 0)
            {
                ExpandedItems.Add(id);
            }
            else if (ExpandedItems.Count == 1 && ExpandedItems[0] == id)
            {
                ExpandedItems.RemoveAt(0);
            }
            else
            {
                ExpandedItems[0] = id;
            }
        }
        else if (!IsExpanded(id))
        {
            ExpandedItems.Add(id);
        }
        else
        {
            ExpandedItems.Remove(id);
        }
        StateHasChanged();
    }
}
