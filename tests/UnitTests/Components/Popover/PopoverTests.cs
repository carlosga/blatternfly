namespace Blatternfly.UnitTests.Components;

public class PopoverTests
{
    [Fact]
    public void WithCloseButtonHeaderAndBody()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Popover>(properties => properties
            .AddUnmatched("id", "test")
            .Add(p => p.Reference, "toggle-popover")
            .Add(p => p.Position, PopoverPosition.Top)
            .Add(p => p.IsVisible, true)
            .Add(p => p.HideOnOutsideClick, true)
            .Add(p => p.HeaderContent, "<div>Popover Header</div>")
            .Add(p => p.BodyContent, "<div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam id feugiat augue, nec fringilla turpis.</div>")
            .AddChildContent(@"<div id=""toggle-popover"">Toggle Popover</div>")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  id=""test""
  class=""pf-c-popover""
  role=""dialog""
  aria-modal=""true""
  aria-labelledby=""popover-test-header""
  aria-describedby=""popover-test-body""
  style=""opacity:1;z-index:9999;transition:opacity 300ms cubic-bezier(.54, 1.5, .38, 1.11);position:absolute;transform:translate3d(0px,0px,0);""
>
  <div class=""pf-c-popover__arrow""></div>
  <div class=""pf-c-popover__content"">
    <button
      style=""pointer-events: auto;""
      aria-disabled=""false""
      aria-label=""Close""
      class=""pf-c-button pf-m-plain""
      type=""button""
    >
      <svg
        style=""vertical-align: -0.125em;""
        fill=""currentColor""
        height=""1em""
        width=""1em""
        viewBox=""{TimesIcon.IconDefinition.ViewBox}""
        aria-hidden=""true"" role=""img""
      >
        <path
          d=""{TimesIcon.IconDefinition.SvgPath}"">
        </path>
      </svg>
    </button>
    <h6 id=""popover-test-header"" class=""pf-c-title pf-m-md"">
      <div>Popover Header</div>
    </h6>
    <div class=""pf-c-popover__body"" id=""popover-test-body"">
      <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam id feugiat augue, nec fringilla turpis.
      </div>
    </div>
  </div>
</div>
<div id=""toggle-popover"">Toggle Popover</div>
");
    }

    [Fact]
    public void WithMinWidth()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Popover>(properties => properties
            .AddUnmatched("id", "test")
            .Add(p => p.Reference, "toggle-popover")
            .Add(p => p.Position, PopoverPosition.Top)
            .Add(p => p.IsVisible, true)
            .Add(p => p.MinWidth, "600px")
            .Add(p => p.HideOnOutsideClick, true)
            .Add(p => p.HeaderContent, "<div>Popover Header</div>")
            .Add(p => p.BodyContent, "<div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam id feugiat augue, nec fringilla turpis.</div>")
            .AddChildContent(@"<div id=""toggle-popover"">Toggle Popover</div>")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  id=""test""
  class=""pf-c-popover""
  role=""dialog""
  aria-modal=""true""
  aria-labelledby=""popover-test-header""
  aria-describedby=""popover-test-body""
  style=""min-width:600px;opacity:1;z-index:9999;transition:opacity 300ms cubic-bezier(.54, 1.5, .38, 1.11);position:absolute;transform:translate3d(0px,0px,0);""
>
  <div class=""pf-c-popover__arrow""></div>
  <div class=""pf-c-popover__content"">
    <button
      style=""pointer-events: auto;""
      aria-disabled=""false""
      aria-label=""Close""
      class=""pf-c-button pf-m-plain""
      type=""button""
    >
      <svg
        style=""vertical-align: -0.125em;""
        fill=""currentColor""
        height=""1em""
        width=""1em""
        viewBox=""{TimesIcon.IconDefinition.ViewBox}""
        aria-hidden=""true"" role=""img""
      >
        <path
          d=""{TimesIcon.IconDefinition.SvgPath}"">
        </path>
      </svg>
    </button>
    <h6 id=""popover-test-header"" class=""pf-c-title pf-m-md"">
      <div>Popover Header</div>
    </h6>
    <div class=""pf-c-popover__body"" id=""popover-test-body"">
      <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam id feugiat augue, nec fringilla turpis.
      </div>
    </div>
  </div>
</div>
<div id=""toggle-popover"">Toggle Popover</div>
");
    }

    [Fact]
    public void WithMaxWidth()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<Popover>(properties => properties
            .AddUnmatched("id", "test")
            .Add(p => p.Reference, "toggle-popover")
            .Add(p => p.Position, PopoverPosition.Top)
            .Add(p => p.IsVisible, true)
            .Add(p => p.MaxWidth, "600px")
            .Add(p => p.HideOnOutsideClick, true)
            .Add(p => p.HeaderContent, "<div>Popover Header</div>")
            .Add(p => p.BodyContent, "<div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam id feugiat augue, nec fringilla turpis.</div>")
            .AddChildContent(@"<div id=""toggle-popover"">Toggle Popover</div>")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  id=""test""
  class=""pf-c-popover""
  role=""dialog""
  aria-modal=""true""
  aria-labelledby=""popover-test-header""
  aria-describedby=""popover-test-body""
  style=""max-width:600px;opacity:1;z-index:9999;transition:opacity 300ms cubic-bezier(.54, 1.5, .38, 1.11);position:absolute;transform:translate3d(0px,0px,0);""
>
  <div class=""pf-c-popover__arrow""></div>
  <div class=""pf-c-popover__content"">
    <button
      style=""pointer-events: auto;""
      aria-disabled=""false""
      aria-label=""Close""
      class=""pf-c-button pf-m-plain""
      type=""button""
    >
      <svg
        style=""vertical-align: -0.125em;""
        fill=""currentColor""
        height=""1em""
        width=""1em""
        viewBox=""{TimesIcon.IconDefinition.ViewBox}""
        aria-hidden=""true"" role=""img""
      >
        <path
          d=""{TimesIcon.IconDefinition.SvgPath}"">
        </path>
      </svg>
    </button>
    <h6 id=""popover-test-header"" class=""pf-c-title pf-m-md"">
      <div>Popover Header</div>
    </h6>
    <div class=""pf-c-popover__body"" id=""popover-test-body"">
      <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam id feugiat augue, nec fringilla turpis.
      </div>
    </div>
  </div>
</div>
<div id=""toggle-popover"">Toggle Popover</div>
");
    }
}
