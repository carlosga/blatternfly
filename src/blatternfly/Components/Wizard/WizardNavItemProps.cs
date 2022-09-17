namespace Blatternfly.Components;

/// <summary>Wizard nav item properties</summary>
public sealed class WizardNavItemProps
{
    /// <summary>Whether the nav item is the currently active item.</summary>
    public bool IsCurrent { get; set; }

    /// <summary>Whether the nav item is disabled.</summary>
    public bool IsDisabled { get; set; }

    /// <summary>The step passed into the onNavItemClick callback.</summary>
    public int Step { get; set; }

    /// <summary>Callback for when the nav item is clicked.</summary>
    public EventCallback<int> OnNavItemClick { get; set; }

    /// <summary>Component used to render WizardNavItem.</summary>
    public WizardNavItemComponent NavItemComponent { get; set; }

    /// <summary>An optional url to use for when using an anchor component.</summary>
    public string Href { get; set; }

    /// <summary>Flag indicating that this NavItem has child steps and is expandable.</summary>
    public bool IsExpandable { get; set; }
}
