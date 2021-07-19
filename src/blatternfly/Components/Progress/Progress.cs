using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class Progress : BaseComponent
    {
        /// Size variant of progress.
        [Parameter] public ProgressSize Size { get; set; } = ProgressSize.Medium;

        /// Where the measure percent will be located.
        [Parameter] public ProgressMeasureLocation MeasureLocation { get; set; } = ProgressMeasureLocation.Top;

        /// Status variant of progress.
        [Parameter] public ProgressVariant Variant { get; set; } = ProgressVariant.Info;

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
            var index       = 0;
            var id          = InternalId ?? Utils.GetUniqueId();
            var scaledValue = Math.Min(100.0M, Math.Max(0, Math.Floor(((Value - Min) / (Max - Min)) * 100.0M)));
            var ariaProps   = new ProgressAriaProps
            {
                LabelledBy = $"{id}-description"
              , Min        = Min
              , Now        = Value
              , Max        = Max
              , Text       = ValueText
            };

            var variantClass = Variant switch
            {
                ProgressVariant.Danger  => "pf-m-danger",
                ProgressVariant.Info    => "pf-m-info",
                ProgressVariant.Success => "pf-m-success",
                ProgressVariant.Warning => "pf-m-warning",
                _                       => null
            };

            var locationClass = MeasureLocation switch
            {
                ProgressMeasureLocation.Inside  => "pf-m-inside",
                ProgressMeasureLocation.Outside => "pf-m-outside",
                ProgressMeasureLocation.Top     => "pf-m-top",
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
                    ProgressSize.Medium => "pf-m-md",
                    ProgressSize.Small  => "pf-m-sm",
                    _                   => null
                };
            }

            var singleLineClass = string.IsNullOrEmpty(Title) ? "pf-m-singleline" : null;

            builder.OpenElement(index++, "div");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-progress {variantClass} {locationClass} {sizeClass} {singleLineClass}");
            builder.AddAttribute(index++, "id", id);

            builder.OpenComponent<ProgressContainer>(index++);
            builder.AddAttribute(index++, "ParentId", id);
            builder.AddAttribute(index++, "Value", scaledValue);
            builder.AddAttribute(index++, "Title", Title);
            builder.AddAttribute(index++, "Label", Label);
            builder.AddAttribute(index++, "Variant", Variant);
            builder.AddAttribute(index++, "MeasureLocation", MeasureLocation);
            builder.AddAttribute(index++, "AriaProps", ariaProps);
            builder.AddAttribute(index++, "IsTitleTruncated", IsTitleTruncated);
            builder.CloseComponent();

            builder.CloseElement();
        }
    }
}
