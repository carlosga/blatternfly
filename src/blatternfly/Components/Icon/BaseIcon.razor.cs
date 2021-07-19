using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Blatternfly.Components
{
    public abstract partial class BaseIcon : ComponentBase
    {
        [CascadingParameter] public string ClassName { get; set; }

        [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

        [Parameter] public string Id { get; set; }
        [Parameter] public string Color { get; set; } = "currentColor";
        [Parameter] public IconSize Size { get; set; } = IconSize.sm;
        [Parameter] public string Title { get; set; }
        [Parameter] public bool NoVerticalAlign { get; set; }

        public IconDefinition Definition { get; private set; }
        public bool HasTitle => !string.IsNullOrEmpty(Title);
        public string Role => "img";
        public string AriaLabelledby => (HasTitle) ? Id : null;
        public string AriaHidden => ((HasTitle) ? null : "true");
        public string ViewBox => Definition.ViewBox;
        public string SvgPath => Definition.SvgPath;
        public string Transform => Definition.Transform;
        public string HeightWidth => GetSize(Size);
        public double BaseAlign => -.125 * double.Parse(HeightWidth.Replace("em", string.Empty));
        public string Style => NoVerticalAlign ? null : $"vertical-align: {BaseAlign}em";

        public static string GetSize(IconSize size) {
            switch (size) {
                case IconSize.md:
                    return "1.5em";

                case IconSize.lg:
                    return "2em";

                case IconSize.xl:
                    return "3em";

                case IconSize.sm:
                default:
                    return "1em";
            }
        }

        public BaseIcon(IconDefinition definition)
        {
            Definition = definition;
        }
    }
}
