﻿using System;
using Blatternfly.Components;
using Blatternfly.Interop;
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

            // Setup Javascript interop
            ctx.SetupJavascriptInterop();
            
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
            
            // Setup Javascript interop
            ctx.SetupJavascriptInterop();
            
            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => 
                ctx.RenderComponent<OverflowMenu>(parameters => parameters.Add(p => p.Breakpoint, (Breakpoints)10))
            );
            
            Assert.Equal("OverflowMenu will not be visible without a valid breakpoint.", ex.Message);
        }
    }
}
