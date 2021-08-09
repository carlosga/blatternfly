using System.Collections.Generic;
using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class CardBodyTests
    {
        [Fact]
        public void DefaultCardTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<CardBody>();

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-card__body""
/>
");
        }
        
        [Fact]
        public void CustomCssClassTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<CardBody>(parameters => parameters
                .Add(p => p.AdditionalAttributes, new Dictionary<string, object> { { "class", "extra-class" }})
            );

            // Assert
            cut.MarkupMatches(
                @"
<div
  class=""pf-c-card__body extra-class""
/>
");
        }        
        
        [Fact]
        public void ExtraPropertiesOnRootElementTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var testId = "card-body";

            // Act
            var cut = ctx.RenderComponent<CardBody>(parameters => parameters
                .Add(p => p.AdditionalAttributes, new Dictionary<string, object> { { "data-testid", testId } })
            );

            // Assert
            cut.MarkupMatches(
                @$"
<div
  data-testid=""{testId}""
  class=""pf-c-card__body""
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
            var cut = ctx.RenderComponent<CardBody>(parameters => parameters
                .Add(p => p.Component, "section")
            );

            // Assert
            cut.MarkupMatches(
                @$"
<{component}
  class=""pf-c-card__body""
/>
");
        }         
        
        [Fact]
        public void NoFillTest()
        {
            // Arrange
            using var ctx = new TestContext();
 
            // Act
            var cut = ctx.RenderComponent<CardBody>(parameters => parameters
                .Add(p => p.IsFilled, false)
            );

            // Assert
            cut.MarkupMatches(
                @$"
<div
  class=""pf-c-card__body pf-m-no-fill""
/>
");
        }            
    }
}
