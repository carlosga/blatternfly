namespace Blatternfly.Layouts;

/// <summary>Gallery breakpints.</summary>
public sealed class GalleryBreakpoints
{
    /// <summary>Default.</summary>
    public string Default { get; set; }

    /// <summary>Small.</summary>
    public string Small { get; set; }

    /// <summary>Medium.</summary>
    public string Medium { get; set; }

    /// <summary>Large.</summary>
    public string Large { get; set; }

    /// <summary>Extra large.</summary>
    public string ExtraLarge { get; set; }

    /// <summary>XL2.</summary>
    public string ExtraLarge2 { get; set; }

    internal bool HasDefault     { get => !string.IsNullOrEmpty(Default); }
    internal bool HasSmall       { get => !string.IsNullOrEmpty(Small); }
    internal bool HasMedium      { get => !string.IsNullOrEmpty(Medium); }
    internal bool HasLarge       { get => !string.IsNullOrEmpty(Large); }
    internal bool HasExtraLarge  { get => !string.IsNullOrEmpty(ExtraLarge); }
    internal bool HasExtraLarge2 { get => !string.IsNullOrEmpty(ExtraLarge2); }
}
