using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class ProgressContainer : BaseComponent
    {
        /// Properties needed for aria support.
        [Parameter] public ProgressAriaProps AriaProps { get; set; }

        /// Progress component DOM ID.
        [Parameter] public string ParentId { get; set; }

        /// Progress title.
        [Parameter] public string Title { get; set; }

        /// Label to indicate what progress is showing.
        [Parameter] public RenderFragment Label { get; set; }

        /// Type of progress status.
        [Parameter] public ProgressVariant Variant { get; set; } = ProgressVariant.Info;

        /// Location of progress value.
        [Parameter] public ProgressMeasureLocation MeasureLocation { get; set; } = ProgressMeasureLocation.Top;

        /// Actual progress value.
        [Parameter] public decimal Value { get; set; }

        /// Indicate whether to truncate the title.
        [Parameter] public bool IsTitleTruncated { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;
            var truncateClass = IsTitleTruncated ? "pf-m-truncate" : null;

            builder.OpenElement(index++, "div");
            builder.AddAttribute(index++, "class", $"pf-c-progress__description {truncateClass}");
            builder.AddAttribute(index++, "id", $"{ParentId}-description");
            builder.AddAttribute(index++, "aria-hidden", "true");
            builder.AddContent(index++, Title);
            builder.CloseElement();

            builder.OpenElement(index++, "div");
            builder.AddAttribute(index++, "class", "pf-c-progress__status");
            builder.AddAttribute(index++, "aria-hidden", "true");
            if (MeasureLocation == ProgressMeasureLocation.Top || MeasureLocation == ProgressMeasureLocation.Outside)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-progress__measure");
                if (Label != null)
                {
                    builder.AddContent(index++, Label);
                }
                else
                {
                    builder.AddContent(index++, $"{Value}%");
                }
                builder.CloseElement();
            }
            if (Variant == ProgressVariant.Danger || Variant == ProgressVariant.Success)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-progress__status-icon");
                builder.OpenComponent(index++, Variant == ProgressVariant.Danger ? typeof(TimesCircleIcon) : typeof(CheckCircleIcon));
                builder.CloseComponent();
                builder.CloseElement();
            }
            builder.CloseElement();

            builder.OpenComponent<ProgressBar>(index++);
            builder.AddAttribute(index++, "role", "progressbar");
            builder.AddAttribute(index++, "AriaProps", AriaProps);
            builder.AddAttribute(index++, "Value", Value);
            builder.AddAttribute(index++, "MeasureLocation", MeasureLocation);
            builder.CloseComponent();
        }
    }
}
