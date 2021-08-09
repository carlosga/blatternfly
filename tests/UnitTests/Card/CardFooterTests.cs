using System.Collections.Generic;
using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class CardFooterTests
    {
        [Fact]
        public void DefaultCardTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<CardFooter>();

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-card__footer""
/>
");
        }
        
        [Fact]
        public void CustomClassTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<CardFooter>(parameters => parameters
                .Add(p => p.AdditionalAttributes, new Dictionary<string, object> { { "class", "extra-class" } })
            );

            // Assert
            cut.MarkupMatches(
                @"
<div
  class=""pf-c-card__footer extra-class""
/>
");
        }
        
        [Fact]
        public void ExtraPropertiesOnRootElementTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var testId = "card-footer";

            // Act
            var cut = ctx.RenderComponent<CardFooter>(parameters => parameters
                .Add(p => p.AdditionalAttributes, new Dictionary<string, object> { { "data-testid", testId } })
            );

            // Assert
            cut.MarkupMatches(
@$"
<div
  data-testid=""{testId}""
  class=""pf-c-card__footer""
/>
");
        }
        
        [Fact]
        public void CustomComponentTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var component = "section";
 
            // Act
            var cut = ctx.RenderComponent<CardFooter>(parameters => parameters
                .Add(p => p.Component, "section")
            );

            // Assert
            cut.MarkupMatches(
@$"
<{component}
  class=""pf-c-card__footer""
/>
");
        }
    }
}
