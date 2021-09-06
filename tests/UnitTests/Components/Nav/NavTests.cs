using Blatternfly.Components;
using Blatternfly.Interop;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
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
            
            // Setup Javascript interop
            ctx.SetupJavascriptInterop();

            // Act
            var cut = ctx.RenderComponent<Nav>(parameters => parameters
                .AddUnmatched("class", "test=nav-class")
                .Add<NavList>(p => p.ChildContent, listparams => listparams
                    .AddUnmatched("class", "test-nav-list-class")
                    .AddItems(s_items, "test-nav-item-class")
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
        
        [Theory]
        [InlineData(ThemeVariant.Dark)]
        [InlineData(ThemeVariant.Light)]
        public void ThemeTest(ThemeVariant theme)
        {
            // Arrange
            using var ctx = new TestContext();
            var themeClass = theme == ThemeVariant.Light ? "pf-m-light" : null;


            // Setup Javascript interop
            ctx.SetupJavascriptInterop();
            
            // Act
            var cut = ctx.RenderComponent<Nav>(parameters => parameters
                .AddUnmatched("class", "test=nav-class")
                .Add(p => p.Theme, theme)
                .Add<NavList>(p => p.ChildContent, listparams => listparams
                    .AddUnmatched("class", "test-nav-list-class")
                    .AddItems(s_items, "test-nav-item-class")
                )
            );

            // Assert
            cut.MarkupMatches(
@$"
<nav
  aria-label=""Global""
  class=""pf-c-nav {themeClass} test=nav-class""
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

        [Fact]
        public void ExpandableNavListTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Setup Javascript interop
            ctx.SetupJavascriptInterop();

            // Act
            var cut = ctx.RenderComponent<Nav>(parameters => parameters
                .Add<NavList>(p => p.ChildContent, listparams => listparams
                    .Add<NavExpandable>(p => p.ChildContent, expandableparams => expandableparams
                        .AddUnmatched("id", "grp-1")
                        .Add(p => p.Title, "Section 1")
                        .AddItems(s_items)
                    )
                )
            );

            // Assert
            cut.MarkupMatches(
@$"
<nav 
  class=""pf-c-nav"" 
  aria-label=""Global"" 
>
  <ul class=""pf-c-nav__list"">
    <li 
      class=""pf-c-nav__item pf-m-expandable"" 
    >
      <button 
        class=""pf-c-nav__link"" 
        id=""grp-1""
        aria-expanded=""false""
      >
        Section 1
        <span class=""pf-c-nav__toggle"">
          <span class=""pf-c-nav__toggle-icon"">            
            <svg
              style=""vertical-align: -0.125em;"" 
              fill=""currentColor"" 
              height=""1em"" 
              width=""1em"" 
              viewBox=""{AngleRightIcon.IconDefinition.ViewBox}"" 
              aria-hidden=""true"" 
              role=""img""
            >
              <path d=""{AngleRightIcon.IconDefinition.SvgPath}""></path>
            </svg>
          </span>
        </span>
      </button>
      <section class=""pf-c-nav__subnav"" aria-labelledby=""grp-1"" hidden="""">
        <ul class=""pf-c-nav__list"">
          <li class=""pf-c-nav__item""><a href=""#link1"" class=""pf-c-nav__link"">Link 1</a></li>
          <li class=""pf-c-nav__item""><a href=""#link2"" class=""pf-c-nav__link"">Link 2</a></li>
          <li class=""pf-c-nav__item""><a href=""#link3"" class=""pf-c-nav__link"">Link 3</a></li>
          <li class=""pf-c-nav__item""><a href=""#link4"" class=""pf-c-nav__link"">Link 4</a></li>
        </ul>
      </section>
    </li>
  </ul>
</nav>
");
        }        

        [Fact]
        public void ExpandableNavListWithAriaLabelTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Setup Javascript interop
            ctx.SetupJavascriptInterop();

            // Act
            var cut = ctx.RenderComponent<Nav>(parameters => parameters
                .Add(p => p.AriaLabel, "Test")
                .Add<NavList>(p => p.ChildContent, listparams => listparams
                    .Add<NavExpandable>(p => p.ChildContent, expandableparams => expandableparams
                        .AddUnmatched("id", "grp-1")
                        .Add(p => p.Title, "Section 1")
                        .Add(p => p.SrText, "Section 1 - Example sub-navigation")
                        .AddItems(s_items)
                    )
                )
            );

            // Assert
            cut.MarkupMatches(
@$"
<nav 
  class=""pf-c-nav"" 
  aria-label=""Test""
>
  <ul class=""pf-c-nav__list"">
    <li 
      class=""pf-c-nav__item pf-m-expandable"" 
    >
      <button 
        class=""pf-c-nav__link"" 
        aria-expanded=""false""
      >
        Section 1
        <span class=""pf-c-nav__toggle"">
          <span class=""pf-c-nav__toggle-icon"">            
            <svg
              style=""vertical-align: -0.125em;"" 
              fill=""currentColor"" 
              height=""1em"" 
              width=""1em"" 
              viewBox=""{AngleRightIcon.IconDefinition.ViewBox}"" 
              aria-hidden=""true"" 
              role=""img""
            >
              <path d=""{AngleRightIcon.IconDefinition.SvgPath}""></path>
            </svg>
          </span>
        </span>
      </button>
      <section class=""pf-c-nav__subnav"" aria-labelledby=""grp-1"" hidden="""">
        <h2 class=""pf-u-screen-reader"" id=""grp-1"">Section 1 - Example sub-navigation</h2>
        <ul class=""pf-c-nav__list"">
          <li class=""pf-c-nav__item""><a href=""#link1"" class=""pf-c-nav__link"">Link 1</a></li>
          <li class=""pf-c-nav__item""><a href=""#link2"" class=""pf-c-nav__link"">Link 2</a></li>
          <li class=""pf-c-nav__item""><a href=""#link3"" class=""pf-c-nav__link"">Link 3</a></li>
          <li class=""pf-c-nav__item""><a href=""#link4"" class=""pf-c-nav__link"">Link 4</a></li>
        </ul>
      </section>
    </li>
  </ul>
</nav>
");
        }
        
        [Fact]
        public void NavGroupedListTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Setup Javascript interop
            ctx.SetupJavascriptInterop();

            // Act
            var cut = ctx.RenderComponent<Nav>(parameters => parameters
                .Add<NavGroup>(p => p.ChildContent, groupparams1 => groupparams1
                    .AddUnmatched("id", "grp-1")
                    .Add(p => p.Title, "Section 1")
                    .Add<NavList>(p => p.ChildContent, listparams => listparams
                        .AddItems(s_items)
                    )
                )
                .Add<NavGroup>(p => p.ChildContent, groupparams1 => groupparams1
                    .AddUnmatched("id", "grp-2")
                    .Add(p => p.Title, "Section 2")
                    .Add<NavList>(p => p.ChildContent, listparams => listparams
                        .AddItems(s_items)
                    )
                )
            );

            // Assert
            cut.MarkupMatches(
@"
<nav 
  class=""pf-c-nav"" 
  aria-label=""Global"" 
>
  <section class=""pf-c-nav__section"" aria-labelledby=""grp-1"">
    <h2 class=""pf-c-nav__section-title"" id=""grp-1"">Section 1</h2>
    <ul class=""pf-c-nav__list"">
      <ul class=""pf-c-nav__list"">
        <li class=""pf-c-nav__item""><a href=""#link1"" class=""pf-c-nav__link"">Link 1</a></li>
        <li class=""pf-c-nav__item""><a href=""#link2"" class=""pf-c-nav__link"">Link 2</a></li>
        <li class=""pf-c-nav__item""><a href=""#link3"" class=""pf-c-nav__link"">Link 3</a></li>
        <li class=""pf-c-nav__item""><a href=""#link4"" class=""pf-c-nav__link"">Link 4</a></li>
      </ul>
    </ul>
  </section>
  <section class=""pf-c-nav__section"" aria-labelledby=""grp-2"">
    <h2 class=""pf-c-nav__section-title"" id=""grp-2"">Section 2</h2>
    <ul class=""pf-c-nav__list"">
      <ul class=""pf-c-nav__list"">
        <li class=""pf-c-nav__item""><a href=""#link1"" class=""pf-c-nav__link"">Link 1</a></li>
        <li class=""pf-c-nav__item""><a href=""#link2"" class=""pf-c-nav__link"">Link 2</a></li>
        <li class=""pf-c-nav__item""><a href=""#link3"" class=""pf-c-nav__link"">Link 3</a></li>
        <li class=""pf-c-nav__item""><a href=""#link4"" class=""pf-c-nav__link"">Link 4</a></li>
      </ul>
    </ul>
  </section>
</nav>
");
        }        
        
        [Fact]
        public void HorizontalNavListTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Setup Javascript interop
            ctx.SetupJavascriptInterop();

            // Act
            var cut = ctx.RenderComponent<Nav>(parameters => parameters
                .Add(p => p.Variant, NavVariant.Horizontal)
                .Add<NavList>(p => p.ChildContent, listparams => listparams
                    .AddItems(s_items)
                )
            );

            // Assert
            cut.MarkupMatches(
@$"
<nav
  class=""pf-c-nav pf-m-horizontal""
  aria-label=""Global""
>
  <button
    class=""pf-c-nav__scroll-button""
    aria-label=""Scroll left""
  >
    <svg
      style=""vertical-align: -0.125em;"" 
      fill=""currentColor"" 
      height=""1em"" 
      width=""1em"" 
      viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}"" 
      aria-hidden=""true"" 
      role=""img""
    >
      <path d=""{AngleLeftIcon.IconDefinition.SvgPath}""></path>
    </svg>  
  </button>
  <ul class=""pf-c-nav__list"">
    <li class=""pf-c-nav__item""><a href=""#link1"" class=""pf-c-nav__link"">Link 1</a></li>
    <li class=""pf-c-nav__item""><a href=""#link2"" class=""pf-c-nav__link"">Link 2</a></li>
    <li class=""pf-c-nav__item""><a href=""#link3"" class=""pf-c-nav__link"">Link 3</a></li>
    <li class=""pf-c-nav__item""><a href=""#link4"" class=""pf-c-nav__link"">Link 4</a></li>
  </ul>
  <button
    class=""pf-c-nav__scroll-button""
    aria-label=""Scroll right""
  >
    <svg
      style=""vertical-align: -0.125em;"" 
      fill=""currentColor"" 
      height=""1em"" 
      width=""1em"" 
      viewBox=""{AngleRightIcon.IconDefinition.ViewBox}"" 
      aria-hidden=""true"" 
      role=""img""
    >
      <path d=""{AngleRightIcon.IconDefinition.SvgPath}""></path>
    </svg>      
  </button>
</nav>
");
        }

        [Fact]
        public void HorizontalSubNavListTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Setup Javascript interop
            ctx.SetupJavascriptInterop();

            // Act
            var cut = ctx.RenderComponent<Nav>(parameters => parameters
                .Add(p => p.Variant, NavVariant.HorizontalSubNav)
                .Add<NavList>(p => p.ChildContent, listparams => listparams
                    .AddItems(s_items)
                )
            );

            // Assert
            cut.MarkupMatches(
                @$"
<nav
  class=""pf-c-nav pf-m-horizontal pf-m-horizontal-subnav""
  aria-label=""Global""
>
  <button
    class=""pf-c-nav__scroll-button""
    aria-label=""Scroll left""
  >
    <svg
      style=""vertical-align: -0.125em;"" 
      fill=""currentColor"" 
      height=""1em"" 
      width=""1em"" 
      viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}"" 
      aria-hidden=""true"" 
      role=""img""
    >
      <path d=""{AngleLeftIcon.IconDefinition.SvgPath}""></path>
    </svg>  
  </button>
  <ul class=""pf-c-nav__list"">
    <li class=""pf-c-nav__item""><a href=""#link1"" class=""pf-c-nav__link"">Link 1</a></li>
    <li class=""pf-c-nav__item""><a href=""#link2"" class=""pf-c-nav__link"">Link 2</a></li>
    <li class=""pf-c-nav__item""><a href=""#link3"" class=""pf-c-nav__link"">Link 3</a></li>
    <li class=""pf-c-nav__item""><a href=""#link4"" class=""pf-c-nav__link"">Link 4</a></li>
  </ul>
  <button
    class=""pf-c-nav__scroll-button""
    aria-label=""Scroll right""
  >
    <svg
      style=""vertical-align: -0.125em;"" 
      fill=""currentColor"" 
      height=""1em"" 
      width=""1em"" 
      viewBox=""{AngleRightIcon.IconDefinition.ViewBox}"" 
      aria-hidden=""true"" 
      role=""img""
    >
      <path d=""{AngleRightIcon.IconDefinition.SvgPath}""></path>
    </svg>      
  </button>
</nav>
");
        }

        [Fact]
        public void TertiaryNavListTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Setup Javascript interop
            ctx.SetupJavascriptInterop();

            // Act
            var cut = ctx.RenderComponent<Nav>(parameters => parameters
                .Add(p => p.Variant, NavVariant.Tertiary)
                .Add<NavList>(p => p.ChildContent, listparams => listparams
                    .AddItems(s_items)
                )
            );

            // Assert
            cut.MarkupMatches(
@$"
<nav
  class=""pf-c-nav pf-m-horizontal pf-m-tertiary""
  aria-label=""Local""
>
  <button
    class=""pf-c-nav__scroll-button""
    aria-label=""Scroll left""
  >
    <svg
      style=""vertical-align: -0.125em;"" 
      fill=""currentColor"" 
      height=""1em"" 
      width=""1em"" 
      viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}"" 
      aria-hidden=""true"" 
      role=""img""
    >
      <path d=""{AngleLeftIcon.IconDefinition.SvgPath}""></path>
    </svg>  
  </button>
  <ul class=""pf-c-nav__list"">
    <li class=""pf-c-nav__item""><a href=""#link1"" class=""pf-c-nav__link"">Link 1</a></li>
    <li class=""pf-c-nav__item""><a href=""#link2"" class=""pf-c-nav__link"">Link 2</a></li>
    <li class=""pf-c-nav__item""><a href=""#link3"" class=""pf-c-nav__link"">Link 3</a></li>
    <li class=""pf-c-nav__item""><a href=""#link4"" class=""pf-c-nav__link"">Link 4</a></li>
  </ul>
  <button
    class=""pf-c-nav__scroll-button""
    aria-label=""Scroll right""
  >
    <svg
      style=""vertical-align: -0.125em;"" 
      fill=""currentColor"" 
      height=""1em"" 
      width=""1em"" 
      viewBox=""{AngleRightIcon.IconDefinition.ViewBox}"" 
      aria-hidden=""true"" 
      role=""img""
    >
      <path d=""{AngleRightIcon.IconDefinition.SvgPath}""></path>
    </svg>      
  </button>
</nav>");
        }
    }
}
