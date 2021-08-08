using Blatternfly.Layouts;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Layouts
{
    public class StackItemTests
    {
        [Fact]
        public void ItemTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<StackItem>(parameters => parameters
                .Add(p => p.ChildContent, "<h1>Gallery Item</h1>")
            );

            // Assert
            cut.MarkupMatches(@"<div class=""pf-l-stack__item""><h1>Gallery Item</h1></div>");            
        }
    }
}
