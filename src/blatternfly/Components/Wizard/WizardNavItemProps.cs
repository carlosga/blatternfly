using Microsoft.AspNetCore.Components;

namespace Blatternfly.Components;

public sealed class WizardNavItemProps
{
    /// Whether the nav item is the currently active item.
    public bool IsCurrent { get; set; }
    
    /// Whether the nav item is disabled.
    public bool IsDisabled { get; set; }
    
    /// The step passed into the onNavItemClick callback.
    public int Step { get; set; }
    
    /// Callback for when the nav item is clicked.
    public EventCallback<int> OnNavItemClick { get; set; }
    
    /// Component used to render WizardNavItem.
    public WizardNavItemComponent NavItemComponent { get; set; }
        
    /// An optional url to use for when using an anchor component.
    public string Href { get; set; }
    
    /// Flag indicating that this NavItem has child steps and is expandable.
    public bool IsExpandable { get; set; }        
}
