namespace Blatternfly.UnitTests.Components;

public class LoginFooterItemTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<LoginFooterItem>(parameters => parameters
            .Add(p => p.Href, "#")
            .Add(p => p.Target, "_self")
        );

        // Assert
        cut.MarkupMatches(
@"
<a
  href=""#""
  target=""_self""
/>
");
    }

    [Fact]
    public void WithAdditionalCssClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<LoginFooterItem>(parameters => parameters
            .AddUnmatched("class", "extra-class")

        );

        // Assert
        cut.MarkupMatches(
@"
<a
  class=""extra-class""
  href=""#""
  target=""_blank""
/>
");
    }

    [Fact]
    public void WithAdditionalPropertiesOnRootElementTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var testId = "login-body";

        // Act
        var cut = ctx.RenderComponent<LoginFooterItem>(parameters => parameters
            .AddUnmatched("data-testid", testId)

        );

        // Assert
        cut.MarkupMatches(
@$"
<a
  href=""#""
  target=""_blank""
  data-testid=""{testId}""
/>
");
    }

    [Fact]
    public void WithChildContentTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<LoginFooterItem>(parameters => parameters
            .AddChildContent("<div>My custom node</div>")

        );

        // Assert
        cut.MarkupMatches(
@"
<a
  href=""#""
  target=""_blank""
>
  <div>My custom node</div>
</a>
");
    }
}
