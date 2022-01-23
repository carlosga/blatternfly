namespace Blatternfly;

public sealed class Size<T>
{
    public T Height { get; set; }
    public T Width { get; set; }

    public Size()
    {
    }

    public Size(T width, T height)
    {
        Width  = width;
        Height = height;
    }
}
