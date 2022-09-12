using System.Globalization;

namespace Blatternfly.Components;

public partial class SliderStep : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Step value.</summary>
    [Parameter] public decimal Value { get; set; }

    /// <summary>Step label.</summary>
    [Parameter] public string Label { get; set; }

    /// <summary>Flag indicating that the tick should be hidden.</summary>
    [Parameter] public bool IsTickHidden { get; set; }

    /// <summary>Flag indicating that the label should be hidden.</summary>
    [Parameter] public bool IsLabelHidden { get; set; }

    /// <summary>Flag indicating the step is active */</summary>
    [Parameter] public bool IsActive { get; set; }

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-c-slider__step--Left", $"{Value.ToString(CultureInfo.InvariantCulture)}%")
        .Build();

    private string CssClass => new CssBuilder("pf-c-slider__step")
        .AddClass("pf-m-active", IsActive)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}