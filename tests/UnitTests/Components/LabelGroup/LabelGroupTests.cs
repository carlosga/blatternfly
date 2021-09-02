using System;
using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class LabelGroupTests
    {
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var items = new[] { "1.1" }; 

            // Act
            var cut = ctx.RenderComponent<LabelGroup<string>>(parameters => parameters
                .Add(p => p.Items, items)
                .Add<Label, string>(p => p.ItemTemplate, value => itemparams => itemparams
                    .Add(p => p.ChildContent, value)
                )
            );
            
            // Assert
            cut.MarkupMatches(
@"
<div class=""pf-c-label-group"">
  <div class=""pf-c-label-group__main"">
    <ul class=""pf-c-label-group__list"" aria-label=""Label group category"" role=""list"">
      <li class=""pf-c-label-group__list-item"">
        <span class=""pf-c-label"">
          <span class=""pf-c-label__content"">1.1</span>
        </span>
      </li>
    </ul>
  </div>
</div>
");
        }
        
        [Fact]
        public void WithCategoryTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var items = new[] { "1.1" }; 

            // Act
            var cut = ctx.RenderComponent<LabelGroup<string>>(parameters => parameters
                .AddUnmatched("id", "pf-random-id-1")
                .Add(p => p.Items, items)
                .Add(p => p.CategoryName, "category")
                .Add<Label, string>(p => p.ItemTemplate, value => itemparams => itemparams
                    .Add(p => p.ChildContent, value)
                )
            );
            
            // Assert
            cut.MarkupMatches(
@"
<div class=""pf-c-label-group pf-m-category"">
  <div class=""pf-c-label-group__main"">
    <span class=""pf-c-label-group__label"" aria-hidden=""true"" id=""pf-random-id-1"">category</span>
    <ul class=""pf-c-label-group__list"" aria-labelledby=""pf-random-id-1"" role=""list"">
      <li class=""pf-c-label-group__list-item"">
        <span class=""pf-c-label"">
          <span class=""pf-c-label__content"">1.1</span>
        </span>
      </li>
    </ul>
  </div>
</div>
");
        }   
        
        [Fact]
        public void WithClosableCategoryTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var items = new[] { "1.1" }; 

            // Act
            var cut = ctx.RenderComponent<LabelGroup<string>>(parameters => parameters
                .AddUnmatched("id", "pf-random-id-2")
                .Add(p => p.Items, items)
                .Add(p => p.CategoryName, "category")
                .Add(p => p.IsClosable, true)
                .Add<Label, string>(p => p.ItemTemplate, value => itemparams => itemparams
                    .Add(p => p.ChildContent, value)
                )
            );
            
            // Assert
            cut.MarkupMatches(
$@"
<div class=""pf-c-label-group pf-m-category"">
  <div class=""pf-c-label-group__main"">
    <span
      class=""pf-c-label-group__label""
      aria-hidden=""true""
      id=""pf-random-id-2""
    >
      category
    </span>
    <ul class=""pf-c-label-group__list"" aria-labelledby=""pf-random-id-2"" role=""list"">
      <li class=""pf-c-label-group__list-item"">
        <span class=""pf-c-label"">
          <span class=""pf-c-label__content"">1.1</span>
        </span>
      </li>
    </ul>
  </div>
  <div class=""pf-c-label-group__close"">
    <button
      id=""remove_group_pf-random-id-2""
      aria-labelledby=""remove_group_pf-random-id-2 pf-random-id-2""
      aria-disabled=""false""
      aria-label=""Close label group""
      class=""pf-c-button pf-m-plain""
      type=""button""
    >
      <svg
        style=""vertical-align: -0.125em;""
        fill=""currentColor""
        height=""1em""
        width=""1em""
        viewBox=""{TimesCircleIcon.IconDefinition.ViewBox}""
        aria-hidden=""true""
        role=""img""
      >
        <path
          d=""{TimesCircleIcon.IconDefinition.SvgPath}"">
        </path>
      </svg>
    </button>
  </div>
</div>
");
        }        
        
        [Fact]
        public void EnmptyTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var items = new string[0]; 

            // Act
            var cut = ctx.RenderComponent<LabelGroup<string>>(parameters => parameters
                .Add(p => p.Items, items)
                .Add<Label, string>(p => p.ItemTemplate, value => itemparams => itemparams
                    .Add(p => p.ChildContent, value)
                )
            );
            
            // Assert
            cut.MarkupMatches("");
        }        
    }
}
