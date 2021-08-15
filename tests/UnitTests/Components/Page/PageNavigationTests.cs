using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class PageNavigationTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<PageNavigation>(parameters => parameters
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-page__main-nav""
>
  test
</div>
");
        }    
        
        [Fact]
        public void WithLimitedWidth()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<PageNavigation>(parameters => parameters
                .Add(p => p.IsWidthLimited, true)
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-page__main-nav pf-m-limit-width""
>
  <div
    class=""pf-c-page__main-body""
  >
    test
  </div>
</div>
");
        }           
        
        [Theory]
        [InlineData(StickyPosition.Bottom)]
        [InlineData(StickyPosition.Top)]
        public void StickyTest(StickyPosition position)
        {
            // Arrange
            using var ctx = new TestContext();
            var stickyClass = position switch
            {
                StickyPosition.Top    => "pf-m-sticky-top",
                StickyPosition.Bottom => "pf-m-sticky-bottom",
                _                     => null
            };            

            // Act
            var cut = ctx.RenderComponent<PageNavigation>(parameters => parameters
                .Add(p => p.Sticky, position)
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
@$"
<div
  class=""pf-c-page__main-nav {stickyClass}""
>
  test
</div>
");
        }      
        
        [Fact]
        public void WithTopShadowTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<PageNavigation>(parameters => parameters
                .Add(p => p.HasShadowTop, true)
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-page__main-nav pf-m-shadow-top""
>
  test
</div>
");
        }         
        
        [Fact]
        public void WithBottomShadowTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<PageNavigation>(parameters => parameters
                .Add(p => p.HasShadowBottom, true)
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-page__main-nav pf-m-shadow-bottom""
>
  test
</div>
");
        }            
        
        [Fact]
        public void WithOverflowScrollTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<PageNavigation>(parameters => parameters
                .Add(p => p.HasOverflowScroll, true)
                .AddChildContent("test")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-page__main-nav pf-m-overflow-scroll""
>
  test
</div>
");
        }         
    }
}
