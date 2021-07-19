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
            var index        = 0;
            var visitedClass = IsVisited ? "pf-m-visited" : null;

            builder.OpenElement(index++, "div");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-content {visitedClass}");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
    }
}
