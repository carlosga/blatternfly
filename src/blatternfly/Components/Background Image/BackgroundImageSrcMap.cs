using System.Collections.Generic;

namespace Blatternfly.Components
{
    public sealed class BackgroundImageSrcMap
    {
        public static readonly Dictionary<string, string> c_background_image_BackgroundColor = new()
        {
            { "name", "--pf-c-background-image--BackgroundColor" },
            { "value", "#151515" },
            { "var", "var(--pf-c-background-image--BackgroundColor)" }
        };

        public static readonly Dictionary<string, string> c_background_image_BackgroundImage = new()
        {
            { "name", "--pf-c-background-image--BackgroundImage" },
            { "value", "url(assets/images/pfbg_576.jpg)" },
            { "var", "var(--pf-c-background-image--BackgroundImage)" }
        };

        private static readonly Dictionary<string, string> c_background_image_BackgroundImage_2x = new()
        {
            { "name", "--pf-c-background-image--BackgroundImage-2x" },
            { "value", "url(assets/images/pfbg_576@2x.jpg)" },
            { "var", "var(--pf-c-background-image--BackgroundImage-2x)" }
        };

        public static readonly Dictionary<string, string> c_background_image_BackgroundImage_sm = new()
        {
            { "name", "--pf-c-background-image--BackgroundImage--sm" },
            { "value", "url(assets/images/pfbg_768.jpg)" },
            { "var", "var(--pf-c-background-image--BackgroundImage--sm)" }
        };

        public static readonly Dictionary<string, string> c_background_image_BackgroundImage_sm_2x = new()
        {
            { "name", "--pf-c-background-image--BackgroundImage--sm-2x" },
            { "value", "url(assets/images/pfbg_768@2x.jpg)" },
            { "var", "var(--pf-c-background-image--BackgroundImage--sm-2x)" }
        };

        public static readonly Dictionary<string, string> c_background_image_BackgroundImage_lg = new()
        {
            { "name", "--pf-c-background-image--BackgroundImage--lg" },
            { "value", "url(assets/images/pfbg_2000.jpg)" },
            { "var", "var(--pf-c-background-image--BackgroundImage--lg)" }
        };

        public static readonly Dictionary<string, string> c_background_image_Filter = new()
        {
            { "name", "--pf-c-background-image--Filter" },
            { "value", "url(#patternfly-background-image-filter-overlay0)" },
            { "var", "var(--pf-c-background-image--Filter)"}
        };

        public string xs;
        public string xs2x;
        public string sm;
        public string sm2x;
        public string lg;

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
}
