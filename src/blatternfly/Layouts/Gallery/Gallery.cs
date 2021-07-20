using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class Gallery : LayoutBase
    {
        /// Adds space between children.
        [Parameter] public bool HasGutter { get; set; }

        /// Minimum widths at various breakpoints.
        [Parameter] public GalleryBreakpoints MinWidths { get; set; }

        /// Maximum widths at various breakpoints.
        [Parameter] public GalleryBreakpoints MaxWidths { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index       = 0;
            var gutterClass = HasGutter ? "pf-m-gutter" : string.Empty;
            var styles = BuildStyle();

            builder.OpenElement(index++, "div");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-l-gallery {gutterClass}");
            if (styles.Length > 0)
            {
                builder.AddAttribute(index++, "style", styles.ToString());
            }
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }

        private StringBuilder BuildStyle()
        {
            var styles = new StringBuilder();

            if (MinWidths is not null)
            {
                if (MinWidths.HasDefault)
                {
                    styles.AppendFormat("--pf-l-gallery--GridTemplateColumns--min:{0};", MinWidths.Default);
                }

                if (MinWidths.HasSmall)
                {
                    styles.AppendFormat("--pf-l-gallery--GridTemplateColumns--min-on-sm:{0};", MinWidths.Small);
                }

                if (MinWidths.HasMedium)
                {
                    styles.AppendFormat("--pf-l-gallery--GridTemplateColumns--min-on-md:{0};", MinWidths.Medium);
                }

                if (MinWidths.HasLarge)
                {
                    styles.AppendFormat("--pf-l-gallery--GridTemplateColumns--min-on-lg:{0};", MinWidths.Large);
                }

                if (MinWidths.HasExtraLarge)
                {
                    styles.AppendFormat("--pf-l-gallery--GridTemplateColumns--min-on-xl:{0};", MinWidths.ExtraLarge);
                }

                if (MinWidths.HasExtraLarge2)
                {
                    styles.AppendFormat("--pf-l-gallery--GridTemplateColumns--min-on-2xl:{0};", MinWidths.ExtraLarge2);
                }
            }

            if (MaxWidths is not null)
            {
                if (MaxWidths.HasDefault)
                {
                    styles.AppendFormat("--pf-l-gallery--GridTemplateColumns--max:{0};", MaxWidths.Default);
                }

                if (MaxWidths.HasSmall)
                {
                    styles.AppendFormat("--pf-l-gallery--GridTemplateColumns--max-on-sm:{0};", MaxWidths.Small);
                }

                if (MaxWidths.HasMedium)
                {
                    styles.AppendFormat("--pf-l-gallery--GridTemplateColumns--max-on-md:{0};", MaxWidths.Medium);
                }

                if (MaxWidths.HasLarge)
                {
                    styles.AppendFormat("--pf-l-gallery--GridTemplateColumns--max-on-lg:{0};", MaxWidths.Large);
                }

                if (MaxWidths.HasExtraLarge)
                {
                    styles.AppendFormat("--pf-l-gallery--GridTemplateColumns--max-on-xl:{0};", MaxWidths.ExtraLarge);
                }

                if (MaxWidths.HasExtraLarge2)
                {
                    styles.AppendFormat("--pf-l-gallery--GridTemplateColumns--max-on-2xl:{0};", MaxWidths.ExtraLarge2);
                }
            }

            return styles;
        }
    }
}
