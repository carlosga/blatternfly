using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public partial class Card : BaseComponent
    {
        /// Sets the base component to render. defaults to article.
        [Parameter] public string Component { get; set; } = "article";

        /// Modifies the card to include hover styles on :hover.
        [Parameter] public bool IsHoverable { get; set; }

        /// Modifies the card to include compact styling.
        [Parameter] public bool IsCompact { get; set; }

        /// Modifies the card to include selectable styling.
        [Parameter] public bool IsSelectable { get; set; }

        // Modifies the card to include selected styling.
        [Parameter] public bool IsSelected { get; set; }

        /// Modifies the card to include flat styling.
        [Parameter] public bool IsFlat { get; set; } = false;

        /// Modifies the card to include rounded styling.
        [Parameter] public bool IsRounded { get; set; } = false;

        /// Modifies the card to be large. Should not be used with isCompact.
        [Parameter] public bool IsLarge { get; set; } = false;

        /// Cause component to consume the available height of its container.
        [Parameter] public bool IsFullHeight { get; set; } = false;

        /// Modifies the card to include plain styling; this removes border and background.
        [Parameter] public bool IsPlain { get; set; } = false;

        /// Flag indicating if a card is expanded. Modifies the card to be expandable.
        [Parameter] public bool IsExpanded { get; set; } = false;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var hoverClass      = IsHoverable  ? "pf-m-hoverable"   : null;
            var compactClass    = IsCompact    ? "pf-m-compact"     : null;
            var selectableClass = IsSelectable ? "pf-m-selectable"  : null;
            var selectedClass   = IsSelected   ? "pf-m-selected"    : null;
            var flatClass       = IsFlat       ? "pf-m-flat"        : null;
            var roundedClass    = IsRounded    ? "pf-m-rounded"     : null;
            var largeClass      = IsLarge      ? "pf-m-display-lg"  : null;
            var heightClass     = IsFullHeight ? "pf-m-full-height" : null;
            var plainClass      = IsPlain      ? "pf-m-plain"       : null;
            var expandedClass   = IsExpanded   ? "pf-m-expanded"    : null;

            builder.OpenElement(1, Component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-c-card {hoverClass} {compactClass} {selectableClass} {selectedClass} {flatClass} {roundedClass} {largeClass} {heightClass} {plainClass} {expandedClass}");
            builder.AddAttribute(4, "tabindex", IsSelectable ? "0" : null);
            builder.OpenComponent<CascadingValue<Card>>(5);
            builder.AddAttribute(6, "Value", this);
            builder.AddAttribute(7, "ChildContent", ChildContent);
            builder.CloseElement();
            builder.CloseElement();
        }
    }
}
