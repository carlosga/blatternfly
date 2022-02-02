namespace Blatternfly.UnitTests.Components;

public class ModalBoxCloseButtonTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<ModalBoxCloseButton>(parameters => parameters
            .AddUnmatched("class", "test-box-close-button-class")
        );

        // Assert
        cut.MarkupMatches(
$@"
<button
  aria-disabled=""false""
  aria-label=""Close""
  class=""pf-c-button pf-m-plain test-box-close-button-class""
  type=""button""
>
  <svg
    style=""vertical-align: -0.125em;""
    fill=""currentColor""
    height=""1em""
    width=""1em""
    viewBox=""{TimesIcon.IconDefinition.ViewBox}""
    aria-hidden=""true""
    role=""img""
  >
    <path d=""{TimesIcon.IconDefinition.SvgPath}""></path>
  </svg>
</button>
");
    }
}
