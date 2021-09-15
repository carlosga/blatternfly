using Blatternfly.Layouts;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Layouts
{
    public class GridTests
    {
        [Fact]
        public void GutterTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Grid>(parameters => parameters
                .Add(p => p.HasGutter, true)
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-l-grid pf-m-gutter""
/>
");
        }
        
        [Fact]
        public void AlternativeComponentTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Grid>(parameters => parameters
                .Add(p => p.Component, "ul")
                .Add<GridItem>(p => p.ChildContent, itemparams => itemparams
                    .Add(p => p.Component, "li")
                    .AddChildContent("Test")
                )
            );

            // Assert
            cut.MarkupMatches(
@"
<ul
  class=""pf-l-grid""
>
  <li
    class=""pf-l-grid__item""
  >
    Test
  </li>
</ul>
");            
        }         
    }
}
