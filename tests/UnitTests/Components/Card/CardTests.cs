namespace Blatternfly.UnitTests.Components;

public class CardTests
{
    [Fact]
    public void DefaultCardTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Card>();

        // Assert
        cut.MarkupMatches(
@"
<article
  class=""pf-c-card""
/>
");
    }

    [Fact]
    public void CustomClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .AddUnmatched("class", "extra-class")
        );

        // Assert
        cut.MarkupMatches(
@"
<article
  class=""pf-c-card extra-class""
/>
");
    }

    [Fact]
    public void ExtraPropertiesOnRootElementTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var testId = "card";

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .AddUnmatched("data-testid", testId)
        );

        // Assert
        cut.MarkupMatches(
$@"
<article
  data-testid=""{testId}""
  class=""pf-c-card""
/>
");
    }

    [Fact]
    public void CustomComponentTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var component = "section";

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .Add(p => p.Component, "section")
        );

        // Assert
        cut.MarkupMatches(
$@"
<{component}
  class=""pf-c-card""
/>
");
    }

    [Fact]
    public void IsCompactTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .Add(p => p.IsCompact, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<article
  class=""pf-c-card pf-m-compact""
/>
");
    }

    [Fact]
    public void IsSelectableTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .Add(p => p.IsSelectable, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<article
  class=""pf-c-card pf-m-selectable""
  tabindex=""0""
/>
");
    }

    [Fact]
    public void IsSelectableAndSelectedTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .Add(p => p.IsSelectable, true)
            .Add(p => p.IsSelected  , true)
        );

        // Assert
        cut.MarkupMatches(
@"
<article
  class=""pf-c-card pf-m-selectable pf-m-selected""
  tabindex=""0""
/>
");
    }

    [Fact]
    public void IsSelectedTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .Add(p => p.IsSelected, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<article
  class=""pf-c-card""
/>
");
    }

    [Fact]
    public void IsDisabledRaisedTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .Add(p => p.IsDisabledRaised, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<article
  class=""pf-c-card pf-m-non-selectable-raised""
/>
");
    }

    [Fact]
    public void IsSelectableRaisedTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .Add(p => p.IsSelectableRaised, true)
        );

        // Assert
        cut.MarkupMatches(
            @"
<article
  class=""pf-c-card pf-m-selectable-raised""
  tabindex=""0""
/>
");
    }

    [Fact]
    public void IsSelectableRaisedAndIsSelectedTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .Add(p => p.IsSelectableRaised, true)
            .Add(p => p.IsSelected, true)
        );

        // Assert
        cut.MarkupMatches(
            @"
<article
  class=""pf-c-card pf-m-selectable-raised pf-m-selected-raised""
  tabindex=""0""
/>
");
    }

    [Fact]
    public void IsFlatTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .Add(p => p.IsFlat, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<article
  class=""pf-c-card pf-m-flat""
/>
");
    }

    [Fact]
    public void IsExpandedTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .Add(p => p.IsExpanded, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<article
  class=""pf-c-card pf-m-expanded""
/>
");
    }

    [Fact]
    public void IsRoundedTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .Add(p => p.IsRounded, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<article
  class=""pf-c-card pf-m-rounded""
/>
");
    }

    [Fact]
    public void IsLargeTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .Add(p => p.IsLarge, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<article
  class=""pf-c-card pf-m-display-lg""
/>
");
    }
}
