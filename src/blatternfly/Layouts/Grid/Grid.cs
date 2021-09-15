using System;
using System.Text;
using Blatternfly.Layouts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class Grid : LayoutBase
    {
        /// Adds space between children.
        [Parameter] public bool HasGutter { get; set; }

        /// The number of rows a column in the grid should span. Value should be a number 1-12.
        [Parameter] public int? Span { get; set; }

        /// the number of columns all grid items should span on a small device.
        [Parameter] public int? Small { get; set; }

        /// the number of columns all grid items should span on a medium device.
        [Parameter] public int? Medium { get; set; }

        /// the number of columns all grid items should span on a large device.
        [Parameter] public int? Large { get; set; }

        /// the number of columns all grid items should span on a xLarge device.
        [Parameter] public int? ExtraLarge { get; set; }

        /// the number of columns all grid items should span on a 2xLarge device.
        [Parameter] public int? ExtraLarge2 { get; set; }

        /// Modifies the flex layout element order property.
        [Parameter] public GridOrder Order { get; set; }
        
        /// Sets the base component to render. defaults to div.
        [Parameter] public string Component { get; set; } = "div";
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var spanClass   = Span.HasValue        ? $"pf-m-all-{Span.Value}-col" : null;
            var smClass     = Small.HasValue       ? $"pf-m-all-{Small.Value}-col-on-sm" : null;
            var mdClass     = Medium.HasValue      ? $"pf-m-all-{Medium.Value}-col-on-md" : null;
            var lgClass     = Large.HasValue       ? $"pf-m-all-{Large.Value}-col-on-lg" : null;
            var xlClass     = ExtraLarge.HasValue  ? $"pf-m-all-{ExtraLarge.Value}-col-on-xl" : null;
            var xl2Class    = ExtraLarge2.HasValue ? $"pf-m-all-{ExtraLarge2.Value}-col-on-2xl" : null;
            var gutterClass = HasGutter            ? "pf-m-gutter" : null;
            
            builder.OpenElement(1, Component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-l-grid {spanClass} {smClass} {mdClass} {lgClass} {xlClass} {xl2Class} {gutterClass}");
            builder.AddAttribute(4, "style", Order?.CssStyle);
            builder.AddContent(5, ChildContent);
            builder.CloseElement();       
        }

        protected override void OnParametersSet()
        {
            ValidateRange(nameof(Span), Span);
            ValidateRange(nameof(Small), Small);
            ValidateRange(nameof(Medium), Medium);
            ValidateRange(nameof(Large), Large);
            ValidateRange(nameof(ExtraLarge), ExtraLarge);
            ValidateRange(nameof(ExtraLarge2), ExtraLarge2);

            base.OnParametersSet();
        }

        private static void ValidateRange(string name, int? value)
        {
            if (!value.HasValue)
            {
                return;
            }

            if (value.Value < 0 || value.Value > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(name));
            }
        }
    }
}
