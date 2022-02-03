namespace Blatternfly.UnitTests.Components;

public class EmptyStateIconTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<EmptyStateIcon>(parameters => parameters
            .AddUnmatched("class", "custom-empty-state-icon")
            .AddUnmatched("id"   , "empty-state-icon")
            .Add<AddressBookIcon>(p => p.ChildContent)
        );

        // Assert
        cut.MarkupMatches(
$@"
<svg
  id=""empty-state-icon""
  class=""pf-c-empty-state__icon custom-empty-state-icon""
  style=""vertical-align: -0.125em;""
  fill=""currentColor""
  height=""1em""
  width=""1em""
  viewBox=""{AddressBookIcon.IconDefinition.ViewBox}""
  aria-hidden=""true""
  role=""img""
>
  <path d=""{AddressBookIcon.IconDefinition.SvgPath}""></path>
</svg>
");
    }

    [Fact]
    public void WrapIconInDiv()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<EmptyStateIcon>(parameters => parameters
            .AddUnmatched("class", "custom-empty-state-icon")
            .AddUnmatched("id"   , "empty-state-icon")
            .Add(p => p.Variant, EmptyStateIconVariant.Container)
            .Add<AddressBookIcon>(p => p.ChildContent)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  id=""empty-state-icon""
  class=""pf-c-empty-state__icon custom-empty-state-icon""
>
    <svg
      style=""vertical-align: -0.125em;""
      fill=""currentColor""
      height=""1em""
      width=""1em""
      viewBox=""{AddressBookIcon.IconDefinition.ViewBox}""
      aria-hidden=""true""
      role=""img""
    >
      <path d=""{AddressBookIcon.IconDefinition.SvgPath}""></path>
    </svg>
</div>
");
    }
}
