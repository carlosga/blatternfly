namespace Blatternfly.Components;

public partial class WizardNavItem : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>The content to display in the nav item.</summary>
    [Parameter] public RenderFragment Content { get; set; }

    /// <summary>Whether the nav item is the currently active item.</summary>
    [Parameter] public bool IsCurrent { get; set; }

    /// <summary>Whether the nav item is disabled.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>The step passed into the onNavItemClick callback.</summary>
    [Parameter] public int Step { get; set; }

    /// <summary>Callback for when the nav item is clicked.</summary>
    [Parameter] public EventCallback<int> OnNavItemClick { get; set; }

    /// <summary>Component used to render WizardNavItem.</summary>
    [Parameter] public WizardNavItemComponent NavItemComponent { get; set; } = WizardNavItemComponent.Button;

    /// <summary>An optional url to use for when using an anchor component.</summary>
    [Parameter] public string Href { get; set; }

    /// <summary>Flag indicating that this NavItem has child steps and is expandable.</summary>
    [Parameter] public bool IsExpandable { get; set; }

    /// <summary>The id for the nav item.</summary>
    [Parameter] public string id { get; set; }

    private bool IsExpanded { get; set; }

    private string CssClass => new CssBuilder("pf-c-wizard__nav-item")
        .AddClass("pf-m-expandable", IsExpandable)
        .AddClass("pf-m-expanded"  , IsExpandable && IsExpanded)
        .Build();

    private string NavLinkCssClass => new CssBuilder("pf-c-wizard__nav-link")
        .AddClass("pf-m-current"  , IsCurrent)
        .AddClass("pf-m-disabled" , IsDisabled)
        .Build();

    private string Component    { get => NavItemComponent is WizardNavItemComponent.Button ? "button" : "a"; }
    private string AriaDisabled { get => IsDisabled ? "true" : null; }
    private string AriaCurrent  { get => IsCurrent && ChildContent is null ? "step" : "false"; }
    private string AriaExpanded { get => IsExpandable && IsExpanded ? "true" : null; }
    private string Disabled
    {
        get
        {
            if (NavItemComponent is WizardNavItemComponent.Button)
            {
                return IsDisabled ? "true" : null;
            }
            return null;
        }
    }
    private string TabIndex
    {
        get
        {
            if (NavItemComponent is not WizardNavItemComponent.Button)
            {
                return IsDisabled ? "-1" : null;
            }

            return null;
        }
    }
    private string HrefValue
    {
        get
        {
            if (NavItemComponent is not WizardNavItemComponent.Button)
            {
                return Href;
            }

            return null;
        }
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (NavItemComponent == WizardNavItemComponent.Link && string.IsNullOrEmpty(Href))
        {
            throw new Exception("WizardNavItem: When using an anchor, please provide an href.");
        }

        IsExpanded = IsCurrent;
    }

    private async Task OnNavItemClickHandler(MouseEventArgs _)
    {
        if (IsExpandable)
        {
            IsExpanded = !IsExpanded || IsCurrent;
        }
        else
        {
            await OnNavItemClick.InvokeAsync(Step);
        }
    }
}
