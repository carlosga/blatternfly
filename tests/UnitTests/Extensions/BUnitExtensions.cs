using Blatternfly.Components;

namespace Bunit
{
    internal static class BUnitExtensions
    {
        internal static ComponentParameterCollectionBuilder<Dropdown> AddDropdownItems(this ComponentParameterCollectionBuilder<Dropdown> parameters)
        {
            parameters
                .Add<DropdownItem>(p => p.DropdownItems, p1 => p1.AddChildContent("Link"))
                .Add<DropdownItem>(p => p.DropdownItems, p2 => p2.AddChildContent("Action").Add(p => p.Component, "button"))
                .Add<DropdownItem>(p => p.DropdownItems, p2 => p2.AddChildContent("Disabled Link").Add(p => p.IsDisabled, true))
                .Add<DropdownItem>(p => p.DropdownItems, p2 => p2.AddChildContent("Disabled Action").Add(p => p.IsDisabled, true).Add(p => p.Component, "button"))
                .Add<DropdownSeparator>(p => p.DropdownItems)
                .Add<DropdownItem>(p => p.DropdownItems, p1 => p1.AddChildContent("Separated Link"))
                .Add<DropdownItem>(p => p.DropdownItems, p2 => p2.AddChildContent("Separated Action").Add(p => p.Component, "button"));
            
            return parameters;
        }
    }
}
