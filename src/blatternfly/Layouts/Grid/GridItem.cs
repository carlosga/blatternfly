using System;
using System.Text;
using Blatternfly.Layouts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class GridItem : LayoutBase
    {
        /// the number of columns the grid item spans. Value should be a number 1-12.
        [Parameter] public int? Span { get; set; }

        /// the number of rows the grid item spans. Value should be a number 1-12.
        [Parameter] public int? RowSpan { get; set; }

        /// the number of columns a grid item is offset */
        [Parameter] public int? Offset { get; set; }

        /// the number of columns the grid item spans on small device. Value should be a number 1-12.
        [Parameter] public int? Small { get; set; }

        /// the number of rows the grid item spans on medium device. Value should be a number 1-12.
        [Parameter] public int? SmallRowSpan { get; set; }

        /// the number of columns the grid item is offset on small device. Value should be a number 1-12.
        [Parameter] public int? SmallOffset { get; set; }

        /// the number of columns the grid item spans on medium device. Value should be a number 1-12.
        [Parameter] public int? Medium { get; set; }

        /// the number of rows the grid item spans on medium device. Value should be a number 1-12.
        [Parameter] public int? MediumRowSpan { get; set; }

        /// the number of columns the grid item is offset on medium device. Value should be a number 1-12.
        [Parameter] public int? MediumOffset { get; set; }

        /// the number of columns the grid item spans on large device. Value should be a number 1-12.
        [Parameter] public int? Large { get; set; }

        /// the number of rows the grid item spans on large device. Value should be a number 1-12.
        [Parameter] public int? LargeRowSpan { get; set; }

        /// the number of columns the grid item is offset on large device. Value should be a number 1-12.
        [Parameter] public int? LargeOffset { get; set; }

        /// the number of columns the grid item spans on xLarge device. Value should be a number 1-12.
        [Parameter] public int? ExtraLarge { get; set; }

        /// the number of rows the grid item spans on large device. Value should be a number 1-12.
        [Parameter] public int? ExtraLargeRowSpan { get; set; }

        /// the number of columns the grid item is offset on xLarge device. Value should be a number 1-12.
        [Parameter] public int? ExtraLargeOffset { get; set; }

        /// the number of columns the grid item spans on 2xLarge device. Value should be a number 1-12.
        [Parameter] public int? ExtraLarge2 { get; set; }

        /// the number of rows the grid item spans on 2xLarge device. Value should be a number 1-12.
        [Parameter] public int? ExtraLarge2RowSpan { get; set; }

        /// the number of columns the grid item is offset on 2xLarge device. Value should be a number 1-12.
        [Parameter] public int? ExtraLarge2Offset { get; set; }

        /// Modifies the flex layout element order property.
        [Parameter] public GridOrder Order { get; set; }
        
        /// Sets the base component to render. defaults to div.
        [Parameter] public string Component { get; set; } = "div";
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var cssbuilder = new StringBuilder();

            ComputeClasses(cssbuilder, null, Span, RowSpan, Offset);
            ComputeClasses(cssbuilder, DeviceSizes.Small, Small, SmallRowSpan, SmallOffset);
            ComputeClasses(cssbuilder, DeviceSizes.Medium, Medium, MediumRowSpan, MediumOffset);
            ComputeClasses(cssbuilder, DeviceSizes.Large, Large, LargeRowSpan, LargeOffset);
            ComputeClasses(cssbuilder, DeviceSizes.ExtraLarge, ExtraLarge, ExtraLargeRowSpan, ExtraLargeOffset);
            ComputeClasses(cssbuilder, DeviceSizes.ExtraLarge2, ExtraLarge2, ExtraLarge2RowSpan, ExtraLarge2Offset);
            
            var computedClasses = cssbuilder.ToString();
            var cssStyle        = $"{InternalCssStyle} {Order?.CssStyle}";
            
            if (string.IsNullOrWhiteSpace(cssStyle))
            {
                cssStyle = null;
            }
            
            builder.OpenElement(1, Component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-l-grid__item {computedClasses}");
            builder.AddAttribute(4, "style", cssStyle);
            builder.AddContent(5, ChildContent);
            builder.CloseElement();            
        }

        protected override void OnParametersSet()
        {
            ValidateRange(nameof(Span), Span);
            ValidateRange(nameof(RowSpan), RowSpan);
            ValidateRange(nameof(Offset), Offset);

            ValidateRange(nameof(Small), Small);
            ValidateRange(nameof(SmallRowSpan), SmallRowSpan);
            ValidateRange(nameof(SmallOffset), SmallOffset);

            ValidateRange(nameof(Medium), Medium);
            ValidateRange(nameof(MediumRowSpan), MediumRowSpan);
            ValidateRange(nameof(MediumOffset), MediumOffset);

            ValidateRange(nameof(Large), Large);
            ValidateRange(nameof(LargeRowSpan), LargeRowSpan);
            ValidateRange(nameof(LargeOffset), LargeOffset);

            ValidateRange(nameof(ExtraLarge), ExtraLarge);
            ValidateRange(nameof(ExtraLargeRowSpan), ExtraLargeRowSpan);
            ValidateRange(nameof(ExtraLargeOffset), ExtraLargeOffset);

            ValidateRange(nameof(ExtraLarge2), ExtraLarge2);
            ValidateRange(nameof(ExtraLarge2RowSpan), ExtraLarge2RowSpan);
            ValidateRange(nameof(ExtraLarge2Offset), ExtraLarge2Offset);

            base.OnParametersSet();
        }

        private static void ComputeClasses(StringBuilder builder, DeviceSizes? size, int? span, int? rowSpan, int? offset)
        {
            if (span.HasValue)
            {
                builder.AppendFormat($"pf-m-{span.Value}-col");
                AppendSize(builder, size);
            }

            if (rowSpan.HasValue)
            {
                builder.AppendFormat($"pf-m-{rowSpan.Value}-row");
                AppendSize(builder, size);
            }

            if (offset.HasValue)
            {
                builder.AppendFormat($"pf-m-offset-{offset.Value}-col");
                AppendSize(builder, size);
            }
        }

        private static void AppendSize(StringBuilder builder, DeviceSizes? size)
        {
            switch (size)
            {
                case null:
                    builder.Append(" ");
                    break;
                case DeviceSizes.Small:
                    builder.Append("-on-sm ");
                    break;
                case DeviceSizes.Medium:
                    builder.Append("-on-md ");
                    break;
                case DeviceSizes.Large:
                    builder.Append("-on-lg ");
                    break;
                case DeviceSizes.ExtraLarge:
                    builder.Append("-on-xl ");
                    break;
                case DeviceSizes.ExtraLarge2:
                    builder.Append("-on-2xl ");
                    break;
            }
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