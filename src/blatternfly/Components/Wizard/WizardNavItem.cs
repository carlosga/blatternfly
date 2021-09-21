using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace Blatternfly.Components
{
    public class WizardNavItemz : BaseComponent
    {
        /// The content to display in the nav item.
        [Parameter] public RenderFragment Content { get; set; }

        /// Whether the nav item is the currently active item.
        [Parameter] public bool IsCurrent { get; set; }

        /// Whether the nav item is disabled.
        [Parameter] public bool IsDisabled { get; set; }

        /// The step passed into the onNavItemClick callback.
        [Parameter] public int Step { get; set; }

        /// Callback for when the nav item is clicked.
        [Parameter] public EventCallback<int> OnNavItemClick { get; set; }

        /// Component used to render WizardNavItem.
        [Parameter] public WizardNavItemComponent NavItemComponent { get; set; } = WizardNavItemComponent.Button;

        /// An optional url to use for when using an anchor component.
        [Parameter] public string Href { get; set; }

        /// Flag indicating that this NavItem has child steps and is expandable.
        [Parameter] public bool IsExpandable { get; set; }

        private bool IsExpanded { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (NavItemComponent == WizardNavItemComponent.Link && string.IsNullOrEmpty(Href))
            {
                throw new Exception("WizardNavItem: When using an anchor, please provide an href.");
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index           = 0;
            var component       = NavItemComponent == WizardNavItemComponent.Button ? "button" : "a";
            var expandableClass = IsExpandable ? "pf-m-expandable" : null;
            var expandedClass   = IsExpandable && IsExpanded ? "pf-m-expanded" : null;
            var currentClass    = IsCurrent ? "pf-m-current" : null;
            var disabledClass   = IsDisabled ? "pf-m-disabled" : null;
            int? tabIndex       = IsDisabled ? -1 : null;

            builder.OpenElement(index++, "li");
            builder.AddAttribute(index++, "class", $"pf-c-wizard__nav-item {expandableClass} {expandedClass}");

            builder.OpenElement(index++, component);
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-wizard__nav-link {currentClass} {disabledClass}");
            builder.AddAttribute(index++, "aria-disabled", IsDisabled ? "true" : null);
            builder.AddAttribute(index++, "aria-current", IsCurrent && ChildContent == null ? "page" : "false");
            builder.AddAttribute(index++, "aria-expanded", IsExpandable && IsExpanded ? "true" : null);

            if (NavItemComponent == WizardNavItemComponent.Button)
            {
                builder.AddAttribute(index++, "disabled", IsDisabled ? "true" : null);
            }
            else
            {
                builder.AddAttribute(index++, "tabindex", tabIndex);
                builder.AddAttribute(index++, "href", "Href");
            }

            if (IsExpandable)
            {
                builder.AddAttribute(index++, "onclick", EventCallback.Factory.Create(this, SetIsExpanded));
            }
            else
            {
                builder.AddAttribute(index++, "onclick", EventCallback.Factory.Create(this, OnNavItemClickHandler));
            }

            if (IsExpandable)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-wizard__nav-link-text");
                builder.AddContent(index++, Content);
                builder.CloseElement();
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-wizard__nav-link-toggle");
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-wizard__nav-link-toggle-icon");
                builder.OpenComponent<AngleRightIcon>(index++);
                builder.CloseComponent();
                builder.CloseElement();
                builder.CloseElement();
            }
            else
            {
                builder.AddContent(index++, Content);
            }

            builder.CloseElement();

            builder.AddContent(index++, ChildContent);

            builder.CloseElement();
        }

        private void SetIsExpanded(MouseEventArgs _)
        {
            IsExpanded = !IsExpanded || IsCurrent;
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
}
