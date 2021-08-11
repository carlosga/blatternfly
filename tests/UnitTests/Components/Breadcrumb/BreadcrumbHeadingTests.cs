using System.Collections.Generic;
using Bunit;
using Xunit;
using Blatternfly.Components;

namespace Blatternfly.UnitTests.Components
{
    public class BreadcrumbHeadingTests
    {
        [Fact]
        public void DefaultBreadcrumbHeadingTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<BreadcrumbHeading>(parameters => parameters
                .AddChildContent("Item")
            );

            // Assert
            cut.MarkupMatches(
@"
<li
  class=""pf-c-breadcrumb__item""
>
  <h1
    class=""pf-c-breadcrumb__heading""
  >
    Item
  </h1>
</li>
");
        }
        
        [Fact]
        public void CustomCssClassTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<BreadcrumbHeading>(parameters => parameters
                .AddUnmatched("class", "Class")
                .AddChildContent("Item")
            );

            // Assert
            cut.MarkupMatches(
@"
<li
  class=""pf-c-breadcrumb__item Class""
>
  <h1
    class=""pf-c-breadcrumb__heading""
  >
    Item
  </h1>
</li>
");
        }   
        
        [Fact]
        public void CustomIdTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<BreadcrumbHeading>(parameters => parameters
                .AddUnmatched("id", "Id")
                .AddChildContent("Item")
            );

            // Assert
            cut.MarkupMatches(
@"
<li
  id=""Id""
  class=""pf-c-breadcrumb__item""
>
  <h1
    class=""pf-c-breadcrumb__heading""
  >
    Item
  </h1>
</li>
");
        }
        
        [Fact]
        public void DefaultLinkTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<BreadcrumbHeading>(parameters => parameters
                .Add(p => p.To, "/somewhere")
                .AddChildContent("Item")
            );

            // Assert
            cut.MarkupMatches(
@"
<li
  class=""pf-c-breadcrumb__item""
>
  <h1
    class=""pf-c-breadcrumb__heading""
  >
    <a
      aria-current=""page""
      class=""pf-c-breadcrumb__link pf-m-current""
      href=""/somewhere""
    >
      Item
    </a>
  </h1>
</li>
");
        }
        
        [Fact]
        public void LinkTargetTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<BreadcrumbHeading>(parameters => parameters
                .Add(p => p.To, "/somewhere")
                .Add(p => p.Target, "_blank")
                .AddChildContent("Item")
            );

            // Assert
            cut.MarkupMatches(
                @"
<li
  class=""pf-c-breadcrumb__item""
>
  <h1
    class=""pf-c-breadcrumb__heading""
  >
    <a
      aria-current=""page""
      class=""pf-c-breadcrumb__link pf-m-current""
      href=""/somewhere""
      target=""_blank""
    >
      Item
    </a>
  </h1>
</li>
");
        }        
    }
}
