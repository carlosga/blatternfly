using Bunit;
using Xunit;
using Blatternfly.Components;

namespace Blatternfly.UnitTests.Components
{
    public class BackgroundImageTests
    {
        private static readonly BackgroundImageSrcMap s_images = new()
        {
            lg   = "/assets/images/pfbg_1200.jpg",
            sm   = "/assets/images/pfbg_768.jpg",
            sm2x = "/assets/images/pfbg_768@2x.jpg",
            xs   = "/assets/images/pfbg_576.jpg",
            xs2x = "/assets/images/pfbg_576@2x.jpg"
        };        
        
        [Fact]
        public void BackgroundImageTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<BackgroundImage>(parameters => parameters
                .Add(p => p.Source, s_images)
            );

            // Assert
            cut.MarkupMatches(
                @"
<div
  class=""pf-c-background-image""
  style=
""
  --pf-c-background-image--BackgroundImage: url(/assets/images/pfbg_576.jpg);
  --pf-c-background-image--BackgroundImage-2x: url(/assets/images/pfbg_576@2x.jpg);
  --pf-c-background-image--BackgroundImage--sm: url(/assets/images/pfbg_768.jpg);
  --pf-c-background-image--BackgroundImage--sm-2x: url(/assets/images/pfbg_768@2x.jpg);
  --pf-c-background-image--BackgroundImage--lg: url(/assets/images/pfbg_1200.jpg);
  --pf-c-background-image--Filter: url(#patternfly-background-image-filter-overlay0);
""
>
  <svg
    class=""pf-c-background-image__filter""
    height=""0""
    width=""0""
    xmlns=""http://www.w3.org/2000/svg""
  >
    <filter
      id=""patternfly-background-image-filter-overlay0""
    >
      <feColorMatrix
        type=""matrix""
        values=""1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 0 0 0 1 0""
      />
      <feComponentTransfer
        color-interpolation-filters=""sRGB""
        result=""duotone""
      >
        <feFuncR
          tableValues=""0.086274509803922 0.43921568627451""
          type=""table""
        />
        <feFuncG
          tableValues=""0.086274509803922 0.43921568627451""
          type=""table""
        />
        <feFuncB
          tableValues=""0.086274509803922 0.43921568627451""
          type=""table""
        />
        <feFuncA
          tableValues=""0 1""
          type=""table""
        />
      </feComponentTransfer>
    </filter>
  </svg>
</div>
");
        }        
    }
}
