namespace Blatternfly.UnitTests.Components;

public class TextInputGroupUtilitiesTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<TextInputGroupUtilities>(properties => properties
            .AddChildContent("<button>Test</button>")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-text-input-group__utilities""
>
  <button>
    Test
  </button>
</div>
");
    }
}
