namespace Blatternfly.Components;

public partial class ProgressBar : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Actual progress value.</summary>
    [Parameter] public decimal Value { get; set; }

    [Parameter] public ProgressAriaProps AriaProps { get; set; }

    /// <summary>Location of progress value.</summary>
    [Parameter] public ProgressMeasureLocation MeasureLocation { get; set; } = ProgressMeasureLocation.Top;

    private string CssClass => new CssBuilder("pf-c-progress__bar")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string CssStyle    => $"width: {Value:N0}%;";
    private string StringValue => $"{Value:N0}%";
    private string AriaValueMin { get => AriaProps?.Min?.ToString("N0"); }
    private string AriaValueNow { get => AriaProps?.Now?.ToString("N0"); }
    private string AriaValueMax { get => AriaProps?.Max?.ToString("N0"); }
}
