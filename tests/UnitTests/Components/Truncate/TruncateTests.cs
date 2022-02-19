namespace Blatternfly.UnitTests.Components;

public class TruncateTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Truncate>(properties => properties
            .Add(p => p.Content, "Vestibulum interdum risus et enim faucibus, sit amet molestie est accumsan.")
        );

        // Assert
        cut.MarkupMatches(
@"
<span
  class=""pf-c-truncate""
  id=""pf-c-truncate-1""
>
  <span
    class=""pf-c-truncate__start""
  >
    Vestibulum interdum risus et enim faucibus, sit amet molestie est accumsan.
  </span>
</span>
");
    }

    [Fact]
    public void StartTruncationTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Truncate>(properties => properties
            .Add(p => p.Content, "Vestibulum interdum risus et enim faucibus, sit amet molestie est accumsan.")
            .Add(p => p.Position, TruncatePosition.Start)
        );

        // Assert
        cut.MarkupMatches(
@"
<span
  class=""pf-c-truncate""
  id=""pf-c-truncate-1""
>
  <span
    class=""pf-c-truncate__end""
  >
    Vestibulum interdum risus et enim faucibus, sit amet molestie est accumsan.&#8206;
  </span>
</span>
");
    }

    [Fact]
    public void MiddleTruncationTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Truncate>(properties => properties
            .Add(p => p.Content, "Vestibulum interdum risus et enim faucibus, sit amet molestie est accumsan.")
            .Add(p => p.Position, TruncatePosition.Middle)
        );

        // Assert
        cut.MarkupMatches(
@"
<span
  class=""pf-c-truncate""
  id=""pf-c-truncate-1""
>
  <span
    class=""pf-c-truncate__start""
  >
    Vestibulum interdum risus et enim faucibus, sit amet molestie est ac
  </span>
  <span
    class=""pf-c-truncate__end""
  >
    cumsan.
  </span>
</span>
");
    }
}
