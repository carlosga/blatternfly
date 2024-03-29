﻿namespace Blatternfly.UnitTests.Components;

public class CardHeaderTests
{
    [Fact]
    public void DefaultCardTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<CardTitle>();

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-card__title""
/>
");
    }

    [Fact]
    public void CustomClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<CardTitle>(parameters => parameters
            .AddUnmatched("class", "extra-class")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-card__title extra-class""
/>
");
    }

    [Fact]
    public void ExtraPropertiesOnRootElementTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var testId = "card-title";

        // Act
        var cut = ctx.RenderComponent<CardTitle>(parameters => parameters
            .AddUnmatched("data-testid", testId)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  data-testid=""{testId}""
  class=""pf-c-card__title""
/>
");
    }

    [Fact]
    public void OnExpandAddsToggleButton()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        Action<MouseEventArgs> onExpand = _ => { };

        // Act
        var cut = ctx.RenderComponent<Card>(parameters => parameters
            .Add<CardHeader>(p => p.ChildContent, headparams => headparams
                .Add(p => p.OnExpand, onExpand)
            )
        );

        // Assert
        cut.MarkupMatches(
$@"
<article
  class=""pf-c-card""
>
  <div
    class=""pf-c-card__header""
  >
    <div
      class=""pf-c-card__header-toggle""
    >
      <button
        aria-disabled=""false""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <span
          class=""pf-c-card__header-toggle-icon""
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
      </button>
    </div>
  </div>
</article>
");
    }
}
