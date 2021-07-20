using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class TextContent : BaseComponent
    {
        /// Flag to indicate the all links in a the content block have visited styles applied if the browser determines the link has been visited.
        [Parameter] public bool IsVisited { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var visitedClass = IsVisited ? "pf-m-visited" : null;

            builder.OpenElement(1, "div");
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-c-content {visitedClass}");
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
