namespace Blatternfly.UnitTests.Components;

public class PanelTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Panel>(parameters => parameters
            .AddChildContent("Foo")
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-panel"">Foo</div>");
    }

    [Fact]
    public void RaisedTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Panel>(parameters => parameters
            .Add(p => p.Variant, PanelVariant.Raised)
            .AddChildContent("Foo")
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-panel pf-m-raised"">Foo</div>");
    }

    [Fact]
    public void BorderedTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Panel>(parameters => parameters
            .Add(p => p.Variant, PanelVariant.Bordered)
            .AddChildContent("Foo")
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-panel pf-m-bordered"">Foo</div>");
    }

    [Fact]
    public void IsScrollableTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Panel>(parameters => parameters
            .Add(p => p.IsScrollable, true)
            .AddChildContent("Foo")
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-panel pf-m-scrollable"">Foo</div>");
    }
}
