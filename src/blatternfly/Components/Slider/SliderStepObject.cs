namespace Blatternfly.Components;

public sealed class SliderStepObject
{
    /// Value of the step. This value is a percentage of the slider where the tick is drawn.
    public decimal Value { get; set; }
    
    /// The display label for the step value. This is also used for the aria-valuetext.
    public string Label { get; set; }
    
    /// Flag to hide the label.
    public bool IsLabelHidden { get; set; }        
}
