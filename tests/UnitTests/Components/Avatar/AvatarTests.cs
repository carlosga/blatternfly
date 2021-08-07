using Xunit;
using Bunit;
using Blatternfly.Components;

namespace Blatternfly.UnitTests.Components
{
    public class AvatarTests
    {
        [Fact]
        public void SimpleAvatarTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Avatar>(parameters => parameters
                .Add(p => p.AlternateText, "avatar")
                .Add(p => p.Source       , "test.png")
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
}
