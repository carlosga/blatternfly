namespace Blatternfly.UnitTests.Components;

public class ModalBoxDescriptionTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<ModalBoxDescription>(parameters => parameters
            .AddUnmatched("id", "id")
            .AddUnmatched("class", "test-box-class")
            .AddChildContent("This is a ModalBox description")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-modal-box__description test-box-class""
  id=""id""
>
  This is a ModalBox description
</div>
");
    }
}
