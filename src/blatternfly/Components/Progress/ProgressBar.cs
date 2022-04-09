using System.Collections.Generic;

namespace Blatternfly.Components;

public class ProgressBar : BaseComponent
{
    /// Actual progress value.
    [Parameter] public decimal Value { get; set; }

    [Parameter] public ProgressAriaProps AriaProps { get; set; }

    /// Location of progress value.
    [Parameter] public ProgressMeasureLocation MeasureLocation { get; set; } = ProgressMeasureLocation.Top;

    private string CssClass => new CssBuilder("pf-c-progress__bar")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

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

        builder.OpenElement(0, "div");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddMultipleAttributes(2, ariaProps);
        builder.AddAttribute(3, "class", @CssClass);

        builder.OpenElement(4, "div");
        builder.AddAttribute(5, "class", "pf-c-progress__indicator");
        builder.AddAttribute(6, "style", $"width: {Value:N0}%;");

        builder.OpenElement(7, "span");
        builder.AddAttribute(8, "class", "pf-c-progress__measure");
        if (MeasureLocation is ProgressMeasureLocation.Inside)
        {
            builder.AddContent(9, $"{Value:N0}%");
        }
        builder.CloseElement();

        builder.CloseElement();

        builder.CloseElement();
    }
}
