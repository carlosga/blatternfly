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

        /// Adds accessible text to the ProgressBar. Required when title not used and there is not any label associated with the progress bar.
        [Parameter] public string AriaLabel { get; set; }
        
        /// Associates the ProgressBar with it's label for accessibility purposes. Required when title not used.
        [Parameter] public string AriaLabelledBy { get; set; }

        // protected override void OnInitialized()
        // {
        //     base.OnInitialized();
        //     
        //     if (string.IsNullOrEmpty(Title) && string.IsNullOrEmpty(AriaLabelledBy) && string.IsNullOrEmpty(AriaLabel))
        //     {
        //         Console.WriteLine("Progress: One of aria-label or aria-labelledby properties should be passed when using the progress component without a title.");
        //     }
        // }
        
        private CssBuilder CssClass => new CssBuilder("pf-c-progress")
            .AddClass("pf-m-danger"    , Variant == ProgressVariant.Danger)
            .AddClass("pf-m-success"   , Variant == ProgressVariant.Success)
            .AddClass("pf-m-warning"   , Variant == ProgressVariant.Warning)
            .AddClass("pf-m-inside"    , MeasureLocation == ProgressMeasureLocation.Inside)
            .AddClass("pf-m-outside"   , MeasureLocation == ProgressMeasureLocation.Outside)
            .AddClass("pf-m-lg"        , MeasureLocation == ProgressMeasureLocation.Inside)
            .AddClass("pf-m-lg"        , MeasureLocation != ProgressMeasureLocation.Inside && Size == ProgressSize.Large)
            .AddClass("pf-m-sm"        , MeasureLocation != ProgressMeasureLocation.Inside && Size == ProgressSize.Small)
            .AddClass("pf-m-singleline", string.IsNullOrEmpty(Title));  
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var id          = InternalId ?? Utils.GetUniqueId();
            var scaledValue = Math.Min(100.0M, Math.Max(0, Math.Floor(((Value - Min) / (Max - Min)) * 100.0M)));
            var ariaProps   = new ProgressAriaProps
            {
                Min  = Min
              , Now  = Value
              , Max  = Max
              , Text = ValueText
            };
            
            if (!string.IsNullOrEmpty(Title) || !string.IsNullOrEmpty(AriaLabelledBy))
            {
                ariaProps.LabelledBy = !string.IsNullOrEmpty(Title) ? $"{id}-description" : AriaLabelledBy;
            }
            if (!string.IsNullOrEmpty(AriaLabel))
            {
                ariaProps.Label = AriaLabel;
            }
            
            builder.OpenElement(1, "div");
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", CssClass);
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
