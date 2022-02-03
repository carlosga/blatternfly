namespace Blatternfly.UnitTests.Components;

public class PanelMainTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PanelMain>(parameters => parameters
            .AddChildContent("Foo")
        );

        // Assert
        cut.MarkupMatches(@"<div class=""pf-c-panel__main"">Foo</div>");
    }

    [Fact]
    public void WithMaximumHeightTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PanelMain>(parameters => parameters
            .Add(p => p.MaxHeight, "80px")
            .AddChildContent("Foo")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-panel__main""
  style=""--pf-c-panel__main--MaxHeight: 80px""
>
  Foo
</div>
");
    }
}
