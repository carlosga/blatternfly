using System;
using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class DataListCellTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<DataListCell>(parameters => parameters
                .AddChildContent("Secondary")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-data-list__cell""
>
  Secondary
</div>
");
        }      
        
        [Fact]
        public void WithAdditionalCssClassTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<DataListCell>(parameters => parameters
                .AddUnmatched("class", "data-list-custom")
                .AddChildContent("Secondary")
            );

            // Assert
            cut.MarkupMatches(
@"
<div
  class=""pf-c-data-list__cell data-list-custom""
>
  Secondary
</div>
");
        }           
        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void WithWidthModifiersTest(int width)
        {
            // Arrange
            using var ctx = new TestContext();
            var widthClass = width == 1 ? null : $"pf-m-flex-{width}";

            // Act
            var cut = ctx.RenderComponent<DataListCell>(parameters => parameters
                .AddUnmatched("id", "primary-item")
                .Add(p => p.Width, width)
                .AddChildContent("Primary Id")
            );

            // Assert
            cut.MarkupMatches(
$@"
<div
  class=""pf-c-data-list__cell {widthClass}""
  id=""primary-item""
>
  Primary Id
</div>
");
        }    
        
        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public void OutOfRangeWidthModifierShouldThrowTest(int width)
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => ctx.RenderComponent<DataListCell>(
                parameters => parameters.Add(p => p.Width, width))
            );
            Assert.Equal("DataListCell: Width should be between 1 and 5.", ex.Message);
        }   
        
        [Theory]
        [InlineData(DataListWrapModifier.Nowrap)]
        [InlineData(DataListWrapModifier.Truncate)]
        [InlineData(DataListWrapModifier.BreakWord)]
        public void WithTextModifiersText(DataListWrapModifier modifier)
        {
            // Arrange
            using var ctx = new TestContext();
            var modifierClass = modifier switch
            {
                DataListWrapModifier.Nowrap    => "pf-m-nowrap",
                DataListWrapModifier.Truncate  => "pf-m-truncate",
                DataListWrapModifier.BreakWord => "pf-m-break-word",
                _                              => null
            };   

            // Act
            var cut = ctx.RenderComponent<DataListCell>(parameters => parameters
                .AddUnmatched("id", "primary-item")
                .Add(p => p.WrapModifier, modifier)
                .AddChildContent("Primary Id")
            );

            // Assert
            cut.MarkupMatches(
$@"
<div
  class=""pf-c-data-list__cell {modifierClass}""
  id=""primary-item""
>
  Primary Id
</div>
");
        }            
    }
}
