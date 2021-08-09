using System.Collections.Generic;
using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class CardHeadMainTests
    {
        [Fact]
        public void DefaultCardTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<CardHeadMain>(properties => properties
                .AddChildContent("text")
            );

            // Assert
            cut.MarkupMatches(
@"
<div  
  class=""pf-c-card__head-main""
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
            var cut = ctx.RenderComponent<CardHeadMain>(parameters => parameters
                .Add(p => p.AdditionalAttributes, new Dictionary<string, object> { { "class", "extra-class" } })
                .AddChildContent("text")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-card__head-main extra-class""
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
            var cut = ctx.RenderComponent<CardHeadMain>(parameters => parameters
                .Add(p => p.AdditionalAttributes, new Dictionary<string, object> { { "data-testid", testId } })
                .AddChildContent("text")
            );

            // Assert
            cut.MarkupMatches(
@$"
<div
  class=""pf-c-card__head-main""
  data-testid=""{testId}""
>
  text
</div>
");
        }
    }
}
