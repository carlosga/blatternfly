namespace Blatternfly.UnitTests.Components;

public class TileTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Tile>(properties => properties
            .Add(p => p.Title, "test")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-tile""
  tabindex=""0""
>
  <div
    class=""pf-c-tile__header""
  >
    <div
      class=""pf-c-tile__title""
    >
      test
    </div>
  </div>
</div>
");
    }      

    [Fact]
    public void IsSelectedTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Tile>(properties => properties
            .Add(p => p.Title, "test")
            .Add(p => p.IsSelected, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-tile pf-m-selected""
  tabindex=""0""
>
  <div
    class=""pf-c-tile__header""
  >
    <div
      class=""pf-c-tile__title""
    >
      test
    </div>
  </div>
</div>
");
    }
    
    [Fact]
    public void IsDisabledTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Tile>(properties => properties
            .Add(p => p.Title, "test")
            .Add(p => p.IsDisabled, true)
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-tile pf-m-disabled""
  tabindex=""0""
>
  <div
    class=""pf-c-tile__header""
  >
    <div
      class=""pf-c-tile__title""
    >
      test
    </div>
  </div>
</div>
");
    }
    
    [Fact]
    public void WithSubtextTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Tile>(properties => properties
            .Add(p => p.Title, "test")
            .AddChildContent("test subtext")
        );

        // Assert
        cut.MarkupMatches(
@"
<div
  class=""pf-c-tile""
  tabindex=""0""
>
  <div
    class=""pf-c-tile__header""
  >
    <div
      class=""pf-c-tile__title""
    >
      test
    </div>
  </div>
  <div
    class=""pf-c-tile__body""
  >
    test subtext
  </div>
</div>
");
    }
    
    [Fact]
    public void WithIconTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Tile>(properties => properties
            .Add(p => p.Title, "test")
            .Add<PlusIcon>(p => p.Icon)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-tile""
  tabindex=""0""
>
  <div
    class=""pf-c-tile__header""
  >
    <div
      class=""pf-c-tile__icon""
    >
      <svg
        style=""vertical-align: -0.125em;"" 
        fill=""currentColor"" 
        height=""1em"" 
        width=""1em"" 
        viewBox=""{PlusIcon.IconDefinition.ViewBox}"" 
        aria-hidden=""true"" 
        role=""img""
      >
        <path d=""{PlusIcon.IconDefinition.SvgPath}""></path>
      </svg>      
    </div>
    <div
      class=""pf-c-tile__title""
    >
      test
    </div>
  </div>
</div>
");
    }
    
    [Fact]
    public void WithStackedIconTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Tile>(properties => properties
            .Add(p => p.Title, "test")
            .Add<PlusIcon>(p => p.Icon)
            .Add(p => p.IsStacked, true)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-tile""
  tabindex=""0""
>
  <div
    class=""pf-c-tile__header pf-m-stacked""
  >
    <div
      class=""pf-c-tile__icon""
    >
      <svg
        style=""vertical-align: -0.125em;"" 
        fill=""currentColor"" 
        height=""1em"" 
        width=""1em"" 
        viewBox=""{PlusIcon.IconDefinition.ViewBox}"" 
        aria-hidden=""true"" 
        role=""img""
      >
        <path d=""{PlusIcon.IconDefinition.SvgPath}""></path>
      </svg>     
    </div>
    <div
      class=""pf-c-tile__title""
    >
      test
    </div>
  </div>
</div>
");
    }
    
    [Fact]
    public void WithStackedLargeIconTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var cut = ctx.RenderComponent<Tile>(properties => properties
            .Add(p => p.Title, "test")
            .Add<PlusIcon>(p => p.Icon)
            .Add(p => p.IsStacked, true)
            .Add(p => p.IsDisplayLarge, true)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-tile pf-m-display-lg""
  tabindex=""0""
>
  <div
    class=""pf-c-tile__header pf-m-stacked""
  >
    <div
      class=""pf-c-tile__icon""
    >
      <svg
        style=""vertical-align: -0.125em;"" 
        fill=""currentColor"" 
        height=""1em"" 
        width=""1em"" 
        viewBox=""{PlusIcon.IconDefinition.ViewBox}"" 
        aria-hidden=""true"" 
        role=""img""
      >
        <path d=""{PlusIcon.IconDefinition.SvgPath}""></path>
      </svg>     
    </div>
    <div
      class=""pf-c-tile__title""
    >
      test
    </div>
  </div>
</div>
");
    }
}
