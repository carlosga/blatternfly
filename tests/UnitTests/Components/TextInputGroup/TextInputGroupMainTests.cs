namespace Blatternfly.UnitTests.Components;

public class TextInputGroupMainTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<TextInputGroupMain>(properties => properties
            .AddChildContent("Test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-text-input-group__main""
>
  Test
  <span
    class=""pf-c-text-input-group__text""
  >
    <input
      aria-label=""Type to filter""
      class=""pf-c-text-input-group__text-input""
      type=""text""
    />
  </span>
</div>
");
    }

    [Fact]
    public void WithAHintTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<TextInputGroupMain>(properties => properties
            .Add(p => p.Type, TextInputTypes.Search)
            .Add(p => p.Hint, "Test")
            .AddChildContent("Test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-text-input-group__main""
>
  Test
  <span
    class=""pf-c-text-input-group__text""
  >
    <input
      class=""pf-c-text-input-group__text-input pf-m-hint""
      type=""text""
      disabled=""""
      aria-hidden=""true""
      value=""Test""
    />
    <input
      aria-label=""Type to filter""
      class=""pf-c-text-input-group__text-input""
      type=""search""
    />
  </span>
</div>
");
    }
}
