namespace Blatternfly.UnitTests.Components;

public class CardFooterTests
{
    [Fact]
    public void DefaultCardTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<CardFooter>();

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-card__footer""
/>
");
    }

    [Fact]
    public void CustomClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<CardFooter>(parameters => parameters
            .AddUnmatched("class", "extra-class")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-card__footer extra-class""
/>
");
    }

    [Fact]
    public void ExtraPropertiesOnRootElementTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var testId = "card-footer";

        // Act
        var cut = ctx.RenderComponent<CardFooter>(parameters => parameters
            .AddUnmatched("data-testid", testId)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  data-testid=""{testId}""
  class=""pf-c-card__footer""
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
        var cut = ctx.RenderComponent<CardFooter>(parameters => parameters
            .Add(p => p.Component, "section")
        );

        // Assert
        cut.MarkupMatches(
$@"
<{component}
  class=""pf-c-card__footer""
/>
");
    }
}
