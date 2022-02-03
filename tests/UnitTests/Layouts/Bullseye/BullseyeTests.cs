namespace Blatternfly.UnitTests.Layouts;
public class BullseyeTests
{
    [Fact]
    public void CoreStylesTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Bullseye>();

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-l-bullseye""
/>
");
    }

    [Fact]
    public void CustomCssClassOnRootElementTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Bullseye>(parameters => parameters
            .AddUnmatched("class", "extra-class")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-l-bullseye extra-class""
/>
");
    }

    [Fact]
    public void ExtraPropsSpreadToTheRootElementTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var testId = "bullseye";

        // Act
        var cut = ctx.RenderComponent<Bullseye>(parameters => parameters
            .AddUnmatched("data-testid", testId)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-l-bullseye"" data-testid=""{testId}""
/>
");
    }

    [Fact]
    public void CustomComponentTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var component = "span";

        // Act
        var cut = ctx.RenderComponent<Bullseye>(parameters => parameters
            .Add(p => p.Component, component)
        );

        // Assert
        cut.MarkupMatches(
$@"
<{component}
  class=""pf-l-bullseye""
/>
");
    }

    [Fact]
    public void ChildContentTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Bullseye>(parameters => parameters
            .AddChildContent("Bullseye")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-l-bullseye""
>
  Bullseye
</div>
");
        }
    }
