namespace Blatternfly.Components;

public sealed class FloatingOptions<T> where T: System.Enum
{
    public T Placement { get; set; }

    public int Distance { get; set; }

    public bool EnableFlip { get; set; }

    public T[] FallbackPlacements { get; set; }
}
