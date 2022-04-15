namespace Blatternfly.Components;

public sealed class SliderInputValueChangedEventArgs : EventArgs
{
    public decimal Value { get; set; }
    public decimal? InputValue { get; set; }
}
