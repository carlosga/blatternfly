using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class ModalBoxTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();
            
            // Setup Javascript interop
            ctx.SetupJavascriptInterop();

            // Act
            var cut = ctx.RenderComponent<ModalBox>(parameters => parameters
                .AddUnmatched("id", "boxId")
                .Add(p => p.AriaDescribedBy, "Test Modal Box")
                .AddChildContent("This is a ModalBox")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  aria-modal=""true""
  class=""pf-c-modal-box""
  id=""boxId""
  role=""dialog""
  aria-describedby=""Test Modal Box""
>
  This is a ModalBox
</div>
");
        }

        [Fact]
        public void IsLargeTest()
        {
            // Arrange
            using var ctx = new TestContext();
            
            // Setup Javascript interop
            ctx.SetupJavascriptInterop();

            // Act
            var cut = ctx.RenderComponent<ModalBox>(parameters => parameters
                .Add(p => p.Variant, ModalVariant.Large)
                .AddUnmatched("id", "boxId")
                .Add(p => p.AriaDescribedBy, "Test Modal Box")
                .AddChildContent("This is a ModalBox")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  aria-modal=""true""
  class=""pf-c-modal-box pf-m-lg""
  id=""boxId""
  role=""dialog""
  aria-describedby=""Test Modal Box""
>
  This is a ModalBox
</div>
");
        }
        
        [Fact]
        public void IsSmallTest()
        {
            // Arrange
            using var ctx = new TestContext();
            
            // Setup Javascript interop
            ctx.SetupJavascriptInterop();

            // Act
            var cut = ctx.RenderComponent<ModalBox>(parameters => parameters
                .Add(p => p.Variant, ModalVariant.Small)
                .AddUnmatched("id", "boxId")
                .Add(p => p.AriaDescribedBy, "Test Modal Box")
                .AddChildContent("This is a ModalBox")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  aria-modal=""true""
  class=""pf-c-modal-box pf-m-sm""
  id=""boxId""
  role=""dialog""
  aria-describedby=""Test Modal Box""
>
  This is a ModalBox
</div>
");
        }
        
        [Fact]
        public void IsMediumTest()
        {
            // Arrange
            using var ctx = new TestContext();
            
            // Setup Javascript interop
            ctx.SetupJavascriptInterop();

            // Act
            var cut = ctx.RenderComponent<ModalBox>(parameters => parameters
                .Add(p => p.Variant, ModalVariant.Medium)
                .AddUnmatched("id", "boxId")
                .Add(p => p.AriaDescribedBy, "Test Modal Box")
                .AddChildContent("This is a ModalBox")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  aria-modal=""true""
  class=""pf-c-modal-box pf-m-md""
  id=""boxId""
  role=""dialog""
  aria-describedby=""Test Modal Box""
>
  This is a ModalBox
</div>
");
        }
        
        [Fact]
        public void IsTopAlignedTest()
        {
            // Arrange
            using var ctx = new TestContext();
            
            // Setup Javascript interop
            ctx.SetupJavascriptInterop();

            // Act
            var cut = ctx.RenderComponent<ModalBox>(parameters => parameters
                .Add(p => p.Position, ModalPosition.Top)
                .AddUnmatched("id", "boxId")
                .Add(p => p.AriaDescribedBy, "Test Modal Box")
                .AddChildContent("This is a ModalBox")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  aria-modal=""true""
  class=""pf-c-modal-box pf-m-align-top""
  id=""boxId""
  role=""dialog""
  aria-describedby=""Test Modal Box""
>
  This is a ModalBox
</div>
");
        }
        
        [Fact]
        public void TopAlignedDistanceTest()
        {
            // Arrange
            using var ctx = new TestContext();
            
            // Setup Javascript interop
            ctx.SetupJavascriptInterop();

            // Act
            var cut = ctx.RenderComponent<ModalBox>(parameters => parameters
                .Add(p => p.Position, ModalPosition.Top)
                .Add(p => p.PositionOffset, "50px")
                .AddUnmatched("id", "boxId")
                .Add(p => p.AriaDescribedBy, "Test Modal Box")
                .AddChildContent("This is a ModalBox")
            );

            // Assert
            cut.MarkupMatches(
$@"
<div
  aria-modal=""true""
  class=""pf-c-modal-box pf-m-align-top""
  id=""boxId""
  role=""dialog""
  aria-describedby=""Test Modal Box""
  style=""--pf-c-modal-box--m-align-top--spacer: 50px""
>
  This is a ModalBox
</div>
");
        }
    }
}
