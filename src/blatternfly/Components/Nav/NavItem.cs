using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;

namespace Blatternfly.Components
{
    public class NavItem : BaseComponent
    {
        public ElementReference Element { get; protected set; }
        
        /// Parent Nav control
        [CascadingParameter] public Nav ParentNav { get; set; }
        
        /// Parent NavList control
        [CascadingParameter] public NavList ParentNavList { get; set; }
        
        /// Target navigation link.
        [Parameter] public string To { get; set; }
        
        /// Group identifier, will be returned with the onToggle and onSelect callback passed to the Nav component.
        [Parameter] public string GroupId { get; set; }
        
        /// Item identifier, will be returned with the onToggle and onSelect callback passed to the Nav component.
        [Parameter] public string ItemId { get; set; }
        
        /// Component used to render NavItems.
        [Parameter] public string Component { get; set; } = "a";

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index        = 0;
            var isActive     = !string.IsNullOrEmpty(ParentNav.ActiveItemId) && ItemId == ParentNav.ActiveItemId;
            var ariaCurrent  = isActive ? "page" : null;
            var activeClass  = isActive ? "pf-m-current" : null;
            
            builder.OpenElement(index++, "li");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-nav__item {InternalCssClass}");
            builder.AddAttribute(index++, "onclick", EventCallback.Factory.Create(this, OnClick));
            
            if (Component == "NavLink")
            {
                builder.OpenComponent<NavLink>(index++);
                builder.AddAttribute(index++, "class", $"pf-c-nav__link {InternalCssClass}");
                builder.AddAttribute(index++, "ActiveClass", "pf-m-current");
                builder.AddAttribute(index++, "href", To);
                builder.AddAttribute(index++, "aria-current", ariaCurrent);
                // builder.AddAttribute(index++, "tablindex", IsNavOpen ?  null : "-1");
                builder.AddAttribute(index++, "ChildContent", ChildContent);
                builder.CloseComponent();
            }
            else
            {
                builder.OpenElement(index++, Component);
                builder.AddAttribute(index++, "class", $"pf-c-nav__link {activeClass} {InternalCssClass}");
                builder.AddAttribute(index++, "href", To);
                builder.AddAttribute(index++, "aria-current", ariaCurrent);
                // builder.AddAttribute(index++, "tablindex", IsNavOpen ?  null : "-1");
                builder.AddContent(index++, ChildContent);
                builder.CloseElement();
            }

            builder.AddElementReferenceCapture(index, __inputReference => Element = __inputReference);
            builder.CloseElement();
        }
        
        protected override void OnInitialized()
        {
            base.OnInitialized();

            ParentNavList?.RegisterItem(this);
        }

        private async Task OnClick(MouseEventArgs args)
        {
            await ParentNav.Select(this);
        }
    }   
}
