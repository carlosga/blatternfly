using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class LoginMainFooterLinksItemTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<LoginMainFooterLinksItem>(parameters => parameters
                .Add(p => p.Href, "#")
                .Add(p => p.Target, "")
            );

            // Assert
            cut.MarkupMatches(
@"
<li
  class=""pf-c-login__main-footer-links-item""
>
  <a
    class=""pf-c-login__main-footer-links-item-link""
    href=""#""
    target=""""
  >
  </a>
</li>
");
        }      
        
        [Fact]
        public void WithAdditionalCssClassTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<LoginMainFooterLinksItem>(parameters => parameters
                .AddUnmatched("class", "extra-class")

            );

            // Assert
            cut.MarkupMatches(
@"
<li
  class=""pf-c-login__main-footer-links-item extra-class""
>
  <a
    class=""pf-c-login__main-footer-links-item-link""
  >
  </a>
</li>
");
        }           
        
        [Fact]
        public void WithAdditionalPropertiesOnRootElementTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var testId = "login-body";

            // Act
            var cut = ctx.RenderComponent<LoginMainFooterLinksItem>(parameters => parameters
                .AddUnmatched("data-testid", testId)

            );

            // Assert
            cut.MarkupMatches(
@$"
<li
  class=""pf-c-login__main-footer-links-item""
  data-testid=""{testId}""
>
  <a
    class=""pf-c-login__main-footer-links-item-link""
  >
  </a>
</li>
");
        }        
        
        [Fact]
        public void WithChildContentTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var testId = "login-body";

            // Act
            var cut = ctx.RenderComponent<LoginMainFooterLinksItem>(parameters => parameters
                .AddChildContent("<div>My custom node</div>")

            );

            // Assert
            cut.MarkupMatches(
                @$"
<li
  class=""pf-c-login__main-footer-links-item""
>
  <a
    class=""pf-c-login__main-footer-links-item-link""
  >
    <div>My custom node</div>
  </a>
</li>
");
        }            
    }
}
