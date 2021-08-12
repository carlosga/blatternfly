using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class FormHelperTextTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<FormHelperText>(parameters => parameters
                .Add(p => p.IsError, true)
                .Add(p => p.IsHidden, false)
            );

            // Assert
            cut.MarkupMatches(@"<p class=""pf-c-form__helper-text pf-m-error"" />");
        }
        
        [Fact]
        public void WithDivVariantTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<FormHelperText>(parameters => parameters
                .Add(p => p.Component, FormHelperTextVariant.div)
                .Add(p => p.IsError, true)
                .Add(p => p.IsHidden, false)
            );

            // Assert
            cut.MarkupMatches(@"<div class=""pf-c-form__helper-text pf-m-error"" />");
        }        

        [Fact]
        public void WithIconTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<FormHelperText>(parameters => parameters
                .Add(p => p.IsError, true)
                .Add(p => p.IsHidden, false)
                .Add<ExclamationCircleIcon>(p => p.Icon)
            );

            // Assert
            cut.MarkupMatches(
@$"
<p
  class=""pf-c-form__helper-text pf-m-error""
>
  <span
    class=""pf-c-form__helper-text-icon""
  >
    <svg
      style=""vertical-align: -0.125em;"" 
      fill=""currentColor"" 
      height=""1em"" 
      width=""1em"" 
      viewBox=""{ExclamationCircleIcon.IconDefinition.ViewBox}"" 
      aria-hidden=""true"" 
      role=""img""
    >
      <path d=""{ExclamationCircleIcon.IconDefinition.SvgPath}""></path>
    </svg>
  </span>
</p>
");
        }
        
        [Fact]
        public void WithCustomClassTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<FormHelperText>(parameters => parameters
                .AddUnmatched("class", "extra-class")
            );

            // Assert
            cut.MarkupMatches(@"<p class=""pf-c-form__helper-text pf-m-hidden extra-class"" />");
        }        
        
        [Fact]
        public void WithExtraPropertiesOnRootElement()
        {
            // Arrange
            using var ctx = new TestContext();
            var testId = "login-body";

            // Act
            var cut = ctx.RenderComponent<FormHelperText>(parameters => parameters
                .AddUnmatched("data-testid", testId)
            );

            // Assert
            cut.MarkupMatches(@$"<p class=""pf-c-form__helper-text pf-m-hidden"" data-testid=""{testId}"" />");
        }         
        
        [Fact]
        public void LoginFooterItemWithCustomNode()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<FormHelperText>(parameters => parameters
                .AddChildContent("<div>My custom node</div>")
            );

            // Assert
            cut.MarkupMatches(
@"
<p
  class=""pf-c-form__helper-text pf-m-hidden""
>
  <div>My custom node</div>
</p>
");
        }        
    }
}
