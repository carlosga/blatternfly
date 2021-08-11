using System.Collections.Generic;
using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class CardHeaderMainTests
    {
        [Fact]
        public void DefaultCardTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<CardHeaderMain>(properties => properties
                .AddChildContent("text")
            );

            // Assert
            cut.MarkupMatches(
@"
<div  
>
  text
</div>
");
        }
        
        [Fact]
        public void CustomClassTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<CardHeaderMain>(parameters => parameters
                .AddUnmatched("class", "extra-class")
                .AddChildContent("text")
            );

            // Assert
            cut.MarkupMatches(
                @"
<div
  class=""extra-class""
>
  text
</div>
");
        }
        
        [Fact]
        public void ExtraPropertiesOnRootElementTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var testId = "card-footer";

            // Act
            var cut = ctx.RenderComponent<CardHeaderMain>(parameters => parameters
                .AddUnmatched("data-testid", testId)
                .AddChildContent("text")
            );

            // Assert
            cut.MarkupMatches(
@$"
<div
  data-testid=""{testId}""
>
  text
</div>
");
        }
    }
}
