using System;
using Blatternfly.Components;
using Blatternfly.Observers;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class OverflowMenuTests
    {
        [Theory]
        [InlineData(Breakpoints.Medium)]
        [InlineData(Breakpoints.Large)]
        [InlineData(Breakpoints.ExtraLarge)]
        [InlineData(Breakpoints.ExtraLarge2)]
        public void WithBreakpointTest(Breakpoints breakpoint)
        {
            // Arrange
            using var ctx = new TestContext();
            ctx.JSInterop.Mode = JSRuntimeMode.Strict;
            
            ctx.JSInterop.SetupVoid("Blatternfly.Dropdown.onKeyDown", _ => true);
            ctx.JSInterop.Setup<Size<int>>("Blatternfly.Window.innerSize").SetResult(new Size<int> { Width = 3840, Height = 2160 });
            
            // Register services
            ctx.Services.AddSingleton<IWindowObserver>(new WindowObserver(ctx.JSInterop.JSRuntime));

            // Act
            var cut = ctx.RenderComponent<OverflowMenu>(parameters => parameters
                .Add(p => p.Breakpoint, breakpoint)
            );
            
            // Assert
            cut.MarkupMatches(@"<div class=""pf-c-overflow-menu""> </div>");
        }
        
        [Fact]
        public void ShouldThrowOnInvalidBreakpointTest()
        {
            // Arrange
            using var ctx = new TestContext();
            ctx.JSInterop.Mode = JSRuntimeMode.Strict;
            
            ctx.JSInterop.SetupVoid("Blatternfly.Dropdown.onKeyDown", _ => true);
            ctx.JSInterop.Setup<Size<int>>("Blatternfly.Window.innerSize").SetResult(new Size<int> { Width = 3840, Height = 2160 });
            
            // Register services
            ctx.Services.AddSingleton<IWindowObserver>(new WindowObserver(ctx.JSInterop.JSRuntime));

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => 
                ctx.RenderComponent<OverflowMenu>(parameters => parameters.Add(p => p.Breakpoint, (Breakpoints)10))
            );
            
            Assert.Equal("OverflowMenu will not be visible without a valid breakpoint.", ex.Message);
        }
    }
}
