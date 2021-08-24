using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class MastheadMainTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<MastheadMain>(parameters => parameters
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
                @"
<div
  class=""pf-c-masthead__main""
>
  test
</div>
");
        }      
        
        [Fact]
        public void WithAdditionalCssClassTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<MastheadMain>(parameters => parameters
                .AddUnmatched("class", "custom-css")
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-masthead__main custom-css""
>
  test
</div>
");
        }         
    }
}
