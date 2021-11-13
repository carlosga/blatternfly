namespace Blatternfly.UnitTests.Components;

public class ChipGroupTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var items = new[] { "1.1" }; 

        // Act
        var cut = ctx.RenderComponent<ChipGroup<string>>(parameters => parameters
            .Add(p => p.Items, items)
            .Add<Chip, string>(p => p.ItemTemplate, value => itemparams => itemparams
                .AddUnmatched("id", "pf-random-id-1")
                .Add(p => p.ChildContent, value)
            )
        );
        
        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-chip-group""
>
  <div
    class=""pf-c-chip-group__main""
  >
    <ul
      aria-label=""Chip group category""
      class=""pf-c-chip-group__list""
      role=""list""
    >
      <li
        class=""pf-c-chip-group__list-item""
      >
        <div
          class=""pf-c-chip""
        >
          <span
            class=""pf-c-chip__text""
            id=""pf-random-id-1""
          >
            1.1
          </span>
          <button
            aria-disabled=""false""
            aria-label=""close""
            aria-labelledby=""remove_pf-random-id-1 pf-random-id-1""
            class=""pf-c-button pf-m-plain""
            id=""remove_pf-random-id-1""
            type=""button""
          >
            <svg
              style=""vertical-align: -0.125em;""
              fill=""currentColor""
              height=""1em""
              width=""1em""
              viewBox=""{TimesIcon.IconDefinition.ViewBox}""
              aria-hidden=""true""
              role=""img""
            >
              <path d=""{TimesIcon.IconDefinition.SvgPath}""></path>
            </svg>
          </button>
        </div>
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
        var cut = ctx.RenderComponent<ChipGroup<string>>(parameters => parameters
            .AddUnmatched("id", "pf-random-id-2")
            .Add(p => p.CategoryName, "category")
            .Add(p => p.Items, items)
            .Add<Chip, string>(p => p.ItemTemplate, value => itemparams => itemparams
                .AddUnmatched("id", "pf-random-id-3")
                .Add(p => p.ChildContent, value)
            )
        );
        
        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-chip-group pf-m-category""
>
  <div
    class=""pf-c-chip-group__main""
  >
    <span
      aria-hidden=""true""
      class=""pf-c-chip-group__label""
      id=""pf-random-id-2""
    >
      category
    </span>
    <ul
      aria-labelledby=""pf-random-id-2""
      class=""pf-c-chip-group__list""
      role=""list""
    >
      <li
        class=""pf-c-chip-group__list-item""
      >
        <div
          class=""pf-c-chip""
        >
          <span
            class=""pf-c-chip__text""
            id=""pf-random-id-3""
          >
            1.1
          </span>
          <button
            aria-disabled=""false""
            aria-label=""close""
            aria-labelledby=""remove_pf-random-id-3 pf-random-id-3""
            class=""pf-c-button pf-m-plain""
            id=""remove_pf-random-id-3""
            type=""button""
          >
            <svg
              style=""vertical-align: -0.125em;""
              fill=""currentColor""
              height=""1em""
              width=""1em""
              viewBox=""{TimesIcon.IconDefinition.ViewBox}""
              aria-hidden=""true""
              role=""img""
            >
              <path d=""{TimesIcon.IconDefinition.SvgPath}""></path>
            </svg>
          </button>
        </div>
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
        var cut = ctx.RenderComponent<ChipGroup<string>>(parameters => parameters
            .AddUnmatched("id", "pf-random-id-2")
            .Add(p => p.CategoryName, "category")
            .Add(p => p.IsClosable, true)
            .Add(p => p.Items, items)
            .Add<Chip, string>(p => p.ItemTemplate, value => itemparams => itemparams
                .AddUnmatched("id", "pf-random-id-3")
                .Add(p => p.ChildContent, value)
            )
        );
        
        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-chip-group pf-m-category""
>
  <div
    class=""pf-c-chip-group__main""
  >
    <span
      aria-hidden=""true""
      class=""pf-c-chip-group__label""
      id=""pf-random-id-2""
    >
      category
    </span>
    <ul
      aria-labelledby=""pf-random-id-2""
      class=""pf-c-chip-group__list""
      role=""list""
    >
      <li
        class=""pf-c-chip-group__list-item""
      >
        <div
          class=""pf-c-chip""
        >
          <span
            class=""pf-c-chip__text""
            id=""pf-random-id-3""
          >
            1.1
          </span>
          <button
            aria-disabled=""false""
            aria-label=""close""
            aria-labelledby=""remove_pf-random-id-3 pf-random-id-3""
            class=""pf-c-button pf-m-plain""
            id=""remove_pf-random-id-3""
            type=""button""
          >
            <svg
              style=""vertical-align: -0.125em;""
              fill=""currentColor""
              height=""1em""
              width=""1em""
              viewBox=""{TimesIcon.IconDefinition.ViewBox}""
              aria-hidden=""true""
              role=""img""
            >
              <path d=""{TimesIcon.IconDefinition.SvgPath}""></path>
            </svg>
          </button>
        </div>
      </li>
    </ul>
  </div>
  <div
    class=""pf-c-chip-group__close""
  >
    <button
      aria-disabled=""false""
      aria-label=""Close chip group""
      aria-labelledby=""remove_group_pf-random-id-2 pf-random-id-2""
      class=""pf-c-button pf-m-plain""
      id=""remove_group_pf-random-id-2""
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
        <path d=""{TimesCircleIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </button>
  </div>
</div>
");
    }
    
    [Fact]
    public void ExpandedTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var items = new[] { "1", "2", "3", "4" }; 

        // Ac
        var cut = ctx.RenderComponent<ChipGroup<string>>(parameters => parameters
            .Add(p => p.Items, items)
            .Add<Chip, string>(p => p.ItemTemplate, value => itemparams => itemparams
                .AddUnmatched("id", $"pf-random-id-{value}")
                .Add(p => p.ChildContent, value)
            )
        );
        
        // Assert
        cut.MarkupMatches(
$@"
<div class=""pf-c-chip-group"">
  <div class=""pf-c-chip-group__main"">
    <ul class=""pf-c-chip-group__list"" aria-label=""Chip group category"" role=""list"">
      <li class=""pf-c-chip-group__list-item"">
        <div class=""pf-c-chip"" >
          <span class=""pf-c-chip__text"" id=""pf-random-id-1"">1</span>
          <button
            id=""remove_pf-random-id-1""
            aria-labelledby=""remove_pf-random-id-1 pf-random-id-1""
            aria-disabled=""false""
            aria-label=""close""
            class=""pf-c-button pf-m-plain""
            type=""button""
          >
            <svg
              style=""vertical-align: -0.125em;""
              fill=""currentColor""
              height=""1em""
              width=""1em""
              viewBox=""{TimesIcon.IconDefinition.ViewBox}""
              aria-hidden=""true""
              role=""img""
            >
              <path d=""{TimesIcon.IconDefinition.SvgPath}""></path>
            </svg>
          </button>
        </div>
      </li>
      <li class=""pf-c-chip-group__list-item"">
        <div class=""pf-c-chip"">
          <span class=""pf-c-chip__text"" id=""pf-random-id-2"">2</span>
          <button
            id=""remove_pf-random-id-2""
            aria-labelledby=""remove_pf-random-id-2 pf-random-id-2""
            aria-disabled=""false""
            aria-label=""close""
            class=""pf-c-button pf-m-plain""
            type=""button""
          >
            <svg
              style=""vertical-align: -0.125em;""
              fill=""currentColor""
              height=""1em""
              width=""1em""
              viewBox=""{TimesIcon.IconDefinition.ViewBox}""
              aria-hidden=""true""
              role=""img""
            >
              <path d=""{TimesIcon.IconDefinition.SvgPath}""></path>
            </svg>
          </button>
        </div>
      </li>
      <li class=""pf-c-chip-group__list-item"">
        <div class=""pf-c-chip"">
          <span class=""pf-c-chip__text"" id=""pf-random-id-3"">3</span>
          <button
            id=""remove_pf-random-id-3""
            aria-labelledby=""remove_pf-random-id-3 pf-random-id-3""
            aria-disabled=""false""
            aria-label=""close""
            class=""pf-c-button pf-m-plain""
            type=""button""
          >
            <svg
              style=""vertical-align: -0.125em;""
              fill=""currentColor""
              height=""1em""
              width=""1em""
              viewBox=""{TimesIcon.IconDefinition.ViewBox}""
              aria-hidden=""true""
              role=""img""
            >
              <path d=""{TimesIcon.IconDefinition.SvgPath}""></path>
            </svg>
          </button>
        </div>
      </li>
      <li class=""pf-c-chip-group__list-item"">
        <button class=""pf-c-chip pf-m-overflow"" type=""button"">
          <span class=""pf-c-chip__text"">1 more</span>
        </button>
      </li>
    </ul>
  </div>
</div>
");
    }
    
    [Fact]
    public void EmptyTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var items = Array.Empty<string>(); 

        // Ac
        var cut = ctx.RenderComponent<ChipGroup<string>>();
        
        // Assert
        cut.MarkupMatches(@"");
    }
}
