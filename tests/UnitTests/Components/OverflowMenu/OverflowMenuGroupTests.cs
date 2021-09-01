using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class OverflowMenuGroupTests
    {
        [Fact]
        public void IsPersistentAndBelowBreakpointShouldStillShowTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<OverflowMenuGroup>(parameters => parameters
                .Add(p => p.IsBelowBreakpoint, false)
                .Add(p => p.IsPersistent, true)
            );
            
            // Assert
            cut.MarkupMatches(@"<div class=""pf-c-overflow-menu__group"" /> ");
        }      
        
        [Fact]
        public void BelowBreakpointButNotIsPersistentShouldNotShowTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<OverflowMenuGroup>(parameters => parameters
                .Add(p => p.IsBelowBreakpoint, true)
            );
            
            // Assert
            cut.MarkupMatches(@"");
        }   
        
        [Fact]
        public void AsButtonGroupTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<OverflowMenuGroup>(parameters => parameters
                .Add(p => p.GroupType, OverflowMenuGroupType.Button)
            );
            
            // Assert
            cut.MarkupMatches(@"<div class=""pf-c-overflow-menu__group pf-m-button-group"" /> ");
        }     
        
        [Fact]
        public void AsIconGroupTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<OverflowMenuGroup>(parameters => parameters
                .Add(p => p.GroupType, OverflowMenuGroupType.Icon)
            );
            
            // Assert
            cut.MarkupMatches(@"<div class=""pf-c-overflow-menu__group pf-m-icon-button-group"" /> ");
        }         
    }
}
