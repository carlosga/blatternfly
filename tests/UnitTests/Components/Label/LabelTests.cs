namespace Blatternfly.UnitTests.Components;

public class LabelTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Label>(parameters => parameters
            .AddChildContent("Something")
        );

        // Assert
        cut.MarkupMatches(
@"
<span
  class=""pf-c-label""
>
  <span
    class=""pf-c-label__content""
  >
    Something
  </span>
</span>
");
    }

    [Fact]
    public void VariantTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Label>(parameters => parameters
            .Add(p => p.Variant, LabelVariant.Outline)
            .AddChildContent("Something")
        );

        // Assert
        cut.MarkupMatches(
@"
<span
  class=""pf-c-label pf-m-outline""
>
  <span
    class=""pf-c-label__content""
  >
    Something
  </span>
</span>
");
    }

    [Fact]
    public void WithHrefTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Label>(parameters => parameters
            .Add(p => p.Variant, LabelVariant.Outline)
            .Add(p => p.Href, "#")
            .AddChildContent("Something")
        );

        // Assert
        cut.MarkupMatches(
@"
<span
  class=""pf-c-label pf-m-outline""
>
  <a
    class=""pf-c-label__content""
    href=""#""
  >
    Something
  </a>
</span>
");
    }

    [Fact]
    public void WithCloseButton()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        Action<MouseEventArgs> onCloseHandler = _ => { };

        // Act
        var cut = ctx.RenderComponent<Label>(parameters => parameters
            .Add(p => p.Variant, LabelVariant.Outline)
            .Add(p => p.OnClose, onCloseHandler)
            .AddChildContent("Something")
        );

        // Assert
        cut.MarkupMatches(
$@"
<span
  class=""pf-c-label pf-m-outline""
>
  <span
    class=""pf-c-label__content""
  >
    Something
  </span>
  <button
    aria-disabled=""false""
    aria-label=""Close Label""
    class=""pf-c-button pf-m-plain""
    type=""button""
  >
    <svg
      style=""vertical-align: -0.125em;""
      fill=""currentColor""
      height=""1em""
      width=""1em""
      viewBox=""{TimesIcon.IconDefinition.ViewBox}""
      aria-hidden=""true""
      role=""img""
    >
      <path d=""{TimesIcon.IconDefinition.SvgPath}""></path>
    </svg>
  </button>
</span>
");
    }

    [Theory]
    [InlineData(LabelColor.Blue)]
    [InlineData(LabelColor.Cyan)]
    [InlineData(LabelColor.Green)]
    [InlineData(LabelColor.Orange)]
    [InlineData(LabelColor.Purple)]
    [InlineData(LabelColor.Red)]
    [InlineData(LabelColor.Grey)]
    public void FilledVariantWithColorTest(LabelColor color)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var colorClass = color switch
        {
            LabelColor.Blue   => "pf-m-blue",
            LabelColor.Cyan   => "pf-m-cyan",
            LabelColor.Green  => "pf-m-green",
            LabelColor.Orange => "pf-m-orange",
            LabelColor.Purple => "pf-m-purple",
            LabelColor.Red    => "pf-m-red",
            _                 => null
        };

        // Act
        var cut = ctx.RenderComponent<Label>(parameters => parameters
            .Add(p => p.Color, color)
            .AddChildContent("Something")
        );

        // Assert
        cut.MarkupMatches(
$@"
<span
  class=""pf-c-label {colorClass}""
>
  <span
    class=""pf-c-label__content""
  >
    Something
  </span>
</span>
");
    }

    [Theory]
    [InlineData(LabelColor.Blue)]
    [InlineData(LabelColor.Cyan)]
    [InlineData(LabelColor.Green)]
    [InlineData(LabelColor.Orange)]
    [InlineData(LabelColor.Purple)]
    [InlineData(LabelColor.Red)]
    [InlineData(LabelColor.Grey)]
    public void OutlineVariantWithColorTest(LabelColor color)
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();
        var colorClass = color switch
        {
            LabelColor.Blue   => "pf-m-blue",
            LabelColor.Cyan   => "pf-m-cyan",
            LabelColor.Green  => "pf-m-green",
            LabelColor.Orange => "pf-m-orange",
            LabelColor.Purple => "pf-m-purple",
            LabelColor.Red    => "pf-m-red",
            _                 => null
        };

        // Act
        var cut = ctx.RenderComponent<Label>(parameters => parameters
            .Add(p => p.Variant, LabelVariant.Outline)
            .Add(p => p.Color, color)
            .AddChildContent("Something")
        );

        // Assert
        cut.MarkupMatches(
$@"
<span
  class=""pf-c-label pf-m-outline {colorClass}""
>
  <span
    class=""pf-c-label__content""
  >
    Something
  </span>
</span>
");
    }

    [Fact]
    public void WithAdditionalCssClassTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Label>(parameters => parameters
            .AddUnmatched("class", "klass1")
            .AddChildContent("Something")
        );

        // Assert
        cut.MarkupMatches(
@"
<span
  class=""pf-c-label klass1""
>
  <span
    class=""pf-c-label__content""
  >
    Something
  </span>
</span>
");
    }

    [Fact]
    public void WithAdditionalCssClassAndPropertiesTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Label>(parameters => parameters
            .AddUnmatched("class", "class-1")
            .AddUnmatched("id", "label-1")
            .AddUnmatched("data-label-name", "something")
            .AddChildContent("Something")
        );

        // Assert
        cut.MarkupMatches(
@"
<span
  class=""pf-c-label class-1""
  data-label-name=""something""
  id=""label-1""
>
  <span
    class=""pf-c-label__content""
  >
    Something
  </span>
</span>
");
    }

    [Fact]
    public void WithTruncation()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Label>(parameters => parameters
            .Add(p => p.IsTruncated, true)
            .AddChildContent("Something very very very very very long that should be truncated")
        );

        // Assert
        cut.MarkupMatches(
@"
<span
  class=""pf-c-label""
>
  <span
    class=""pf-c-label__content""
  >
    <span
      class=""pf-c-label__text""
    >
      Something very very very very very long that should be truncated
    </span>
  </span>
</span>
");
    }

    [Fact]
    public void CompactTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Label>(parameters => parameters
            .Add(p => p.IsCompact, true)
            .AddChildContent("Something")
        );

        // Assert
        cut.MarkupMatches(
@"
<span
  class=""pf-c-label pf-m-compact""
>
  <span
    class=""pf-c-label__content""
  >
    Something
  </span>
</span>
");
    }
}
