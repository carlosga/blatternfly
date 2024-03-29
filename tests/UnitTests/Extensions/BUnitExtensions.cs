﻿using Blatternfly.UnitTests.Components;

namespace Bunit;

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

    internal static ComponentParameterCollectionBuilder<T> AddNavExpandableItems<T>(this ComponentParameterCollectionBuilder<T> parameters, NavItemInfo[] items, string className = null) where T: NavExpandable
    {
        foreach (var item in items)
        {
            parameters.Add<NavItem>(p => p.ChildContent, itemparams => itemparams
                .AddUnmatched("class", className)
                .Add(p => p.To, item.To)
                .Add(p => p.ChildContent, item.Label)
            );
        }
        return parameters;
    }

    internal static ComponentParameterCollectionBuilder<T> AddNavListItems<T>(this ComponentParameterCollectionBuilder<T> parameters, NavItemInfo[] items, string className = null) where T: NavList
    {
        foreach (var item in items)
        {
            parameters.Add<NavItem>(p => p.ChildContent, itemparams => itemparams
                .AddUnmatched("class", className)
                .Add(p => p.To, item.To)
                .Add(p => p.ChildContent, item.Label)
            );
        }
        return parameters;
    }
}
