namespace Blatternfly.UnitTests.Components;

public class TextInputGroupTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<TextInputGroup>(properties => properties
            .AddChildContent("Test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-text-input-group""
>
  Test
</div>
");
    }

    [Fact]
    public void IsDisabledTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<TextInputGroup>(properties => properties
            .Add(p => p.IsDisabled, true)
            .Add<TextInputGroupMain>(p => p.ChildContent)
        );

        // Assert
        cut.MarkupMatches(
@"
<div class=""pf-c-text-input-group pf-m-disabled"">
  <div class=""pf-c-text-input-group__main"">
    <span class=""pf-c-text-input-group__text"">
      <input type=""text"" class=""pf-c-text-input-group__text-input"" aria-label=""Type to filter"" disabled="""">
    </span>
  </div>
</div>
");
    }
}
