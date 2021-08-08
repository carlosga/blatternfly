using System.Collections.Generic;
using Blatternfly.Layouts;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Layouts
{
    public class FlexTests
    {
        [Fact]
        public void SimpleFlexWithSingleItem()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Flex>(parameters => parameters
                .Add<FlexItem>(p => p.ChildContent, itemparams => itemparams
                    .AddChildContent("Test")
                )
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-l-flex""
>
  <div>
    Test
  </div>
</div>
");
        }
        
        [Fact]
        public void NestedFlexItem()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Flex>(parameters => parameters
                .Add<Flex>(p => p.ChildContent, itemparams => itemparams
                    .Add<FlexItem>(p => p.ChildContent, niparams => niparams.AddChildContent("Test"))
                )
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-l-flex""
>
  <div
    class=""pf-l-flex""
  >
    <div>
      Test
    </div>
  </div>
</div>
");
        }
        
        [Fact]
        public void FlexWithCustomClassTests()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Flex>(parameters => parameters
                .Add(p => p.AdditionalAttributes, new Dictionary<string, object> { { "class", "extra-class" } })
            );

            // Assert
            cut.MarkupMatches(@"<div class=""pf-l-flex extra-class"" />");
        } 
        
        [Fact]
        public void ExtraPropertiesOnRootElementTests()
        {
            // Arrange
            using var ctx = new TestContext();
            var testId = "flex";

            // Act
            var cut = ctx.RenderComponent<Flex>(parameters => parameters
                .Add(p => p.AdditionalAttributes, new Dictionary<string, object> { { "data-testid", testId } })
            );

            // Assert
            cut.MarkupMatches($@"<div data-testid=""{testId}"" class=""pf-l-flex"" />");
        }          
    }
}
