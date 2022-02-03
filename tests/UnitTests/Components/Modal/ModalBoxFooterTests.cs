namespace Blatternfly.UnitTests.Components;

public class ModalBoxFooterTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<ModalBoxFooter>(parameters => parameters
            .AddUnmatched("class", "test-box-footer-class")
            .AddChildContent("This is a ModalBox Footer")
        );

        // Assert
        cut.MarkupMatches(
@"
<footer
  class=""pf-c-modal-box__footer test-box-footer-class""
>
  This is a ModalBox Footer
</footer>
");
    }
}
