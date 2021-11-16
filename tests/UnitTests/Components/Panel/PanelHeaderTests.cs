namespace Blatternfly.UnitTests.Components;

public class PanelHeaderTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<PanelHeader>(parameters => parameters
            .AddChildContent("Foo")
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-panel__header"">Foo</div>");
    }        
}
