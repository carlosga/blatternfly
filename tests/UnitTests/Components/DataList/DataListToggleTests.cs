namespace Blatternfly.UnitTests.Components;

public class DataListToggleTests
{
    [Fact]
    public void WithAriaLabel()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<DataListToggle>(parameters => parameters
            .Add(p => p.AriaLabel, "Toggle details for")
            .Add(p => p.Id, "ex-toggle2")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-data-list__item-control""
>
  <div
    class=""pf-c-data-list__toggle""
  >
    <button
      id=""ex-toggle2""
      aria-controls=""false""
      aria-expanded=""false""
      aria-disabled=""false""
      aria-label=""Toggle details for""
      class=""pf-c-button pf-m-plain""
      type=""button""
    >
      <div
        class=""pf-c-data-list__toggle-icon""
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
      </div>
    </button>
  </div>
</div>
");
    }

    [Fact]
    public void IsExpandedTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<DataListToggle>(parameters => parameters
            .Add(p => p.AriaLabel, "Toggle details for")
            .Add(p => p.Id, "ex-toggle2")
            .Add(p => p.IsExpanded, true)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-data-list__item-control""
>
  <div
    class=""pf-c-data-list__toggle""
  >
    <button
      id=""ex-toggle2""
      aria-controls=""false""
      aria-expanded=""true""
      aria-disabled=""false""
      aria-label=""Toggle details for""
      class=""pf-c-button pf-m-plain""
      type=""button""
    >
      <div
        class=""pf-c-data-list__toggle-icon""
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
      </div>
    </button>
  </div>
</div>
");
    }
}
