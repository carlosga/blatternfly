namespace Blatternfly.UnitTests.Components;

public class CodeBlockCodeTests
{
    [Fact(Skip="bunit")]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<CodeBlockCode>(parameters => parameters
            .AddChildContent("action")
        );

        // Assert
        cut.MarkupMatches(
@"
<pre
  class=""pf-c-code-block__pre""
>
  <code
    class=""pf-c-code-block__code""
  >
    action
  </code>
</pre>
");
    }
}
