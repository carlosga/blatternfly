namespace Blatternfly.UnitTests.Components;

public class AvatarTests
{
    [Fact]
    public void SimpleAvatarTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Avatar>(parameters => parameters
            .Add(p => p.Alt, "avatar")
            .Add(p => p.Src       , "test.png")
            .Add(p => p.Border       , AvatarBorder.Light)
        );

        // Assert
        cut.MarkupMatches(
@"
<img
  alt=""avatar""
  class=""pf-c-avatar pf-m-light""
  src=""test.png""
/>
");
    }
}
