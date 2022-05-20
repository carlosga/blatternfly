namespace Blatternfly.UnitTests.Components;

public class ChipTests
{
    [Fact]
    public void OverflowTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Chip>(parameters => parameters
            .AddUnmatched("class", "my-chp-cls")
            .Add(p => p.IsOverflowChip, true)
            .AddChildContent("4 more")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-chip pf-m-overflow my-chp-cls""
>
  <span
    class=""pf-c-chip__text""
  >
    4 more
  </span>
</div>
");
    }

    [Fact]
    public void ClosableTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Chip>(parameters => parameters
            .AddUnmatched("class", "my-chp-cls")
            .AddUnmatched("id", "chip_one")
            .AddChildContent("Chip")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-chip my-chp-cls""
>
  <span
    class=""pf-c-chip__text""
    id=""chip_one""
  >
    Chip
  </span>
  <button
    aria-disabled=""false""
    aria-label=""close""
    aria-labelledby=""remove_chip_one chip_one""
    class=""pf-c-button pf-m-plain""
    id=""remove_chip_one""
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
");
    }

    [Fact]
    public void ReadonlyTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Chip>(parameters => parameters
            .AddUnmatched("class", "my-chp-cls")
            .AddUnmatched("id", "chip_one")
            .Add(p => p.IsReadOnly, true)
            .AddChildContent("4 more")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-chip my-chp-cls""
>
  <span
    class=""pf-c-chip__text""
    id=""chip_one""
  >
    4 more
  </span>
</div>
");
    }

    [Fact]
    public void CustomMaxWidthTextTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Chip>(parameters => parameters
            .AddUnmatched("class", "my-chp-cls")
            .Add(p => p.TextMaxWidth, "100px")
            .AddChildContent("4 more")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-chip my-chp-cls""
  style=""--pf-c-chip__text--MaxWidth: 100px;""
>
  <span
    class=""pf-c-chip__text""
    id=""pf-c-chip-1""
  >
    4 more
  </span>
  <button
    aria-disabled=""false""
    aria-label=""close""
    aria-labelledby=""remove_pf-c-chip-1 pf-c-chip-1""
    class=""pf-c-button pf-m-plain""
    id=""remove_pf-c-chip-1""
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
");
    }
}
