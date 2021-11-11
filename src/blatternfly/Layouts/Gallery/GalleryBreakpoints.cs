namespace Blatternfly.Layouts;

public sealed class GalleryBreakpoints
{
    public string Default { get; set; }
    public string Small { get; set; }
    public string Medium { get; set; }
    public string Large { get; set; }
    public string ExtraLarge { get; set; }
    public string ExtraLarge2 { get; set; }

    internal bool HasDefault     { get => !string.IsNullOrEmpty(Default); }
    internal bool HasSmall       { get => !string.IsNullOrEmpty(Small); }
    internal bool HasMedium      { get => !string.IsNullOrEmpty(Medium); }
    internal bool HasLarge       { get => !string.IsNullOrEmpty(Large); }
    internal bool HasExtraLarge  { get => !string.IsNullOrEmpty(ExtraLarge); }
    internal bool HasExtraLarge2 { get => !string.IsNullOrEmpty(ExtraLarge2); }
}
