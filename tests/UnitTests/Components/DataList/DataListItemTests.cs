namespace Blatternfly.UnitTests.Components;

public class DataListItemTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<DataListItem>(parameters => parameters
            .Add(p => p.AriaLabelledBy, "item-1")
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(@"<li class=""pf-c-data-list__item"" aria-labelledby=""item-1"">test</li>");
    }
    
    [Fact]
    public void IsExpandedTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<DataListItem>(parameters => parameters
            .Add(p => p.AriaLabelledBy, "item-1")
            .Add(p => p.IsExpanded, true)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(@"<li class=""pf-c-data-list__item pf-m-expanded"" aria-labelledby=""item-1"">test</li>");
    }
    
    [Fact]
    public void WithAdditionalCssClassTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<DataListItem>(parameters => parameters
            .AddUnmatched("class", "data-list-item-custom")
            .Add(p => p.AriaLabelledBy, "item-1")
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(@"<li class=""pf-c-data-list__item data-list-item-custom"" aria-labelledby=""item-1"">test</li>");
    }
}
