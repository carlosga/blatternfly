namespace Blatternfly.UnitTests.Components;

public class PanelMainBodyTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<PanelMainBody>(parameters => parameters
            .AddChildContent("Foo")
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-panel__main-body"">Foo</div>");
    }        
}
