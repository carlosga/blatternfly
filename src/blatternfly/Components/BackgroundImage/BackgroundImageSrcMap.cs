namespace Blatternfly.Components;

public sealed class BackgroundImageSrcMap
{
    internal static readonly Dictionary<string, string> c_background_image_BackgroundImage = new()
    {
        { "name", "--pf-c-background-image--BackgroundImage" },
        { "value", "" },
        { "var", "var(--pf-c-background-image--BackgroundImage)" }
    };

    internal static readonly Dictionary<string, string> c_background_image_BackgroundImage_2x = new()
    {
        { "name", "--pf-c-background-image--BackgroundImage-2x" },
        { "value", "" },
        { "var", "var(--pf-c-background-image--BackgroundImage-2x)" }
    };

    internal static readonly Dictionary<string, string> c_background_image_BackgroundImage_sm = new()
    {
        { "name", "--pf-c-background-image--BackgroundImage--sm" },
        { "value", "" },
        { "var", "var(--pf-c-background-image--BackgroundImage--sm)" }
    };

    internal static readonly Dictionary<string, string> c_background_image_BackgroundImage_sm_2x = new()
    {
        { "name", "--pf-c-background-image--BackgroundImage--sm-2x" },
        { "value", "" },
        { "var", "var(--pf-c-background-image--BackgroundImage--sm-2x)" }
    };

    internal static readonly Dictionary<string, string> c_background_image_BackgroundImage_lg = new()
    {
        { "name", "--pf-c-background-image--BackgroundImage--lg" },
        { "value", "" },
        { "var", "var(--pf-c-background-image--BackgroundImage--lg)" }
    };

    internal static readonly Dictionary<string, string> c_background_image_Filter = new()
    {
        { "name", "--pf-c-background-image--Filter" },
        { "value", "url(#patternfly-background-image-filter-overlay0)" },
        { "var", "var(--pf-c-background-image--Filter)"}
    };

    public string xs { get; set; }
    public string xs2x { get; set; }
    public string sm { get; set; }
    public string sm2x { get; set; }
    public string lg { get; set; }

    public bool IsNotEmpty
    {
        get => !string.IsNullOrEmpty(xs)
            || !string.IsNullOrEmpty(xs2x)
            || !string.IsNullOrEmpty(sm)
            || !string.IsNullOrEmpty(sm2x)
            || !string.IsNullOrEmpty(lg);
    }

    public static Dictionary<string, string> C_background_image_BackgroundImage_2x => c_background_image_BackgroundImage_2x;
}
