using System.Text;

namespace Blatternfly.Layouts;

public partial class GridItem : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>the number of columns the grid item spans. Value should be a number 1-12.</summary>
    [Parameter] public int? Span { get; set; }

    /// <summary>the number of rows the grid item spans. Value should be a number 1-12.</summary>
    [Parameter] public int? RowSpan { get; set; }

    /// <summary>the number of columns a grid item is offset */</summary>
    [Parameter] public int? Offset { get; set; }

    /// <summary>the number of columns the grid item spans on small device. Value should be a number 1-12.</summary>
    [Parameter] public int? Small { get; set; }

    /// <summary>the number of rows the grid item spans on medium device. Value should be a number 1-12.</summary>
    [Parameter] public int? SmallRowSpan { get; set; }

    /// <summary>the number of columns the grid item is offset on small device. Value should be a number 1-12.</summary>
    [Parameter] public int? SmallOffset { get; set; }

    /// <summary>the number of columns the grid item spans on medium device. Value should be a number 1-12.</summary>
    [Parameter] public int? Medium { get; set; }

    /// <summary>the number of rows the grid item spans on medium device. Value should be a number 1-12.</summary>
    [Parameter] public int? MediumRowSpan { get; set; }

    /// <summary>the number of columns the grid item is offset on medium device. Value should be a number 1-12.</summary>
    [Parameter] public int? MediumOffset { get; set; }

    /// <summary>the number of columns the grid item spans on large device. Value should be a number 1-12.</summary>
    [Parameter] public int? Large { get; set; }

    /// <summary>the number of rows the grid item spans on large device. Value should be a number 1-12.</summary>
    [Parameter] public int? LargeRowSpan { get; set; }

    /// <summary>the number of columns the grid item is offset on large device. Value should be a number 1-12.</summary>
    [Parameter] public int? LargeOffset { get; set; }

    /// <summary>the number of columns the grid item spans on xLarge device. Value should be a number 1-12.</summary>
    [Parameter] public int? ExtraLarge { get; set; }

    /// <summary>the number of rows the grid item spans on large device. Value should be a number 1-12.</summary>
    [Parameter] public int? ExtraLargeRowSpan { get; set; }

    /// <summary>the number of columns the grid item is offset on xLarge device. Value should be a number 1-12.</summary>
    [Parameter] public int? ExtraLargeOffset { get; set; }

    /// <summary>the number of columns the grid item spans on 2xLarge device. Value should be a number 1-12.</summary>
    [Parameter] public int? ExtraLarge2 { get; set; }

    /// <summary>the number of rows the grid item spans on 2xLarge device. Value should be a number 1-12.</summary>
    [Parameter] public int? ExtraLarge2RowSpan { get; set; }

    /// <summary>the number of columns the grid item is offset on 2xLarge device. Value should be a number 1-12.</summary>
    [Parameter] public int? ExtraLarge2Offset { get; set; }

    /// <summary>Modifies the flex layout element order property.</summary>
    [Parameter] public GridOrderModifiers Order { get; set; }

    /// <summary>Sets the base component to render. defaults to div.</summary>
    [Parameter] public string Component { get; set; } = "div";

    private string CssStyle => new StyleBuilder()
        .AddStyle(Order?.CssStyle)
        .AddStyleFromAttributes(AdditionalAttributes)
        .Build();

    private string CssClass => new CssBuilder("pf-l-grid__item")
        .AddClass(ComputeClasses(null                   , Span       , RowSpan           , Offset))
        .AddClass(ComputeClasses(DeviceSizes.Small      , Small      , SmallRowSpan      , SmallOffset))
        .AddClass(ComputeClasses(DeviceSizes.Medium     , Medium     , MediumRowSpan     , MediumOffset))
        .AddClass(ComputeClasses(DeviceSizes.Large      , Large      , LargeRowSpan      , LargeOffset))
        .AddClass(ComputeClasses(DeviceSizes.ExtraLarge , ExtraLarge , ExtraLargeRowSpan , ExtraLargeOffset))
        .AddClass(ComputeClasses(DeviceSizes.ExtraLarge2, ExtraLarge2, ExtraLarge2RowSpan, ExtraLarge2Offset))
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void OnParametersSet()
    {
        ValidateRange(nameof(Span), Span);
        ValidateRange(nameof(RowSpan), RowSpan);
        ValidateRange(nameof(Offset), Offset);

        ValidateRange(nameof(Small), Small);
        ValidateRange(nameof(SmallRowSpan), SmallRowSpan);
        ValidateRange(nameof(SmallOffset), SmallOffset);

        ValidateRange(nameof(Medium), Medium);
        ValidateRange(nameof(MediumRowSpan), MediumRowSpan);
        ValidateRange(nameof(MediumOffset), MediumOffset);

        ValidateRange(nameof(Large), Large);
        ValidateRange(nameof(LargeRowSpan), LargeRowSpan);
        ValidateRange(nameof(LargeOffset), LargeOffset);

        ValidateRange(nameof(ExtraLarge), ExtraLarge);
        ValidateRange(nameof(ExtraLargeRowSpan), ExtraLargeRowSpan);
        ValidateRange(nameof(ExtraLargeOffset), ExtraLargeOffset);

        ValidateRange(nameof(ExtraLarge2), ExtraLarge2);
        ValidateRange(nameof(ExtraLarge2RowSpan), ExtraLarge2RowSpan);
        ValidateRange(nameof(ExtraLarge2Offset), ExtraLarge2Offset);

        base.OnParametersSet();
    }

    private static string ComputeClasses(DeviceSizes? size, int? span, int? rowSpan, int? offset)
    {
        var builder = new StringBuilder();

        if (span.HasValue)
        {
            builder.Append($"pf-m-{span.Value}-col");
            AppendSize(builder, size);
        }

        if (rowSpan.HasValue)
        {
            builder.Append($"pf-m-{rowSpan.Value}-row");
            AppendSize(builder, size);
        }

        if (offset.HasValue)
        {
            builder.Append($"pf-m-offset-{offset.Value}-col");
            AppendSize(builder, size);
        }

        return builder.ToString();
    }

    private static void AppendSize(StringBuilder builder, DeviceSizes? size)
    {
        switch (size)
        {
            case null:
                builder.Append(' ');
                break;
            case DeviceSizes.Small:
                builder.Append("-on-sm ");
                break;
            case DeviceSizes.Medium:
                builder.Append("-on-md ");
                break;
            case DeviceSizes.Large:
                builder.Append("-on-lg ");
                break;
            case DeviceSizes.ExtraLarge:
                builder.Append("-on-xl ");
                break;
            case DeviceSizes.ExtraLarge2:
                builder.Append("-on-2xl ");
                break;
        }
    }

    private static void ValidateRange(string name, int? value)
    {
        if (!value.HasValue)
        {
            return;
        }

        if (value.Value < 0 || value.Value > 12)
        {
            throw new ArgumentOutOfRangeException(name);
        }
    }
}
