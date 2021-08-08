using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Blatternfly.Components
{
    public abstract partial class BaseIcon : ComponentBase
    {
        private const string Role = "img";

        private static string GetSize(IconSize size)
        {
            return size switch
            {
                IconSize.Small      => "1em",
                IconSize.Medium     => "1.5em",
                IconSize.Large      => "2em",
                IconSize.ExtraLarge => "3em",
                _                   => "1em"
            };
        }
        
        private static double GetRawSize(IconSize size)
        {
            return size switch
            {
                IconSize.Small      => 1,
                IconSize.Medium     => 1.5,
                IconSize.Large      => 2,
                IconSize.ExtraLarge => 3,
                _                   => 1
            };
        }        
        
        [CascadingParameter] 
        public string ClassName { get; set; }

        [Parameter(CaptureUnmatchedValues = true)] 
        public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

        [Parameter] public string   Color           { get; set; } = "currentColor";
        [Parameter] public IconSize Size            { get; set; } = IconSize.Small;
        [Parameter] public string   Title           { get; set; }
        [Parameter] public bool     NoVerticalAlign { get; set; }

        protected abstract IconDefinition Definition { get; }

        private bool   HasTitle       { get => !string.IsNullOrEmpty(Title); }
        private string AriaLabelledby { get => HasTitle ? TitleId : null; }
        private string AriaHidden     { get => HasTitle ? null : "true"; }
        private string ViewBox        { get => Definition.ViewBox; }
        private string SvgPath        { get => Definition.SvgPath; }
        private string Transform      { get => Definition.Transform; }
        private string HeightWidth    { get => GetSize(Size); }
        private double BaseAlign      { get => -.125 * GetRawSize(Size); }
        private string Style          { get => NoVerticalAlign ? null : $"vertical-align: {BaseAlign}em"; }
        private string TitleId        { get => HasTitle ? _id : null; }

        private string _id;
        
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (HasTitle && string.IsNullOrEmpty(_id))
            {
                _id = Utils.GetUniqueId("icon-title");
            }
        }
    }
}
