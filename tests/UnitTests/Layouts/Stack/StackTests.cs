namespace Blatternfly.UnitTests.Layouts;

public class StackTests
{
    [Fact]
    public void IsFilledTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Stack>(parameters => parameters
            .Add<StackItem>(p => p.ChildContent, itemparams => itemparams
                .Add(p => p.IsFilled, true)
                .AddChildContent("Filled content")
            )
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-l-stack""
>
  <div
    class=""pf-l-stack__item pf-m-fill""
  >
    Filled content
  </div>
</div>
");
    }

    [Fact]
    public void IsFilledDefaultsToFalseTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Stack>(parameters => parameters
            .Add<StackItem>(p => p.ChildContent, itemparams => itemparams
                .AddChildContent("Basic content")
            )
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-l-stack""
>
  <div
    class=""pf-l-stack__item""
  >
    Basic content
  </div>
</div>
");
    }

    [Fact]
    public void GutterTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Stack>(parameters => parameters
            .Add(p => p.HasGutter, true)
            .Add<StackItem>(p => p.ChildContent, itemparams => itemparams
                .AddChildContent("Basic content")
            )
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-l-stack pf-m-gutter""
>
  <div
    class=""pf-l-stack__item""
  >
    Basic content
  </div>
</div>
");
    }
}
    
