namespace Blatternfly.UnitTests.Components;

public class ClipboardCopyButtonTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<ClipboardCopyButton>(parameters => parameters
            .Add(p => p.id, "my-id")
            .Add(p => p.TextId, "my-text-id")
            .AddUnmatched("class", "fancy-copy-button")
            .Add(p => p.ExitDelay, 1000)
            .Add(p => p.EntryDelay, 2000)
            .Add(p => p.MaxWidth, "500px")
            .Add(p => p.Position, TooltipPosition.Right)
            .Add(p => p.AriaLabel, "click this button to copy text")
            .AddChildContent("Copy Me")
        );

        // Assert
        cut.MarkupMatches(
$@"
<button
  aria-disabled=""false""
  aria-label=""click this button to copy text""
  aria-labelledby=""my-id my-text-id""
  class=""pf-c-button pf-m-control fancy-copy-button""
  id=""my-id""
  type=""button""
>
  <svg
    aria-hidden=""true""
    fill=""currentColor""
    height=""1em""
    role=""img""
    style=""vertical-align: -0.125em;""
    viewBox=""{CopyIcon.IconDefinition.ViewBox}""
    width=""1em""
  >
    <path d=""{CopyIcon.IconDefinition.SvgPath}""></path>
  </svg>
</button>
");
    }
}
