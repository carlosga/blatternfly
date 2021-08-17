using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class TitleTests
    {
        [Theory]
        [InlineData(TitleSizes.Medium)]
        [InlineData(TitleSizes.Large)]
        [InlineData(TitleSizes.ExtraLarge)]
        [InlineData(TitleSizes.ExtraLarge2)]
        [InlineData(TitleSizes.ExtraLarge3)]
        [InlineData(TitleSizes.ExtraLarge4)]
        public void SizeTest(TitleSizes size)
        {
            // Arrange
            using var ctx = new TestContext();
            var sizeClass = size switch
            {
                TitleSizes.Medium      => "pf-m-md",
                TitleSizes.Large       => "pf-m-lg",
                TitleSizes.ExtraLarge  => "pf-m-xl",
                TitleSizes.ExtraLarge2 => "pf-m-2xl",
                TitleSizes.ExtraLarge3 => "pf-m-3xl",
                TitleSizes.ExtraLarge4 => "pf-m-4xl",
                _                      => null
            };
            var titleContent = $"{size} Title";
            
            // Act
            var cut = ctx.RenderComponent<Title>(properties => properties
                .Add(p => p.Size, size)
                .Add(p => p.HeadingLevel, HeadingLevel.h1)
                .AddChildContent(titleContent)
            );

            // Assert
            cut.MarkupMatches(
$@"
<h1
  class=""pf-c-title {sizeClass}""
>
  {titleContent}
</h1>
");
        }
        
        [Theory]
        [InlineData(HeadingLevel.h1)]
        [InlineData(HeadingLevel.h2)]
        [InlineData(HeadingLevel.h3)]
        [InlineData(HeadingLevel.h4)]
        [InlineData(HeadingLevel.h5)]
        [InlineData(HeadingLevel.h6)]        
        public void HeadingLevelTest(HeadingLevel headingLevel)
        {
            // Arrange
            using var ctx = new TestContext();
            var titleContent = $"{headingLevel} Title";
            TitleSizes? size = headingLevel switch
            {
                HeadingLevel.h1 => TitleSizes.ExtraLarge2,
                HeadingLevel.h2 => TitleSizes.ExtraLarge,
                HeadingLevel.h3 => TitleSizes.Large,
                HeadingLevel.h4 => TitleSizes.Medium,
                HeadingLevel.h5 => TitleSizes.Medium,
                HeadingLevel.h6 => TitleSizes.Medium,
                _               => null
            };            
            var sizeClass = size switch
            {
                TitleSizes.Medium      => "pf-m-md",
                TitleSizes.Large       => "pf-m-lg",
                TitleSizes.ExtraLarge  => "pf-m-xl",
                TitleSizes.ExtraLarge2 => "pf-m-2xl",
                TitleSizes.ExtraLarge3 => "pf-m-3xl",
                TitleSizes.ExtraLarge4 => "pf-m-4xl",
                _                      => null
            };            
            // Act
            var cut = ctx.RenderComponent<Title>(properties => properties
                .Add(p => p.HeadingLevel, headingLevel)
                .AddChildContent(titleContent)
            );

            // Assert
            cut.MarkupMatches(
$@"
<{headingLevel}
  class=""pf-c-title {sizeClass}""
>
  {titleContent}
</{headingLevel}>
");
        }
    }
}
