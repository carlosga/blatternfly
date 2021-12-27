namespace Blatternfly.UnitTests.Components;

public class BackgroundImageTests
{
    private static readonly BackgroundImageSrcMap Images = new()
    {
        lg   = "/assets/images/pfbg_1200.jpg",
        sm   = "/assets/images/pfbg_768.jpg",
        sm2x = "/assets/images/pfbg_768@2x.jpg",
        xs   = "/assets/images/pfbg_576.jpg",
        xs2x = "/assets/images/pfbg_576@2x.jpg"
    };        
    
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        const string filterId = "patternfly-background-image-filter-overlay-1";
        
        // Act
        var cut = ctx.RenderComponent<BackgroundImage>(parameters => parameters
            .Add(p => p.Source, Images)
            .Add(p => p.FilterId, filterId)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-background-image""
  style=
""
  --pf-c-background-image--BackgroundImage: url(/assets/images/pfbg_576.jpg);
  --pf-c-background-image--BackgroundImage-2x: url(/assets/images/pfbg_576@2x.jpg);
  --pf-c-background-image--BackgroundImage--sm: url(/assets/images/pfbg_768.jpg);
  --pf-c-background-image--BackgroundImage--sm-2x: url(/assets/images/pfbg_768@2x.jpg);
  --pf-c-background-image--BackgroundImage--lg: url(/assets/images/pfbg_1200.jpg);
  --pf-c-background-image--Filter: url(#patternfly-background-image-filter-overlay-1);
""
>
  <svg
    class=""pf-c-background-image__filter""
    height=""0""
    width=""0""
    xmlns=""http://www.w3.org/2000/svg""
  >
    <filter
      id=""patternfly-background-image-filter-overlay-1""
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
    
    [Fact]
    public void WitNoSourceImagesTest()
    {
        // Arrange
        using var ctx = new TestContext();

        const string filterId = "patternfly-background-image-filter-overlay-1";
        
        // Act
        var cut = ctx.RenderComponent<BackgroundImage>(parameters => parameters.Add(p => p.FilterId, filterId));

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-background-image""
  style=
""
  --pf-c-background-image--Filter: url(#patternfly-background-image-filter-overlay-1);
""
>
  <svg
    class=""pf-c-background-image__filter""
    height=""0""
    width=""0""
    xmlns=""http://www.w3.org/2000/svg""
  >
    <filter
      id=""patternfly-background-image-filter-overlay-1""
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
