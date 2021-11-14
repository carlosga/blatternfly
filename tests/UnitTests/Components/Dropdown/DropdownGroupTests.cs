namespace Blatternfly.UnitTests.Components;

public class DropdownGroupTests
{
    [Fact]
    public void DefaultDropdownGroupTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<DropdownGroup>(parameters => parameters
            .Add(p => p.Label, "Group 1")
            .AddChildContent("Something")
        );

        // Assert
        cut.MarkupMatches(
@"
<section class=""pf-c-dropdown__group"">
  <h1 
    class=""pf-c-dropdown__group-title"" 
    aria-hidden=""true""
  >
    Group 1
  </h1>
  <ul role=""none"">
    Something
  </ul>
</section>
");            
    }           
}
