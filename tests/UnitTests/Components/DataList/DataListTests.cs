using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class DataListTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<DataList>(parameters => parameters
                .Add(p => p.AriaLabel, "this is a simple list")
            );

            // Assert
            cut.MarkupMatches(
@"
<ul
  aria-label=""this is a simple list""
  class=""pf-c-data-list pf-m-grid-md""
/>
");
        }        
        
        [Fact]
        public void IsCompactTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<DataList>(parameters => parameters
                .Add(p => p.AriaLabel, "this is a simple list")
                .Add(p => p.IsCompact, true)
            );

            // Assert
            cut.MarkupMatches(
@"
<ul
  aria-label=""this is a simple list""
  class=""pf-c-data-list pf-m-compact pf-m-grid-md""
/>
");
        }    
        
        [Theory]
        [InlineData(DataListGridBreakpoint.None)]
        [InlineData(DataListGridBreakpoint.Always)]
        [InlineData(DataListGridBreakpoint.Small)]
        [InlineData(DataListGridBreakpoint.Medium)]
        [InlineData(DataListGridBreakpoint.Large)]
        [InlineData(DataListGridBreakpoint.ExtraLarge)]
        [InlineData(DataListGridBreakpoint.ExtraLarge2)]        
        public void GridBreakpointTest(DataListGridBreakpoint breakpoint)
        {
            // Arrange
            using var ctx = new TestContext();
            var breakpointClass = breakpoint switch
            {
                DataListGridBreakpoint.None        => "pf-m-grid-none",
                DataListGridBreakpoint.Always      => "pf-m-grid",
                DataListGridBreakpoint.Small       => "pf-m-grid-sm",
                DataListGridBreakpoint.Medium      => "pf-m-grid-md",
                DataListGridBreakpoint.Large       => "pf-m-grid-lg",
                DataListGridBreakpoint.ExtraLarge  => "pf-m-grid-xl",
                DataListGridBreakpoint.ExtraLarge2 => "pf-m-grid-2xl",
                _                                  => null
            };

            // Act
            var cut = ctx.RenderComponent<DataList>(parameters => parameters
                .Add(p => p.AriaLabel, "this is a simple list")
                .Add(p => p.GridBreakpoint, breakpoint)
            );

            // Assert
            cut.MarkupMatches(
$@"
<ul
  aria-label=""this is a simple list""
  class=""pf-c-data-list {breakpointClass}""
/>
");
        }
        
        [Fact]
        public void WithAdditionalCssClassTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<DataList>(parameters => parameters
                .AddUnmatched("class", "data-list-custom")
                .Add(p => p.AriaLabel, "this is a simple list")
            );

            // Assert
            cut.MarkupMatches(
@"
<ul
  aria-label=""this is a simple list""
  class=""pf-c-data-list pf-m-grid-md data-list-custom""
/>
");
        }
    }
}
