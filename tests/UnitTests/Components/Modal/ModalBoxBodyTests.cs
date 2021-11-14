namespace Blatternfly.UnitTests.Components;

public class ModalBoxBodyTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();
        
        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<ModalBoxBody>(parameters => parameters
            .AddUnmatched("id", "id")
            .AddUnmatched("class", "test-box-class")
            .AddChildContent("This is a ModalBox body")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-modal-box__body test-box-class""
  id=""id""
>
  This is a ModalBox body
</div>
");
    }          
}
