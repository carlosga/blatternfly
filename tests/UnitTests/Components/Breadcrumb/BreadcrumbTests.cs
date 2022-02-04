namespace Blatternfly.UnitTests.Components;

public class BreadcrumbTests
{
    [Fact]
    public void DefaultBreadcrumbTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Breadcrumb>();

        // Assert
        cut.MarkupMatches(
@"
<nav
  aria-label=""Breadcrumb""
  class=""pf-c-breadcrumb""
>
  <ol
    class=""pf-c-breadcrumb__list""
  />
</nav>
");
    }

    [Fact]
    public void CustomCssClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Breadcrumb>(parameters => parameters
            .AddUnmatched("class", "className")
        );

        // Assert
        cut.MarkupMatches(
@"
<nav
  aria-label=""Breadcrumb""
  class=""pf-c-breadcrumb className""
>
  <ol
    class=""pf-c-breadcrumb__list""
  />
</nav>
");
    }

    [Fact]
    public void CustomAriaLabelTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Breadcrumb>(parameters => parameters
            .Add(p => p.AriaLabel, "custom label")
        );

        // Assert
        cut.MarkupMatches(
@"
<nav
  aria-label=""custom label""
  class=""pf-c-breadcrumb""
>
  <ol
    class=""pf-c-breadcrumb__list""
  />
</nav>
");
    }

    [Fact]
    public void ChildContentTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Breadcrumb>(parameters => parameters
            .AddChildContent<BreadcrumbItem>(itemparams => itemparams
                .Add(p => p.To, "#")
                .AddChildContent("Item 1")
            )
            .AddChildContent<BreadcrumbItem>(itemparams => itemparams
                .Add(p => p.To, "#")
                .AddChildContent("Item 1")
            )
        );

        // Assert
        cut.MarkupMatches(
$@"
<nav
  aria-label=""Breadcrumb""
  class=""pf-c-breadcrumb""
>
  <ol
    class=""pf-c-breadcrumb__list""
  >
    <li
      class=""pf-c-breadcrumb__item""
    >
      <a
        class=""pf-c-breadcrumb__link""
        href=""#""
      >
        Item 1
      </a>
    </li>

    <li
      class=""pf-c-breadcrumb__item""
    >
      <span
        class=""pf-c-breadcrumb__item-divider""
      >
        <svg
          aria-hidden=""true""
          fill=""currentColor""
          height=""1em""
          role=""img""
          style=""vertical-align: -0.125em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          width=""1em""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}""
          />
        </svg>
      </span>
      <a
        class=""pf-c-breadcrumb__link""
        href=""#""
      >
        Item 1
      </a>
    </li>
  </ol>
</nav>
");
    }
}
