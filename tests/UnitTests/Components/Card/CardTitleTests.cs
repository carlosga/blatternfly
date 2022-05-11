namespace Blatternfly.UnitTests.Components;

public class CardTitleTests
{
    [Fact]
    public void DefaultCardTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<CardTitle>(parameters => parameters
            .AddChildContent("text")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-card__title""
>
  text
</div>
");
    }

    [Fact]
    public void WithCustomCssClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<CardTitle>(parameters => parameters
            .AddUnmatched("class", "extra-class")
            .AddChildContent("text")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-card__title extra-class""
>
  text
</div>
");
    }

    [Fact]
    public void WithAdditionalPropertiesTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<CardTitle>(parameters => parameters
            .AddUnmatched("data-testid", "card-header")
            .AddChildContent("text")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-card__title""
  data-testid=""card-header""
>
  text
</div>
");
    }
}
