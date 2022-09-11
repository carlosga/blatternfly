namespace Blatternfly.Components;

public partial class NavExpandable : ComponentBase
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    [CascadingParameter] private Nav Parent { get; set; }

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
    /// Title shown for the expandable list.
    /// </summary>
    [Parameter]
    public string Title { get; set; }

    /// <summary>
    /// If defined, screen readers will read this text instead of the list title */
    /// </summary>
    [Parameter]
    public string SrText { get; set; }

    /// <summary>
    /// Boolean to programatically expand or collapse section.
    /// </summary>
    [Parameter]
    public bool IsExpanded { get; set; }

    /// <summary>
    /// Group identifier, will be returned with the onToggle and onSelect callback passed to the Nav component.
    /// </summary>
    [Parameter]
    public string GroupId { get; set; }

    /// <summary>
    /// Allow consumer to optionally override this callback and manage expand state externally. if passed will not call Nav's onToggle.
    /// </summary>
    [Parameter]
    public EventCallback<NavExpandable> OnExpand { get; set; }

    private string CssClass => new CssBuilder("pf-c-nav__item pf-m-expandable")
        .AddClass("pf-m-expanded", IsExpanded)
        .AddClass("pf-m-current" , IsActive)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string Id;
    private string ItemId       { get => null; }
    private string InternalId   { get => AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id); }
    private string ExpandableId { get => !string.IsNullOrEmpty(InternalId) ? InternalId : Id; }
    private bool   IsActive     { get => !string.IsNullOrEmpty(Parent.ActiveGroupId) && GroupId == Parent.ActiveGroupId; }
    private string ElementId    { get => !string.IsNullOrEmpty(SrText) ? null : ExpandableId; }
    private string Hidden       { get => IsExpanded ? null : ""; }
    private string AriaExpanded { get => IsExpanded ? "true" : "false"; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Id = ComponentIdGenerator.Generate();
    }

    private async Task HandleExpand(MouseEventArgs args)
    {
        IsExpanded = !IsExpanded;
        await OnExpand.InvokeAsync(this);
        await Parent.Expand(this);
    }
}