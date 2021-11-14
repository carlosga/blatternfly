namespace Blatternfly.UnitTests.Components;

public class CardExpandableContentTests
{
    [Fact]
    public void DefaultCardTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .Add(p => p.IsExpanded, true)
            .Add<CardExpandableContent>(p => p.ChildContent)
        );

        // Assert
        cut.MarkupMatches(
@"
<article
  class=""pf-c-card pf-m-expanded""
>
  <div
    class=""pf-c-card__expandable-content""
  />
</article>
");
    }
}
