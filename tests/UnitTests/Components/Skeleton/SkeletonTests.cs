namespace Blatternfly.UnitTests.Components;

public class SkeletonTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Skeleton>();

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-skeleton""
>
<span
  class=""pf-u-screen-reader""
/>
</div>
");
    }

    [Theory]
    [InlineData("25%")]
    [InlineData("33%")]
    [InlineData("50%")]
    [InlineData("66%")]
    [InlineData("75%")]
    public void WidthTest(string width)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Skeleton>(parameters => parameters
            .Add(p => p.Width, width)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-skeleton""
  style=""--pf-c-skeleton--Width: {width};""
>
<span
  class=""pf-u-screen-reader""
/>
</div>
");
    }

    [Theory]
    [InlineData("25%")]
    [InlineData("33%")]
    [InlineData("50%")]
    [InlineData("66%")]
    [InlineData("75%")]
    [InlineData("100%")]
    public void HeightTest(string height)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Skeleton>(parameters => parameters
            .Add(p => p.Height, height)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-skeleton""
  style=""--pf-c-skeleton--Height: {height};""
>
<span
  class=""pf-u-screen-reader""
/>
</div>
");
    }

    [Theory]
    [InlineData(SkeletonFontSize.Small)]
    [InlineData(SkeletonFontSize.Medium)]
    [InlineData(SkeletonFontSize.Large)]
    [InlineData(SkeletonFontSize.ExtraLarge)]
    [InlineData(SkeletonFontSize.ExtraLarge2)]
    [InlineData(SkeletonFontSize.ExtraLarge3)]
    [InlineData(SkeletonFontSize.ExtraLarge4)]
    public void FontSizeTest(SkeletonFontSize fontSize)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var fontSizeClass = fontSize switch
        {
            SkeletonFontSize.Small       => "pf-m-text-sm",
            SkeletonFontSize.Medium      => "pf-m-text-md",
            SkeletonFontSize.Large       => "pf-m-text-lg",
            SkeletonFontSize.ExtraLarge  => "pf-m-text-xl",
            SkeletonFontSize.ExtraLarge2 => "pf-m-text-2xl",
            SkeletonFontSize.ExtraLarge3 => "pf-m-text-3xl",
            SkeletonFontSize.ExtraLarge4 => "pf-m-text-4xl",
            _                            => null
        };

        // Act
        var cut = ctx.RenderComponent<Skeleton>(parameters => parameters
            .Add(p => p.FontSize, fontSize)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-skeleton {fontSizeClass}""
>
<span
  class=""pf-u-screen-reader""
/>
</div>
");
    }

    [Fact]
    public void CircleShapeTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Skeleton>(parameters => parameters
            .Add(p => p.Shape, SkeletonShape.Circle)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-skeleton pf-m-circle""
>
<span
  class=""pf-u-screen-reader""
/>
</div>
");
    }

    [Fact]
    public void SquareShapeTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Skeleton>(parameters => parameters
            .Add(p => p.Shape, SkeletonShape.Square)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-skeleton pf-m-square""
>
<span
  class=""pf-u-screen-reader""
/>
</div>
");
    }
}
