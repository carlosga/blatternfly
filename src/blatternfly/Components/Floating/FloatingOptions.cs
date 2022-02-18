namespace Blatternfly.Components;

public sealed class FloatingOptions
{
    public TooltipPosition Placement { get; set; }

    public int Distance { get; set; }

    public bool EnableFlip { get; set; }

    public TooltipPosition[] FallbackPlacements { get; set; }
}
