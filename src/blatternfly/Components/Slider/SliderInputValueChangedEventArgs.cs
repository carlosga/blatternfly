namespace Blatternfly.Components;

/// <summary>Slider input value changed event args.</summary>
public sealed class SliderInputValueChangedEventArgs : EventArgs
{
    /// <summary>Slider value.</summary>
    public decimal Value { get; set; }

    /// <summary>Slider input value</summary>
    public decimal? InputValue { get; set; }
}
