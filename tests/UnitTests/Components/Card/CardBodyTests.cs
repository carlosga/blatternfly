﻿namespace Blatternfly.UnitTests.Components;

public class CardBodyTests
{
    [Fact]
    public void DefaultCardTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<CardBody>();

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-card__body""
/>
");
    }

    [Fact]
    public void CustomCssClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<CardBody>(parameters => parameters
            .AddUnmatched("class", "extra-class")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-card__body extra-class""
/>
");
    }

    [Fact]
    public void ExtraPropertiesOnRootElementTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var testId = "card-body";

        // Act
        var cut = ctx.RenderComponent<CardBody>(parameters => parameters
            .AddUnmatched("data-testid", testId)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  data-testid=""{testId}""
  class=""pf-c-card__body""
/>
");
    }

    [Fact]
    public void CustomComponentTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var component = "section";

        // Act
        var cut = ctx.RenderComponent<CardBody>(parameters => parameters
            .Add(p => p.Component, "section")
        );

        // Assert
        cut.MarkupMatches(
$@"
<{component}
  class=""pf-c-card__body""
/>
");
    }

    [Fact]
    public void NoFillTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<CardBody>(parameters => parameters
            .Add(p => p.IsFilled, false)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-card__body pf-m-no-fill""
/>
");
    }
}
