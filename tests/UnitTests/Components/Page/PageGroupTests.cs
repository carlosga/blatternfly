namespace Blatternfly.UnitTests.Components;

public class PageGroupTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageGroup>(parameters => parameters
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-page__main-group""
>
  test
</div>
");
    }

    [Theory]
    [InlineData(StickyPosition.Bottom)]
    [InlineData(StickyPosition.Top)]
    public void StickyTest(StickyPosition position)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var stickyClass = position switch
        {
            StickyPosition.Top    => "pf-m-sticky-top",
            StickyPosition.Bottom => "pf-m-sticky-bottom",
            _                     => null
        };

        // Act
        var cut = ctx.RenderComponent<PageGroup>(parameters => parameters
            .Add(p => p.Sticky, position)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-page__main-group {stickyClass}""
>
  test
</div>
");
    }

    [Fact]
    public void WithTopShadowTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageGroup>(parameters => parameters
            .Add(p => p.HasShadowTop, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-page__main-group pf-m-shadow-top""
>
  test
</div>
");
    }

    [Fact]
    public void WithBottomShadowTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageGroup>(parameters => parameters
            .Add(p => p.HasShadowBottom, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-page__main-group pf-m-shadow-bottom""
>
  test
</div>
");
    }

    [Fact]
    public void WithOverflowScrollTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageGroup>(parameters => parameters
            .Add(p => p.HasOverflowScroll, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-page__main-group pf-m-overflow-scroll""
>
  test
</div>
");
    }
}
