using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class Progress : BaseComponent
    {
        /// Size variant of progress.
        [Parameter] public ProgressSize? Size { get; set; }

        /// Where the measure percent will be located.
        [Parameter] public ProgressMeasureLocation MeasureLocation { get; set; } = ProgressMeasureLocation.Top;

        /// Status variant of progress.
        [Parameter] public ProgressVariant? Variant { get; set; }

        /// Title above progress.
        [Parameter] public string Title { get; set; }

        /// Text description of current progress value to display instead of percentage.
        [Parameter] public RenderFragment Label { get; set; }

        /// Actual value of progress.
        [Parameter] public decimal Value { get; set; } = decimal.Zero;

        /// Minimal value of progress.
        [Parameter] public decimal Min { get; set; } = decimal.Zero;

        /// Maximum value of progress.
        [Parameter] public decimal Max { get; set; } = 100.0M;

        /// Accessible text description of current progress value, for when value is not a percentage. Use with label.
        [Parameter] public string ValueText { get; set; }

        /// Indicate whether to truncate the title.
        [Parameter] public bool IsTitleTruncated { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            // TODO: Throw Exception ??
            // if (title && !ariaLabelledBy && !ariaLabel) {
            //     /* eslint-disable no-console */
            //     console.warn(
            //         'One of aria-label or aria-labelledby properties should be passed when using the progress component without a title.'
            //     );
            // }
            
            var id          = InternalId ?? Utils.GetUniqueId();
            var scaledValue = Math.Min(100.0M, Math.Max(0, Math.Floor(((Value - Min) / (Max - Min)) * 100.0M)));
            var ariaProps   = new ProgressAriaProps
            {
                Min  = Min
              , Now  = Value
              , Max  = Max
              , Text = ValueText
            };
            
            var ariaLabelledBy = GetPropertyValue("aria-labelledby");
            if (!string.IsNullOrEmpty(Title) || !string.IsNullOrEmpty(ariaLabelledBy))
            {
                ariaProps.LabelledBy = !string.IsNullOrEmpty(Title) ? $"{id}-description" : ariaLabelledBy;
            }
            var ariaLabel = GetPropertyValue("aria-label");
            if (!string.IsNullOrEmpty(ariaLabel))
            {
                ariaProps.AriaLabel = ariaLabel;
            }

            var variantClass = Variant switch
            {
                ProgressVariant.Danger  => "pf-m-danger",
                ProgressVariant.Success => "pf-m-success",
                ProgressVariant.Warning => "pf-m-warning",
                _                       => null
            };

            var locationClass = MeasureLocation switch
            {
                ProgressMeasureLocation.Inside  => "pf-m-inside",
                ProgressMeasureLocation.Outside => "pf-m-outside",
                _                               => null
            };

            string sizeClass;

            if (MeasureLocation == ProgressMeasureLocation.Inside)
            {
                sizeClass = "pf-m-lg";
            }
            else
            {
                sizeClass = Size switch
                {
                    ProgressSize.Large  => "pf-m-lg",
                    ProgressSize.Small  => "pf-m-sm",
                    _                   => null
                };
            }

            var singleLineClass = string.IsNullOrEmpty(Title) ? "pf-m-singleline" : null;

            builder.OpenElement(1, "div");
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-c-progress {variantClass} {locationClass} {sizeClass} {singleLineClass}");
            builder.AddAttribute(4, "id", id);

            builder.OpenComponent<ProgressContainer>(5);
            builder.AddAttribute(6, "ParentId", id);
            builder.AddAttribute(7, "Value", scaledValue);
            builder.AddAttribute(8, "Title", Title);
            builder.AddAttribute(9, "Label", Label);
            builder.AddAttribute(10, "Variant", Variant);
            builder.AddAttribute(11, "MeasureLocation", MeasureLocation);
            builder.AddAttribute(12, "AriaProps", ariaProps);
            builder.AddAttribute(13, "IsTitleTruncated", IsTitleTruncated);
            builder.CloseComponent();

            builder.CloseElement();
        }
    }
}
