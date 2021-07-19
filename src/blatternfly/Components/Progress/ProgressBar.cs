using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class ProgressBar : BaseComponent
    {
        /// Actual progress value.
        [Parameter] public decimal Value { get; set; }

        [Parameter] public ProgressAriaProps AriaProps { get; set; }

        /// Location of progress value.
        [Parameter] public ProgressMeasureLocation MeasureLocation { get; set; } = ProgressMeasureLocation.Top;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index     = 0;
            var ariaProps = new Dictionary<string, object>
            {
                { "aria-labelledby", AriaProps?.LabelledBy }
              , { "aria-valuemin"  , AriaProps?.Min?.ToString(CultureInfo.InvariantCulture) ?? "0" }
              , { "aria-valuenow"  , AriaProps?.Now?.ToString(CultureInfo.InvariantCulture) ?? "0" }
              , { "aria-valuemax"  , AriaProps?.Max?.ToString(CultureInfo.InvariantCulture) ?? "0" }
              , { "aria-valuetext" , AriaProps?.Text }
            };

            builder.OpenElement(index++, "div");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddMultipleAttributes(index++, ariaProps);
            builder.AddAttribute(index++, "class", "pf-c-progress__bar");

            builder.OpenElement(index++, "div");
            builder.AddAttribute(index++, "class", "pf-c-progress__indicator");
            builder.AddAttribute(index++, "style", $"width: {Value.ToString(CultureInfo.InvariantCulture)}%;");

            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-progress__measure");
            if (MeasureLocation == ProgressMeasureLocation.Inside)
            {
                builder.AddContent(index++, (Value / 100.0M).ToString("P0"));
            }
            builder.CloseElement();

            builder.CloseElement();

            builder.CloseElement();
        }
    }
}
