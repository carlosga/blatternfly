namespace Blatternfly.UnitTests.Components;

public class PanelFooterTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<PanelFooter>(parameters => parameters
            .AddChildContent("Foo")
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-panel__footer"">Foo</div>");
    }        
}
