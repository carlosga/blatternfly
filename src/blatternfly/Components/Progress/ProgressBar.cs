using System.Collections.Generic;

namespace Blatternfly.Components;

public class ProgressBar : BaseComponent
{
    /// Actual progress value.
    [Parameter] public decimal Value { get; set; }

    [Parameter] public ProgressAriaProps AriaProps { get; set; }

    /// Location of progress value.
    [Parameter] public ProgressMeasureLocation MeasureLocation { get; set; } = ProgressMeasureLocation.Top;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var ariaProps = new Dictionary<string, object>
        {
            { "aria-label"     , AriaProps.Label }
          , { "aria-labelledby", AriaProps?.LabelledBy }
          , { "aria-valuemin"  , AriaProps?.Min?.ToString("N0") ?? "0" }
          , { "aria-valuenow"  , AriaProps?.Now?.ToString("N0") ?? "0" }
          , { "aria-valuemax"  , AriaProps?.Max?.ToString("N0") ?? "0" }
          , { "aria-valuetext" , AriaProps?.Text }
        };

        builder.OpenElement(1, "div");
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddMultipleAttributes(3, ariaProps);
        builder.AddAttribute(4, "class", "pf-c-progress__bar");

        builder.OpenElement(5, "div");
        builder.AddAttribute(6, "class", "pf-c-progress__indicator");
        builder.AddAttribute(7, "style", $"width: {Value:N0}%;");

        builder.OpenElement(8, "span");
        builder.AddAttribute(9, "class", "pf-c-progress__measure");
        if (MeasureLocation == ProgressMeasureLocation.Inside)
        {
            builder.AddContent(10, $"{Value:N0}%");
        }
        builder.CloseElement();

        builder.CloseElement();

        builder.CloseElement();
    }
}
