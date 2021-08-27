using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class DataListItemCellsTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<DataListItemCells>(parameters => parameters
                .Add<DataListCell>(p => p.ChildContent, cell1params => cell1params
                    .AddUnmatched("id", "primary-item-1")
                    .AddUnmatched("class", "data-list-custom")
                    .AddChildContent("Primary Id")
                )
                .Add<DataListCell>(p => p.ChildContent, cell1params => cell1params
                    .AddUnmatched("id", "primary-item-2")
                    .AddUnmatched("class", "data-list-custom")
                    .AddChildContent("Primary Id 2")
                )
            );

            // Assert
            cut.MarkupMatches(
@"
<div 
  class=""pf-c-data-list__item-content""
>
  <div 
    class=""pf-c-data-list__cell data-list-custom"" 
    id=""primary-item-1""
  >
    Primary Id
  </div>
  <div 
    class=""pf-c-data-list__cell data-list-custom"" 
    id=""primary-item-2""
  >
    Primary Id 2
  </div>
</div>
");
        }          
    }
}
