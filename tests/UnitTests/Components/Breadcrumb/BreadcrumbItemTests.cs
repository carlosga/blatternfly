namespace Blatternfly.UnitTests.Components;

public class BreadcrumbItemTests
{
    [Fact]
    public void DefaultBreadcrumbItemTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<BreadcrumbItem>(parameters => parameters
            .AddChildContent("Item")
        );

        // Assert
        cut.MarkupMatches(
@"
<li
  class=""pf-c-breadcrumb__item""
>
  Item
</li>
");
    }

    [Fact]
    public void CustomCssClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<BreadcrumbItem>(parameters => parameters
            .AddUnmatched("class", "Class")
            .AddChildContent("Item")
        );

        // Assert
        cut.MarkupMatches(
@"
<li
  class=""pf-c-breadcrumb__item Class""
>
  Item
</li>
");
    }

    [Fact]
    public void CustomIdTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<BreadcrumbItem>(parameters => parameters
            .AddUnmatched("id", "Item 1")
            .AddChildContent("Item")
        );

        // Assert
        cut.MarkupMatches(
@"
<li
  id=""Item 1"" class=""pf-c-breadcrumb__item""
>
  Item
</li>
");
    }

    [Fact]
    public void ActiveItemTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<BreadcrumbItem>(parameters => parameters
            .Add(p => p.IsActive, true)
            .AddChildContent("Item")
        );

        // Assert
        cut.MarkupMatches(
@"
<li
  class=""pf-c-breadcrumb__item""
>
  Item
</li>
");
    }

    [Fact]
    public void LinkItemTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<BreadcrumbItem>(parameters => parameters
            .Add(p => p.To, "/somewhere")
            .AddChildContent("Item")
        );

        // Assert
        cut.MarkupMatches(
@"
<li
  class=""pf-c-breadcrumb__item""
>
  <a
    class=""pf-c-breadcrumb__link""
    href=""/somewhere""
  >
    Item
  </a>
</li>
");
    }

    [Fact]
    public void TargetTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<BreadcrumbItem>(parameters => parameters
            .Add(p => p.Target, "_blank")
            .AddChildContent("Item")
        );

        // Assert
        cut.MarkupMatches(
@"
<li
  class=""pf-c-breadcrumb__item""
>
    Item
</li>
");
    }

    [Fact]
    public void WithCustomElementTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<BreadcrumbItem>(parameters => parameters
            .AddChildContent<TimesIcon>()
        );

        // Assert
        cut.MarkupMatches(
$@"
<li
  class=""pf-c-breadcrumb__item""
>
  <svg
    aria-hidden=""true""
    fill=""currentColor""
    height=""1em""
    role=""img""
    style=""vertical-align: -0.125em""
    viewBox=""{TimesIcon.IconDefinition.ViewBox}""
    width=""1em""
  >
    <path d=""{TimesIcon.IconDefinition.SvgPath}""></path>
  </svg>
</li>
");
    }
}
