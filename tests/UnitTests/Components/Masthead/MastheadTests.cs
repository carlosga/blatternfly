namespace Blatternfly.UnitTests.Components;

public class MastheadTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Masthead>(parameters => parameters
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<header
  class=""pf-c-masthead pf-m-display-inline-on-md""
>
  test
</header>
");
    }

    [Fact]
    public void FullStructureTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Masthead>(parameters => parameters
            .Add<MastheadToggle>(p => p.ChildContent, toggleparams => toggleparams
                .AddChildContent("Toggle")
            )
            .Add<MastheadMain>(p => p.ChildContent, mainparams => mainparams
                .Add<MastheadBrand>(p => p.ChildContent, brandparams => brandparams
                    .AddChildContent("Logo")
                )
            )
            .Add<MastheadContent>(p => p.ChildContent, contentparams => contentparams
                .AddChildContent("<span>Content</span>")
            )
        );

        // Assert
        cut.MarkupMatches(
@"
<header
  class=""pf-c-masthead pf-m-display-inline-on-md""
>
  <div
    class=""pf-c-masthead__toggle""
  >
    Toggle
  </div>
  <div
    class=""pf-c-masthead__main""
  >
    <a
      class=""pf-c-masthead__brand""
      tabindex=""0""
    >
      Logo
    </a>
  </div>
  <div
    class=""pf-c-masthead__content""
  >
    <span>
      Content
    </span>
  </div>
</header>
");
    }

    [Fact]
    public void WithAdditionalCssClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Masthead>(parameters => parameters
            .AddUnmatched("class", "custom-css")
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
@"
<header
  class=""pf-c-masthead pf-m-display-inline-on-md custom-css""
>
  test
</header>
");
    }

    [Theory]
    [InlineData(MastheadDisplayType.Inline)]
    [InlineData(MastheadDisplayType.Stack)]
    public void WithDisplayBreakpointsTest(MastheadDisplayType displayType)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var breakpoints = new MastheadDisplay
        {
            Default     = displayType,
            Small       = displayType,
            Medium      = displayType,
            Large       = displayType,
            ExtraLarge  = displayType,
            ExtraLarge2 = displayType
        };
        var displayClass = displayType == MastheadDisplayType.Inline ? "inline" : "stack";

        // Act
        var cut = ctx.RenderComponent<Masthead>(parameters => parameters
            .Add(p => p.Display, breakpoints)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
$@"
<header
 class=""pf-c-masthead pf-m-display-{displayClass} pf-m-display-{displayClass}-on-sm pf-m-display-{displayClass}-on-md pf-m-display-{displayClass}-on-lg pf-m-display-{displayClass}-on-xl pf-m-display-{displayClass}-on-2xl""
>
  test
</header>
");
    }

    [Theory]
    [InlineData(Inset.None)]
    [InlineData(Inset.ExtraSmall)]
    [InlineData(Inset.Small)]
    [InlineData(Inset.Medium)]
    [InlineData(Inset.Large)]
    [InlineData(Inset.ExtraLarge)]
    [InlineData(Inset.ExtraLarge2)]
    [InlineData(Inset.ExtraLarge3)]
    public void WithInsetBreakpointsTest(Inset inset)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var breakpoints = new InsetModifiers
        {
            Default     = inset,
            Small       = inset,
            Medium      = inset,
            Large       = inset,
            ExtraLarge  = inset,
            ExtraLarge2 = inset
        };
        var insetClass = inset switch
        {
            Inset.None        => "none",
            Inset.ExtraSmall  => "xs",
            Inset.Small       => "sm",
            Inset.Medium      => "md",
            Inset.Large       => "lg",
            Inset.ExtraLarge  => "xl",
            Inset.ExtraLarge2 => "2xl",
            Inset.ExtraLarge3 => "3xl",
            _                  => null
        };

        // Act
        var cut = ctx.RenderComponent<Masthead>(parameters => parameters
            .Add(p => p.Inset, breakpoints)
            .AddChildContent("test")
        );

        // Assert
        cut.MarkupMatches(
$@"
<header
  class=""pf-c-masthead pf-m-display-inline-on-md pf-m-inset-{insetClass} pf-m-inset-{insetClass}-on-sm pf-m-inset-{insetClass}-on-md pf-m-inset-{insetClass}-on-lg pf-m-inset-{insetClass}-on-xl pf-m-inset-{insetClass}-on-2xl""
>
  test
</header>
");
    }
}
