namespace Blatternfly.UnitTests.Components;

public class PageBreadcrumbTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageBreadcrumb>(parameters => parameters
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<section
  class=""pf-c-page__main-breadcrumb""
>
  test
</section>
");
    }

    [Fact]
    public void IsWidthLimitedTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageBreadcrumb>(parameters => parameters
            .Add(p => p.IsWidthLimited, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<section
  class=""pf-c-page__main-breadcrumb pf-m-limit-width""
>
  <div
    class=""pf-c-page__main-body""
  >
    test
  </div>
</section>
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
        var cut = ctx.RenderComponent<PageBreadcrumb>(parameters => parameters
            .Add(p => p.Sticky, position)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
$@"
<section
  class=""pf-c-page__main-breadcrumb {stickyClass}""
>
  test
</section>
");
    }

    [Fact]
    public void WithTopShadowTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageBreadcrumb>(parameters => parameters
            .Add(p => p.HasShadowTop, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<section
  class=""pf-c-page__main-breadcrumb pf-m-shadow-top""
>
  test
</section>
");
    }

    [Fact]
    public void WithBottomShadowTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageBreadcrumb>(parameters => parameters
            .Add(p => p.HasShadowBottom, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<section
  class=""pf-c-page__main-breadcrumb pf-m-shadow-bottom""
>
  test
</section>
");
    }

    [Fact]
    public void WithOverflowScrollTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageBreadcrumb>(parameters => parameters
            .Add(p => p.HasOverflowScroll, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<section
  class=""pf-c-page__main-breadcrumb pf-m-overflow-scroll""
>
  test
</section>
");
    }
}
