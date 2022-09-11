namespace Blatternfly.Components;

/// <summary>Progress bar aria properties</summary>
public sealed class ProgressAriaProps
{
    /// <summary>Aria label</summary>
    public string Label { get; set; }

    /// <summary>Aria labelledby</summary>
    public string LabelledBy { get; set; }

    /// <summary>Aria value min</summary>
    public decimal? Min { get; set; }

    /// <summary>Aria value now</summary>
    public decimal? Now { get; set; }

    /// <summary>Aria value max</summary>
    public decimal? Max { get; set; }

    /// <summary>Aria value text</summary>
    public string Text { get; set; }
}
