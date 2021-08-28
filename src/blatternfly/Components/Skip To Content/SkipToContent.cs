using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class SkipToContent : BaseComponent
    {
        public ElementReference Element { get; protected set; }
        
        /// The skip to content link.
        [Parameter] public string Href { get; set; }

        /// Forces the skip to component to display. This is primarily for demonstration purposes and would not normally be used. */
        [Parameter] public bool Show { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(1, "a");
            builder.AddAttribute(2, "class", $"pf-c-skip-to-content pf-c-button pf-m-primary");
            builder.AddAttribute(3, "href", Href);
            builder.AddMultipleAttributes(4, AdditionalAttributes);
            builder.AddElementReferenceCapture(5, __inputReference => Element = __inputReference);
            builder.AddContent(6, ChildContent);
            builder.CloseElement();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            
            if (firstRender)
            {
                if (Show)
                {
                    await Task.Yield();
                    await Element.FocusAsync();
                }
            }
        }
    }
}
