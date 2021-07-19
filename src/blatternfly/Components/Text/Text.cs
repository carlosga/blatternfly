using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class Text : BaseComponent
    {
        /// The text component.
        [Parameter] public TextVariants Component { get; set; } = TextVariants.p;

        /// Flag to indicate the link has visited styles applied if the browser determines the link has been visited.
        [Parameter] public bool IsVisitedLink { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var visitedClass = IsVisitedLink && Component == TextVariants.a ? "pf-m-visited" : null;
            var component    = Component switch
            {
                TextVariants.blockquote => "blockquote",
                TextVariants.h1         => "h1",
                TextVariants.h2         => "h2",
                TextVariants.h3         => "h3",
                TextVariants.h4         => "h4",
                TextVariants.h5         => "h5",
                TextVariants.h6         => "h6",
                TextVariants.a          => "a",
                TextVariants.p          => "p",
                TextVariants.pre        => "pre",
                TextVariants.small      => "small",
                _                       => null
            };
            
            builder.OpenElement(0, component);
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "class", $"{visitedClass} {InternalCssClass}");
            builder.AddAttribute(3, "data-pf-content", "true");
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
