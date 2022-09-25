namespace Blatternfly.Components;

public partial class PageSidebar : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// If true, manages the sidebar open/close state and there is no need to pass the isNavOpen boolean into
    /// the sidebar component or add a callback onNavToggle function into the PageHeader component
    /// </summary>
    [Parameter] public bool IsManagedSidebar { get; set; }

    /// <summary>Programmatically manage if the side nav is shown, if isManagedSidebar is set to true in the Page component, this prop is managed.</summary>
    [Parameter] public bool IsNavOpen { get; set; } = true;

    /// <summary>Indicates the color scheme of the sidebar.</summary>
    [Parameter] public ThemeVariant Theme { get; set; } = ThemeVariant.Dark;

    private string CssClass => new CssBuilder("pf-c-page__sidebar")
        .AddClass("pf-m-light"    , Theme is ThemeVariant.Light)
        .AddClass("pf-m-expanded" , NavOpen)
        .AddClass("pf-m-collapsed", !NavOpen)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string InternalId { get => AdditionalAttributes?.GetPropertyValue(HtmlElement.Id); }
    private string SidebarId  { get => !string.IsNullOrEmpty(InternalId) ? InternalId : "page-sidebar"; }

    private bool   ManagedIsNavOpen { get => IsManagedSidebar && IsNavOpen; }
    private bool   NavOpen          { get => IsManagedSidebar ? ManagedIsNavOpen : IsNavOpen; }
    private string AriaHidden       { get => !NavOpen ? "true" : "false"; }
}