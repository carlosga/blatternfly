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
            .Add(p => p.Alt   , "avatar")
            .Add(p => p.Src   , "test.png")
            .Add(p => p.Border, AvatarBorder.Light)
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

    [Theory]
    [InlineData(AvatarSize.Small)]
    [InlineData(AvatarSize.Medium)]
    [InlineData(AvatarSize.Large)]
    [InlineData(AvatarSize.ExtraLarge)]
    public void SizeVariationsTest(AvatarSize size)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        var sizeClass = size switch
        {
            AvatarSize.Small      => "pf-m-sm",
            AvatarSize.Medium     => "pf-m-md",
            AvatarSize.Large      => "pf-m-lg",
            AvatarSize.ExtraLarge => "pf-m-xl",
            _                     => ""
        };

        // Act
        var cut = ctx.RenderComponent<Avatar>(parameters => parameters
            .Add(p => p.Alt   , "avatar")
            .Add(p => p.Src   , "test.png")
            .Add(p => p.Border, AvatarBorder.Light)
            .Add(p => p.Size  , size)
        );

        // Assert
        cut.MarkupMatches(
$@"
<img
  alt=""avatar""
  class=""pf-c-avatar pf-m-light {sizeClass}""
  src=""test.png""
/>
");
    }
}
