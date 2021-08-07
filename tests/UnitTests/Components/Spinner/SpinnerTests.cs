using Xunit;
using Bunit;
using Blatternfly.Components;

namespace Blatternfly.UnitTests.Components
{
    public class SpinnerTests
    {
        [Fact]
        public void SimpleSpinnerTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Spinner>();

            // Assert
            cut.MarkupMatches(
@"
<span
  aria-valuetext=""Loading...""
  class=""pf-c-spinner pf-m-xl""
  role=""progressbar""
>
  <span class=""pf-c-spinner__clipper""></span>
  <span class=""pf-c-spinner__lead-ball""></span>  
  <span class=""pf-c-spinner__tail-ball""></span>
</span>
");
        }
        
        [Theory]
        [InlineData(SpinnerSize.Small)]
        [InlineData(SpinnerSize.Medium)]
        [InlineData(SpinnerSize.Large)]
        [InlineData(SpinnerSize.ExtraLarge)]
        public void SpinnerSizeTest(SpinnerSize size)
        {
            // Arrange
            using var ctx = new TestContext();
            var sizeModifier = size switch
            {
                SpinnerSize.Small      => "sm",
                SpinnerSize.Medium     => "md",
                SpinnerSize.Large      => "lg",
                SpinnerSize.ExtraLarge => "xl"
            };

            // Act
            var cut = ctx.RenderComponent<Spinner>(parameters => parameters
                .Add(p => p.Size, size)
            );

            // Assert
            cut.MarkupMatches(
@$"
<span
  aria-valuetext=""Loading...""
  class=""pf-c-spinner pf-m-{sizeModifier}""
  role=""progressbar""
>
  <span class=""pf-c-spinner__clipper""></span>
  <span class=""pf-c-spinner__lead-ball""></span>
  <span class=""pf-c-spinner__tail-ball""></span>
</span>
");
        }        
    }
}
