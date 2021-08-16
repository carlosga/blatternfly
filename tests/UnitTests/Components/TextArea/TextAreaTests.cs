using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class TextAreaTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<TextArea>(properties => properties
                .Add(p => p.AriaLabel, "simple textarea")
                .Add(p => p.Value, "test textarea")
            );

            // Assert
            cut.MarkupMatches(
@"
<textarea
  aria-invalid=""false""
  aria-label=""simple textarea""
  class=""pf-c-form-control""
  value=""test textarea""
/>
");
        }      
        
        [Fact]
        public void IsDisabledTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<TextArea>(properties => properties
                .Add(p => p.AriaLabel, "is disabled textarea")
                .Add(p => p.Value, "test textarea")
                .Add(p => p.IsDisabled, true)
            );

            // Assert
            cut.MarkupMatches(
@"
<textarea
  aria-invalid=""false""
  aria-label=""is disabled textarea""
  class=""pf-c-form-control""
  disabled=""""
  value=""test textarea""
/>
");
        }           
    }
}
