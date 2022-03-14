namespace Blatternfly.UnitTests.Components;

public class PopoverCloseButtonTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<PopoverCloseButton>(properties => properties
            .Add(p => p.AriaLabel, "string")
        );

        // Assert
        cut.MarkupMatches(
$@"
<button
  aria-disabled=""false""
  aria-label=""string""
  class=""pf-c-button pf-m-plain""
  style=""pointer-events: auto;""
  type=""button""
>
  <svg
    aria-hidden=""true""
    fill=""currentColor""
    height=""1em""
    role=""img""
    style=""vertical-align: -0.125em;""
    viewBox=""{TimesIcon.IconDefinition.ViewBox}""
    width=""1em""
  >
    <path
      d=""{TimesIcon.IconDefinition.SvgPath}""
    />
  </svg>
</button>
");
    }
}
