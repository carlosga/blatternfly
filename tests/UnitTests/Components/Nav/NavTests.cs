using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class NavItemInfo
    {
        public string To { get; set; }
        public string Label { get; set; }
    }
    
    public class NavTests
    {
        private static readonly NavItemInfo[] s_items = 
        {
            new() { To = "#link1", Label = "Link 1" },
            new() { To = "#link2", Label = "Link 2" },
            new() { To = "#link3", Label = "Link 3" },
            new() { To = "#link4", Label = "Link 4" }
        };
        
        [Fact]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Nav>(parameters => parameters
                .AddUnmatched("class", "test=nav-class")
                .Add<NavList>(p => p.ChildContent, listparams => listparams
                    .AddUnmatched("class", "test-nav-list-class")
                    .AddItems(s_items)
                )
            );

            // Assert
            cut.MarkupMatches(
@"
<nav
  aria-label=""Global""
  class=""pf-c-nav test=nav-class""
>
  <ul
    class=""pf-c-nav__list test-nav-list-class""
  >
    <li
      class=""pf-c-nav__item test-nav-item-class""
    >
      <a
        class=""pf-c-nav__link test-nav-item-class""
        href=""#link1""
      >
        Link 1
      </a>
    </li>
    <li
      class=""pf-c-nav__item test-nav-item-class""
    >
      <a
        class=""pf-c-nav__link test-nav-item-class""
        href=""#link2""
      >
        Link 2
      </a>
    </li>
    <li
      class=""pf-c-nav__item test-nav-item-class""
    >
      <a
        class=""pf-c-nav__link test-nav-item-class""
        href=""#link3""
      >
        Link 3
      </a>
    </li>
    <li
      class=""pf-c-nav__item test-nav-item-class""
    >
      <a
        class=""pf-c-nav__link test-nav-item-class""
        href=""#link4""
      >
        Link 4
      </a>
    </li>
  </ul>
</nav>
");
        }        
    }
}
