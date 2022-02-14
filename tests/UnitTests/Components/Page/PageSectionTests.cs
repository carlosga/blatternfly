namespace Blatternfly.UnitTests.Components;

public class PageSectionTests
{
    [Fact]
    public void WithNoPaddingTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var padding = new Padding { Default = Paddings.NoPadding };

        // Act
        var cut = ctx.RenderComponent<PageSection>(parameters => parameters
            .Add(p => p.Padding, padding)
        );

        // Assert
        cut.MarkupMatches(
@"
<section
  class=""pf-c-page__main-section pf-m-no-padding""
/>
");
    }

    [Fact]
    public void WithLimitedWidthTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageSection>(parameters => parameters
            .Add(p => p.IsWidthLimited, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<section
  class=""pf-c-page__main-section pf-m-limit-width""
>
  <div
    class=""pf-c-page__main-body""
  />
</section>
");
    }

    [Fact]
    public void IsCenterAlignedTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageSection>(parameters => parameters
            .Add(p => p.IsWidthLimited, true)
            .Add(p => p.IsCenterAligned, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<section
  class=""pf-c-page__main-section pf-m-limit-width pf-m-align-center""
>
  <div
    class=""pf-c-page__main-body""
  />
</section>
");
    }

    [Theory]
    [InlineData(PageSectionType.Default)]
    [InlineData(PageSectionType.Nav)]
    [InlineData(PageSectionType.SubNav)]
    [InlineData(PageSectionType.Breadcrumb)]
    [InlineData(PageSectionType.Tabs)]
    [InlineData(PageSectionType.Wizard)]
    public void SectionTypeTest(PageSectionType type)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var sectionTypeClass = type switch
        {
            PageSectionType.Default    => "pf-c-page__main-section",
            PageSectionType.Nav        => "pf-c-page__main-nav",
            PageSectionType.SubNav     => "pf-c-page__main-subnav",
            PageSectionType.Breadcrumb => "pf-c-page__main-breadcrumb",
            PageSectionType.Tabs       => "pf-c-page__main-tabs",
            PageSectionType.Wizard     => "pf-c-page__main-wizard",
            _                          => null
        };

        // Act
        var cut = ctx.RenderComponent<PageSection>(parameters => parameters
            .Add(p => p.Type, type)
        );

        // Assert
        cut.MarkupMatches(
$@"
<section
  class=""{sectionTypeClass}""
/>
");
    }

    [Fact]
    public void NoFilledTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageSection>(parameters => parameters
            .Add(p => p.IsFilled, false)
        );

        // Assert
        cut.MarkupMatches(
@"
<section
  class=""pf-c-page__main-section pf-m-no-fill""
/>
");
    }

    [Fact]
    public void FilledTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PageSection>(parameters => parameters
            .Add(p => p.IsFilled, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<section
  class=""pf-c-page__main-section pf-m-fill""
/>
");
    }

    [Fact]
    public void IsFilledAndNoPaddingTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var padding = new Padding { Default = Paddings.NoPadding };

        // Act
        var cut = ctx.RenderComponent<PageSection>(parameters => parameters
            .Add(p => p.IsFilled, true)
            .Add(p => p.Padding, padding)
        );

        // Assert
        cut.MarkupMatches(
@"
<section
  class=""pf-c-page__main-section pf-m-no-padding pf-m-fill""
/>
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
        var cut = ctx.RenderComponent<PageSection>(parameters => parameters
            .Add(p => p.Sticky, position)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
$@"
<section
  class=""pf-c-page__main-section {stickyClass}""
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
        var cut = ctx.RenderComponent<PageSection>(parameters => parameters
            .Add(p => p.HasShadowTop, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<section
  class=""pf-c-page__main-section pf-m-shadow-top""
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
        var cut = ctx.RenderComponent<PageSection>(parameters => parameters
            .Add(p => p.HasShadowBottom, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<section
  class=""pf-c-page__main-section pf-m-shadow-bottom""
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
        var cut = ctx.RenderComponent<PageSection>(parameters => parameters
            .Add(p => p.HasOverflowScroll, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<section
  class=""pf-c-page__main-section pf-m-overflow-scroll""
>
  test
</section>
");
    }
}
