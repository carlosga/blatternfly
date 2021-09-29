using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class ModalContentTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();
            
            // Setup Javascript interop
            ctx.SetupJavascriptInterop();

            // Act
            var cut = ctx.RenderComponent<ModalBoxHeader>(parameters => parameters
                .AddChildContent("This is a ModalBox header")
            );

            // Assert
            cut.MarkupMatches(
$@"
<header
  class=""pf-c-modal-box__header""
>
  This is a ModalBox header
</header>
");
        }
    }
}
