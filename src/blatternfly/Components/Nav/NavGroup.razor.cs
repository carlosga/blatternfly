namespace Blatternfly.Components;

public partial class NavGroup : ComponentBase
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    [CascadingParameter] private Nav Parent { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Title shown for the group.</summary>
    [Parameter] public string Title { get; set; }

    private string CssClass => new CssBuilder("pf-c-nav__section")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string InternalId  { get => AdditionalAttributes.GetPropertyValue(HtmlElement.Id); }
    private string GroupId     { get; set; }
    private string SectionId   { get => null; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        GroupId = !string.IsNullOrEmpty(InternalId) ? InternalId : ComponentIdGenerator.Generate("pf-c-nav-section");
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        var ariaLabel = AdditionalAttributes.GetPropertyValue("aria-label");

        if (string.IsNullOrEmpty(Title) && string.IsNullOrEmpty(ariaLabel))
        {
            throw new InvalidOperationException("NavGroup: For accessibility reasons an aria-label should be specified on nav groups if a title isn't");
        }
    }
}