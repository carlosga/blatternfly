namespace Blatternfly.Components;

public sealed class FloatingPlacement<T> where T: System.Enum
{
    public T Placement { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}
