namespace Blatternfly.Components;

public partial class PageHeader : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Component to render the logo/brand (e.g. <Brand />).</summary>
    [Parameter] public RenderFragment Logo { get; set; }

    /// <summary>Component to use to wrap the passed <logo />.</summary>
    [Parameter] public LogoComponent LogoComponent { get; set; } = LogoComponent.a;

    /// <summary>Component to render the toolbar (e.g. <Toolbar />).</summary>
    [Parameter] public RenderFragment HeaderTools { get; set; }

    /// <summary>Component to render the avatar (e.g. <Avatar />.</summary>
    [Parameter] public RenderFragment TopNav { get; set; }

    /// <summary>True to show the nav toggle button (toggles side nav).</summary>
    [Parameter] public bool ShowNavToggle { get; set; }

    /// <summary>Id for the nav toggle button.</summary>
    [Parameter] public string NavToggleId { get; set; } = "nav-toggle";

    /// <summary>True if the side nav is shown.</summary>
    [Parameter] public bool IsNavOpen { get; set; } = true;

    /// <summary>Sets the value for role on the <main /> element.</summary>
    [Parameter] public string Role { get; set; }

    /// <summary>Callback function to handle the side nav toggle button, managed by the Page component if the Page isManagedSidebar prop is set to true.</summary>
    [Parameter] public EventCallback<bool> OnNavToggle { get; set; }

    /// <summary>Aria Label for the nav toggle button.</summary>
    [Parameter] public string AriaLabel { get; set; } = "Global navigation";

    private string CssClass => new CssBuilder("pf-c-page__header")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string AriaExpanded { get => IsNavOpen ? "true" : "false"; }

    private async Task NavToggle(MouseEventArgs args)
    {
        IsNavOpen = !IsNavOpen;
        await OnNavToggle.InvokeAsync(IsNavOpen);
    }
}