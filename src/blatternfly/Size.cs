namespace Blatternfly;

/// <summary>Element size (used on javascript interop.)</summary>
public sealed class Size<T>
{
    /// <summary>Element height.</summary>
    public T Height { get; set; }

    /// <summary>Element width.</summary>
    public T Width { get; set; }

    /// <summary>Initializes a new instance of the Size class.</summary>
    public Size()
    {
    }

    /// <summary>Initializes a new instance of the Size class.</summary>
    /// <param name="width">Element width.</param>
    /// <param name="height">Element height.</param>
    public Size(T width, T height)
    {
        Width  = width;
        Height = height;
    }
}