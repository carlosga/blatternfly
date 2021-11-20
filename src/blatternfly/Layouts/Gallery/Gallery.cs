using System.Text;

namespace Blatternfly.Layouts;

public class Gallery : LayoutBase
{
    /// Adds space between children.
    [Parameter] public bool HasGutter { get; set; }

    /// Minimum widths at various breakpoints.
    [Parameter] public GalleryBreakpoints MinWidths { get; set; }

    /// Maximum widths at various breakpoints.
    [Parameter] public GalleryBreakpoints MaxWidths { get; set; }

    /// Sets the base component to render. defaults to div.
    [Parameter] public string Component { get; set; } = "div";

    private string CssClass => new CssBuilder("pf-l-gallery")
        .AddClass("pf-m-gutter", HasGutter)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, Component);
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddAttribute(4, "style", BuildStyle());
        builder.AddContent(5, ChildContent);
        builder.CloseElement();
    }

    private string BuildStyle()
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

        return styles.Length > 0 ? styles.ToString() : null;
    }
}
