namespace Blatternfly.UnitTests.Components;

public class ClipboardCopyToggleTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<ClipboardCopyToggle>(parameters => parameters
            .Add(p => p.id, "my-id")
            .Add(p => p.TextId, "my-text-id")
            .Add(p => p.ContentId, "my-content-id")
            .Add(p => p.IsExpanded, false)
            .AddUnmatched("class", "myclassName")
            .Add(p => p.AriaLabel, "toggle content")
        );

        // Assert
        cut.MarkupMatches(
$@"
<button
  aria-controls=""my-id my-content-id""
  aria-disabled=""false""
  aria-expanded=""false""
  aria-label=""toggle content""
  aria-labelledby=""my-id my-text-id""
  class=""pf-c-button pf-m-control myclassName""
  id=""my-id""
  type=""button""
>
  <svg
    aria-hidden=""true""
    fill=""currentColor""
    height=""1em""
    role=""img""
    style=""vertical-align: -0.125em;""
    viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
    width=""1em""
  >
    <path
      d=""{AngleRightIcon.IconDefinition.SvgPath}""
    />
  </svg>
</button>
");
    }
}
