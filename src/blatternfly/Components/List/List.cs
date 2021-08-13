using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public partial class List : BaseComponent
    {
        /// Adds list variant styles.
        [Parameter] public ListVariant Variant { get; set; } = ListVariant.None;

        /// Modifies the list to add borders between items.
        [Parameter] public bool IsBordered { get; set; }

        /// Modifies the list to include plain styling.
        [Parameter] public bool IsPlain { get; set; }

        /// Modifies the size of the icons in the list.
        [Parameter] public ListIconSize IconSize { get; set; } = ListIconSize.Default;

        /// Sets the way items are numbered if variant is set to ordered.
        [Parameter] public OrderType Type { get; set; } = OrderType.Number;

        [Parameter] public ListComponent Component { get; set; } = ListComponent.ul;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index        = 0;
            var variantClass = Variant == ListVariant.Inline ? "pf-m-inline" : null;
            var borderClass  = IsBordered ? "pf-m-bordered" : null;
            var plainClass   = IsPlain ? "pf-m-plain" : null;
            var iconClass    = IconSize == ListIconSize.Large ? "pf-m-icon-lg" : null;
            var component    = Component == ListComponent.ul ? "ul" : "ol";

            builder.OpenElement(index++, component);
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-list {variantClass} {borderClass} {plainClass} {iconClass}");
            if (Component == ListComponent.ol)
            {
                var type = Type switch
                {
                    OrderType.Number               => "1",
                    OrderType.LowercaseLetter      => "a",
                    OrderType.UppercaseLetter      => "A",
                    OrderType.LowercaseRomanNumber => "i",
                    OrderType.UppercaseRomanNumber => "I",
                    _                              => null
                };

                builder.AddAttribute(index++, "type", type);
            }
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
    }
}
