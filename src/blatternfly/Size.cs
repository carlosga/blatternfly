namespace Blatternfly;

/// Element size (used on javascript interop.)
public sealed class Size<T>
{
    /// Element height.
    public T Height { get; set; }

    /// Element width.
    public T Width { get; set; }

    /// Initializes a new instance of the <see cref="Size" /> class
    public Size()
    {
    }

    /// Initializes a new instance of the <see cref="Size" /> class
    /// <param name="width">Element width.</param>
    /// <param name="height">Element height.</param>
    public Size(T width, T height)
    {
        Width  = width;
        Height = height;
    }
}
