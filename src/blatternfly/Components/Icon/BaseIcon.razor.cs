using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Blatternfly.Components
{
    public abstract partial class BaseIcon : ComponentBase
    {
        protected const string Role = "img";

        protected static string GetSize(IconSize size)
        {
            return size switch
            {
                IconSize.sm => "1em",
                IconSize.md => "1.5em",
                IconSize.lg => "2em",
                IconSize.xl => "3em",
                _           => "1em"
            };
        }
        
        protected static double GetRawSize(IconSize size)
        {
            return size switch
            {
                IconSize.sm => 1,
                IconSize.md => 1.5,
                IconSize.lg => 2,
                IconSize.xl => 3,
                _           => 1
            };
        }        
        
        [CascadingParameter] public string ClassName { get; set; }

        [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

        [Parameter] public string Color { get; set; } = "currentColor";
        [Parameter] public IconSize Size { get; set; } = IconSize.sm;
        [Parameter] public string Title { get; set; }
        [Parameter] public bool NoVerticalAlign { get; set; }

        protected IconDefinition Definition { get; }

        protected bool HasTitle { get => !string.IsNullOrEmpty(Title); }
        protected string AriaLabelledby { get => HasTitle ? TitleId : null; }
        protected string AriaHidden { get => HasTitle ? null : "true"; }

        protected string ViewBox { get => Definition.ViewBox; }
        protected string SvgPath { get => Definition.SvgPath; }
        protected string Transform { get => Definition.Transform; }
        protected string HeightWidth { get => GetSize(Size); }
        protected double BaseAlign { get => -.125 * GetRawSize(Size); }
        protected string Style { get => NoVerticalAlign ? null : $"vertical-align: {BaseAlign}em"; }
        protected string TitleId { get => HasTitle ? _id : null; }

        private string _id;
        
        protected BaseIcon(IconDefinition definition)
        {
            Definition = definition;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (HasTitle)
            {
                _id = Utils.GetUniqueId("icon-title");
            }
        }
    }
}
