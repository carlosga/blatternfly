namespace Blatternfly.Components;

/// <summary>Slider step data.</summary>
public sealed class SliderStepObject
{
    /// <summary>Flag to hide the label.</summary>
    public bool IsLabelHidden { get; set; }

    /// <summary>The display label for the step value. This is also used for the aria-valuetext.</summary>
    public string Label { get; set; }

    /// <summary>Value of the step. This value is a percentage of the slider where the tick is drawn.</summary>
    public decimal Value { get; set; }
}
