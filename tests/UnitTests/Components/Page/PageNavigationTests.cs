﻿namespace Blatternfly.UnitTests.Components;

public class PageNavigationTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageNavigation>(parameters => parameters
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-page__main-nav""
>
  test
</div>
");
    }

    [Fact]
    public void WithLimitedWidth()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageNavigation>(parameters => parameters
            .Add(p => p.IsWidthLimited, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-page__main-nav pf-m-limit-width""
>
  <div
    class=""pf-c-page__main-body""
  >
    test
  </div>
</div>
");
    }

    [Fact]
    public void WithTopShadowTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageNavigation>(parameters => parameters
            .Add(p => p.HasShadowTop, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-page__main-nav pf-m-shadow-top""
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
        var cut = ctx.RenderComponent<PageNavigation>(parameters => parameters
            .Add(p => p.HasShadowBottom, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-page__main-nav pf-m-shadow-bottom""
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
        var cut = ctx.RenderComponent<PageNavigation>(parameters => parameters
            .Add(p => p.HasOverflowScroll, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-page__main-nav pf-m-overflow-scroll""
  tabindex=""0""
>
  test
</div>
");
    }
}
