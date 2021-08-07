using Xunit;
using Bunit;
using Blatternfly.Components;

namespace Blatternfly.UnitTests.Components
{
    public class SkipToContentTests
    {
        [Fact]
        public void VerifySkipToContentTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<SkipToContent>(parameters => parameters
                .Add(p => p.Href, "#main-content")
            );

            // Assert
            cut.MarkupMatches(
@"
<a
  class=""pf-c-button pf-m-primary pf-c-skip-to-content""
  href=""#main-content""
/>
");
        }
        
        [Fact]
        public void VerifySkipToContentIfForcedToDisplayTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<SkipToContent>(parameters => parameters
                .Add(p => p.Href, "#main-content")
                .Add(p => p.Show, true)
            );

            // Assert
            cut.MarkupMatches(
                @"
<a
  class=""pf-c-button pf-m-primary pf-c-skip-to-content""
  href=""#main-content""
/>
");
        }        
    }
}
