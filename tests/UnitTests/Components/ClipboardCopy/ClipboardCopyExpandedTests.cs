namespace Blatternfly.UnitTests.Components;

public class ClipboardCopyExpandedTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<ClipboardCopyExpanded>(parameters => parameters
            .AddUnmatched("class", "class-1")
            .AddUnmatched("id", "id-1")
            .AddChildContent("This is my text")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  suppresscontenteditablewarning=""true""
  class=""pf-c-clipboard-copy__expandable-content class-1""
  contenteditable=""true""
  id=""id-1""
>
  This is my text
</div>
");
    }

    [Fact]
    public void ExpandedCodeTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var code =
@"{ ""name"": ""@patternfly/react-core"", ""version"": ""1.33.2"" }";

        // Act
        var cut = ctx.RenderComponent<ClipboardCopyExpanded>(parameters => parameters
            .AddUnmatched("class", "class-1")
            .AddUnmatched("id", "id-1")
            .Add(p => p.IsCode, true)
            .AddChildContent(code)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  suppresscontenteditablewarning=""true""
  class=""pf-c-clipboard-copy__expandable-content class-1""
  contenteditable=""true""
  id=""id-1""
>
  <pre>{ ""name"": ""@patternfly/react-core"", ""version"": ""1.33.2"" }</pre>
</div>
");
    }
}
