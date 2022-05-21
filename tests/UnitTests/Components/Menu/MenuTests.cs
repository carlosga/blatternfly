namespace Blatternfly.UnitTests.Components;

public class MenuTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Menu>(parameters => parameters
            .Add(p => p.ActiveItemId, "0")
            .AddChildContent("content")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-menu""
>
  content
</div>
");
    }

    [Fact]
    public void IsPlainTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Menu>(parameters => parameters
            .Add(p => p.ActiveItemId, "0")
            .Add(p => p.IsPlain, true)
            .AddChildContent("content")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-menu pf-m-plain""
>
  content
</div>
");
    }

    [Fact]
    public void IsScrollableTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Menu>(parameters => parameters
            .Add(p => p.ActiveItemId, "0")
            .Add(p => p.IsScrollable, true)
            .AddChildContent("content")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-menu pf-m-scrollable""
>
  content
</div>
");
    }

    [Fact]
    public void IsNavFlyoutTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Menu>(parameters => parameters
            .Add(p => p.ActiveItemId, "0")
            .Add(p => p.IsNavFlyout, true)
            .AddChildContent("content")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-menu pf-m-nav""
>
  content
</div>
");
    }
}
