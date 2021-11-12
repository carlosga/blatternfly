namespace Blatternfly.Components;

public sealed class ProgressAriaProps
{
    public string Label { get; set; }
    public string LabelledBy { get; set; }
    public decimal? Min { get; set; }
    public decimal? Now { get; set; }
    public decimal? Max { get; set; }
    public string Text { get; set; }
}
