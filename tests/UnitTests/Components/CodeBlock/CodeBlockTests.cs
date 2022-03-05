namespace Blatternfly.UnitTests.Components;

public class CodeBlockTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<CodeBlock>(parameters => parameters
            .AddChildContent("test text")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-code-block""
>
  <div
    class=""pf-c-code-block__header""
  >
    <div
      class=""pf-c-code-block__actions""
    >
    </div>
  </div>
  <div
    class=""pf-c-code-block__content""
  >
    test text
  </div>
</div>
");
    }

    [Fact]
    public void CodeBlockWithComponentsTests()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<CodeBlock>(parameters => parameters
            .Add<CodeBlockAction>(p => p.Actions, paction => paction.AddChildContent("button"))
            .Add<CodeBlockCode>(p => p.ChildContent, pcode => pcode.AddChildContent("inside pre/code tags"))
            .AddChildContent("test outer text")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-code-block""
>
  <div
    class=""pf-c-code-block__header""
  >
    <div
      class=""pf-c-code-block__actions""
    >
      <div
          class=""pf-c-code-block__actions-item""
      >
          button
      </div>
    </div>
  </div>
  <div
    class=""pf-c-code-block__content""
  >
    <pre
      class=""pf-c-code-block__pre""
      diff:whitespace=""RemoveWhitespaceNodes""
    >
      <code
        class=""pf-c-code-block__code""
      >
        inside pre/code tags
      </code>
    </pre>
    test outer text
  </div>
</div>
");
    }
}
