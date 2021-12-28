namespace Blatternfly.UnitTests.Components;

public class PaginationTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .AddUnmatched("id", "pagination-options-menu-1")
            .Add(p => p.OptionsToggleId, "pagination-options-menu-toggle-1")
            .Add(p => p.ItemCount, 20)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-pagination""
  style=""--pf-c-pagination__nav-page-select--c-form-control--width-chars: 2;""
  id=""pagination-options-menu-1""
>
  <div class=""pf-c-pagination__total-items""><b>1 - 10</b> of <b>20</b> </div>
  <div class=""pf-c-options-menu"">
    <div class=""pf-c-options-menu__toggle pf-m-plain pf-m-text"">
      <span class=""pf-c-options-menu__toggle-text"">
        <b>1 - 10</b> of <b>20</b>
      </span>
      <button
        aria-label=""Items per page""
        id=""pagination-options-menu-toggle-1""
        class=""  pf-c-options-menu__toggle-button""
        type=""button""
        aria-expanded=""false""
        aria-haspopup=""true""
      >
        <span class=""pf-c-options-menu__toggle-button-icon"">
          <svg
            style=""vertical-align: -0.125em;""
            fill=""currentColor""
            height=""1em"" width=""1em""
            viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
            aria-hidden=""true"" role=""img""
          >
            <path
              d=""{CaretDownIcon.IconDefinition.SvgPath}"">
            </path>
          </svg>
        </span>
      </button>
    </div>
  </div>
  <nav class=""pf-c-pagination__nav"" aria-label=""Pagination"">
    <div class=""pf-c-pagination__nav-control pf-m-first"">
      <button
        data-action=""first""
        aria-disabled=""true""
        aria-label=""Go to first page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""previous""
        aria-disabled=""true""
        aria-label=""Go to previous page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-page-select"">
      <input
        class=""pf-c-form-control""
        aria-label=""Current page""
        type=""number""
        min=""1""
        max=""2""
        value=""1""
      >
      <span aria-hidden=""true"">of 2</span>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""next""
        aria-disabled=""false""
        aria-label=""Go to next page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control pf-m-last"">
      <button
        data-action=""last""
        aria-disabled=""false""
        aria-label=""Go to last page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
  </nav>
</div>
");
    }

    [Fact]
    public void WithBottomVariantTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .AddUnmatched("id", "pagination-options-menu-1")
            .Add(p => p.OptionsToggleId, "pagination-options-menu-toggle-1")
            .Add(p => p.ItemCount, 20)
            .Add(p => p.Variant, PaginationVariant.Bottom)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-pagination pf-m-bottom""
  id=""pagination-options-menu-1""
  style=""--pf-c-pagination__nav-page-select--c-form-control--width-chars: 2;""
>
  <div class=""pf-c-options-menu pf-m-top"">
    <div class=""pf-c-options-menu__toggle pf-m-plain pf-m-text"">
      <span class=""pf-c-options-menu__toggle-text"">
        <b>1 - 10</b> of <b>20</b>
      </span>
      <button
        aria-label=""Items per page""
        id=""pagination-options-menu-toggle-1""
        class=""pf-c-options-menu__toggle-button""
        type=""button""
        aria-expanded=""false""
        aria-haspopup=""true""
      >
        <span class=""pf-c-options-menu__toggle-button-icon"">
          <svg style=""vertical-align: -0.125em;""
            fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""0 0 320 512"" aria-hidden=""true"" role=""img"">
            <path
              d=""M31.3 192h257.3c17.8 0 26.7 21.5 14.1 34.1L174.1 354.8c-7.8 7.8-20.5 7.8-28.3 0L17.2 226.1C4.6 213.5 13.5 192 31.3 192z"">
            </path>
          </svg>
        </span>
      </button>
    </div>
  </div>
  <nav class=""pf-c-pagination__nav"" aria-label=""Pagination"">
    <div class=""pf-c-pagination__nav-control pf-m-first"">
      <button
        data-action=""first""
        aria-disabled=""true""
        aria-label=""Go to first page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""previous""
        aria-disabled=""true""
        aria-label=""Go to previous page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-page-select"">
      <input
        class=""pf-c-form-control""
        aria-label=""Current page""
        type=""number""
        min=""1""
        max=""2""
        value=""1""
      >
      <span aria-hidden=""true"">of 2</span>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""next""
        aria-disabled=""false""
        aria-label=""Go to next page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control pf-m-last"">
      <button
        data-action=""last""
        aria-disabled=""false""
        aria-label=""Go to last page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
  </nav>
</div>
");
    }

    [Fact]
    public void IsCompactTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .AddUnmatched("id", "pagination-options-menu-1")
            .Add(p => p.OptionsToggleId, "pagination-options-menu-toggle-1")
            .Add(p => p.ItemCount, 20)
            .Add(p => p.IsCompact, true)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-pagination pf-m-compact""
  style=""--pf-c-pagination__nav-page-select--c-form-control--width-chars: 2;""
  id=""pagination-options-menu-1""
>
  <div class=""pf-c-pagination__total-items""><b>1 - 10</b> of <b>20</b> </div>
  <div class=""pf-c-options-menu"">
    <div class=""pf-c-options-menu__toggle pf-m-plain pf-m-text"">
      <span class=""pf-c-options-menu__toggle-text"">
        <b>1 - 10</b> of <b>20</b>
      </span>
      <button
        aria-label=""Items per page""
        id=""pagination-options-menu-toggle-1""
        class=""  pf-c-options-menu__toggle-button""
        type=""button""
        aria-expanded=""false""
        aria-haspopup=""true""
      >
        <span class=""pf-c-options-menu__toggle-button-icon"">
          <svg
            style=""vertical-align: -0.125em;""
            fill=""currentColor""
            height=""1em"" width=""1em""
            viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
            aria-hidden=""true"" role=""img""
          >
            <path
              d=""{CaretDownIcon.IconDefinition.SvgPath}"">
            </path>
          </svg>
        </span>
      </button>
    </div>
  </div>
  <nav class=""pf-c-pagination__nav"" aria-label=""Pagination"">
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""previous""
        aria-disabled=""true""
        aria-label=""Go to previous page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""next""
        aria-disabled=""false""
        aria-label=""Go to next page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
  </nav>
</div>
");
    }

    [Fact]
    public void IsStickyTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .AddUnmatched("id", "pagination-options-menu-1")
            .Add(p => p.OptionsToggleId, "pagination-options-menu-toggle-1")
            .Add(p => p.ItemCount, 20)
            .Add(p => p.IsSticky, true)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-pagination pf-m-sticky""
  style=""--pf-c-pagination__nav-page-select--c-form-control--width-chars: 2;""
  id=""pagination-options-menu-1""
>
  <div class=""pf-c-pagination__total-items""><b>1 - 10</b> of <b>20</b> </div>
  <div class=""pf-c-options-menu"">
    <div class=""pf-c-options-menu__toggle pf-m-plain pf-m-text"">
      <span class=""pf-c-options-menu__toggle-text"">
        <b>1 - 10</b> of <b>20</b>
      </span>
      <button
        aria-label=""Items per page""
        id=""pagination-options-menu-toggle-1""
        class=""  pf-c-options-menu__toggle-button""
        type=""button""
        aria-expanded=""false""
        aria-haspopup=""true""
      >
        <span class=""pf-c-options-menu__toggle-button-icon"">
          <svg
            style=""vertical-align: -0.125em;""
            fill=""currentColor""
            height=""1em"" width=""1em""
            viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
            aria-hidden=""true"" role=""img""
          >
            <path
              d=""{CaretDownIcon.IconDefinition.SvgPath}"">
            </path>
          </svg>
        </span>
      </button>
    </div>
  </div>
  <nav class=""pf-c-pagination__nav"" aria-label=""Pagination"">
    <div class=""pf-c-pagination__nav-control pf-m-first"">
      <button
        data-action=""first""
        aria-disabled=""true""
        aria-label=""Go to first page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""previous""
        aria-disabled=""true""
        aria-label=""Go to previous page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-page-select"">
      <input
        class=""pf-c-form-control""
        aria-label=""Current page""
        type=""number""
        min=""1""
        max=""2""
        value=""1""
      >
      <span aria-hidden=""true"">of 2</span>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""next""
        aria-disabled=""false""
        aria-label=""Go to next page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control pf-m-last"">
      <button
        data-action=""last""
        aria-disabled=""false""
        aria-label=""Go to last page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
  </nav>
</div>
");
    }

    [Fact]
    public void IsBottomStickyTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .AddUnmatched("id", "pagination-options-menu-1")
            .Add(p => p.OptionsToggleId, "pagination-options-menu-toggle-1")
            .Add(p => p.ItemCount, 20)
            .Add(p => p.Variant, PaginationVariant.Bottom)
            .Add(p => p.IsSticky, true)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-pagination pf-m-bottom pf-m-sticky""
  style=""--pf-c-pagination__nav-page-select--c-form-control--width-chars: 2;""
  id=""pagination-options-menu-1""
>
  <div class=""pf-c-options-menu pf-m-top"">
    <div class=""pf-c-options-menu__toggle pf-m-plain pf-m-text"">
      <span class=""pf-c-options-menu__toggle-text"">
        <b>1 - 10</b> of <b>20</b>
      </span>
      <button
        aria-label=""Items per page""
        id=""pagination-options-menu-toggle-1""
        class=""  pf-c-options-menu__toggle-button""
        type=""button""
        aria-expanded=""false""
        aria-haspopup=""true""
      >
        <span class=""pf-c-options-menu__toggle-button-icon"">
          <svg
            style=""vertical-align: -0.125em;""
            fill=""currentColor""
            height=""1em"" width=""1em""
            viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
            aria-hidden=""true"" role=""img""
          >
            <path
              d=""{CaretDownIcon.IconDefinition.SvgPath}"">
            </path>
          </svg>
        </span>
      </button>
    </div>
  </div>
  <nav class=""pf-c-pagination__nav"" aria-label=""Pagination"">
    <div class=""pf-c-pagination__nav-control pf-m-first"">
      <button
        data-action=""first""
        aria-disabled=""true""
        aria-label=""Go to first page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""previous""
        aria-disabled=""true""
        aria-label=""Go to previous page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-page-select"">
      <input
        class=""pf-c-form-control""
        aria-label=""Current page""
        type=""number""
        min=""1""
        max=""2""
        value=""1""
      >
      <span aria-hidden=""true"">of 2</span>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""next""
        aria-disabled=""false""
        aria-label=""Go to next page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control pf-m-last"">
      <button
        data-action=""last""
        aria-disabled=""false""
        aria-label=""Go to last page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
  </nav>
</div>
");
    }

    [Fact]
    public void IsDisabledTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .AddUnmatched("id", "pagination-options-menu-1")
            .Add(p => p.OptionsToggleId, "pagination-options-menu-toggle-1")
            .Add(p => p.ItemCount, 20)
            .Add(p => p.IsDisabled, true)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-pagination""
  id=""pagination-options-menu-1""
  style=""--pf-c-pagination__nav-page-select--c-form-control--width-chars: 2;""
>
  <div class=""pf-c-pagination__total-items""><b>1 - 10</b> of <b>20</b> </div>
  <div class=""pf-c-options-menu"">
    <div class=""pf-c-options-menu__toggle pf-m-disabled pf-m-plain pf-m-text"">
      <span class=""pf-c-options-menu__toggle-text""><b>1 - 10</b> of <b>20</b> </span>
      <button
        aria-label=""Items per page""
        id=""pagination-options-menu-toggle-1""
        class=""  pf-c-options-menu__toggle-button""
        type=""button""
        aria-expanded=""false""
        aria-haspopup=""true""
        disabled=""""
      >
        <span class=""pf-c-options-menu__toggle-button-icon"">
          <svg
            style=""vertical-align: -0.125em;""
            fill=""currentColor""
            height=""1em"" width=""1em""
            viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
            aria-hidden=""true"" role=""img""
          >
            <path
              d=""{CaretDownIcon.IconDefinition.SvgPath}"">
            </path>
          </svg>
        </span>
      </button>
    </div>
  </div>
  <nav class=""pf-c-pagination__nav"" aria-label=""Pagination"">
    <div class=""pf-c-pagination__nav-control pf-m-first"">
      <button
        data-action=""first""
        aria-disabled=""true""
        aria-label=""Go to first page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""previous""
        aria-disabled=""true""
        aria-label=""Go to previous page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-page-select"">
      <input
        class=""pf-c-form-control""
        aria-label=""Current page""
        type=""number""
        disabled=""""
        min=""1""
        max=""2""
        value=""1""
      >
      <span aria-hidden=""true"">of 2</span>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""next""
        aria-disabled=""true""
        aria-label=""Go to next page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control pf-m-last"">
      <button
        data-action=""last""
        aria-disabled=""true""
        aria-label=""Go to last page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
  </nav>
</div>
");
    }

    [Fact]
    public void LimitedNumberOfPagesTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .AddUnmatched("id", "pagination-options-menu-1")
            .Add(p => p.OptionsToggleId, "pagination-options-menu-toggle-1")
            .Add(p => p.ItemCount, 20)
            .Add(p => p.PerPage, 20)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-pagination""
  id=""pagination-options-menu-1""
  style=""--pf-c-pagination__nav-page-select--c-form-control--width-chars: 2;""
>
  <div class=""pf-c-pagination__total-items""><b>1 - 20</b> of <b>20</b> </div>
  <div class=""pf-c-options-menu"">
    <div class=""pf-c-options-menu__toggle pf-m-plain pf-m-text"">
      <span class=""pf-c-options-menu__toggle-text""><b>1 - 20</b> of <b>20</b> </span>
      <button
        aria-label=""Items per page""
        id=""pagination-options-menu-toggle-1""
        class=""  pf-c-options-menu__toggle-button""
        type=""button""
        aria-expanded=""false""
        aria-haspopup=""true""
      >
        <span class=""pf-c-options-menu__toggle-button-icon"">
          <svg
            style=""vertical-align: -0.125em;""
            fill=""currentColor""
            height=""1em"" width=""1em""
            viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
            aria-hidden=""true"" role=""img""
          >
            <path
              d=""{CaretDownIcon.IconDefinition.SvgPath}"">
            </path>
          </svg>
        </span>
      </button>
    </div>
  </div>
  <nav class=""pf-c-pagination__nav"" aria-label=""Pagination"">
    <div class=""pf-c-pagination__nav-control pf-m-first"">
      <button
        data-action=""first""
        aria-disabled=""true""
        aria-label=""Go to first page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""previous""
        aria-disabled=""true""
        aria-label=""Go to previous page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-page-select"">
      <input
        class=""pf-c-form-control""
        aria-label=""Current page""
        type=""number""
        disabled=""""
        min=""1""
        max=""1""
        value=""1""
      >
      <span aria-hidden=""true"">of 1</span>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""next""
        aria-disabled=""true""
        aria-label=""Go to next page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control pf-m-last"">
      <button
        data-action=""last""
        aria-disabled=""true""
        aria-label=""Go to last page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
  </nav>
</div>
");
    }

    [Fact]
    public void ZeroResultsTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .AddUnmatched("id", "pagination-options-menu-1")
            .Add(p => p.OptionsToggleId, "pagination-options-menu-toggle-1")
            .Add(p => p.ItemCount, 0)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-pagination""
  id=""pagination-options-menu-1""
  style=""--pf-c-pagination__nav-page-select--c-form-control--width-chars: 2;""
>
  <div class=""pf-c-pagination__total-items""><b>0 - 0</b> of <b>0</b> </div>
  <div class=""pf-c-options-menu"">
    <div class=""pf-c-options-menu__toggle pf-m-plain pf-m-text"">
      <span class=""pf-c-options-menu__toggle-text""><b>0 - 0</b> of <b>0</b> </span>
      <button
        aria-label=""Items per page""
        id=""pagination-options-menu-toggle-1""
        class=""  pf-c-options-menu__toggle-button""
        type=""button""
        aria-expanded=""false""
        aria-haspopup=""true""
        disabled=""""
      >
        <span class=""pf-c-options-menu__toggle-button-icon"">
          <svg
            style=""vertical-align: -0.125em;""
            fill=""currentColor""
            height=""1em"" width=""1em""
            viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
            aria-hidden=""true"" role=""img""
          >
            <path
              d=""{CaretDownIcon.IconDefinition.SvgPath}"">
            </path>
          </svg>
        </span>
      </button>
    </div>
  </div>
  <nav class=""pf-c-pagination__nav"" aria-label=""Pagination"">
    <div class=""pf-c-pagination__nav-control pf-m-first"">
      <button
        data-action=""first""
        aria-disabled=""true""
        aria-label=""Go to first page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""previous""
        aria-disabled=""true""
        aria-label=""Go to previous page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-page-select"">
      <input
        class=""pf-c-form-control""
        aria-label=""Current page""
        type=""number""
        disabled=""""
        min=""1""
        max=""0""
        value=""0""
      >
      <span aria-hidden=""true"">of 0</span>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""next""
        aria-disabled=""true""
        aria-label=""Go to next page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control pf-m-last"">
      <button
        data-action=""last""
        aria-disabled=""true""
        aria-label=""Go to last page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
  </nav>
</div>
");
    }

    [Fact]
    public void LastPageTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .AddUnmatched("id", "pagination-options-menu-1")
            .Add(p => p.OptionsToggleId, "pagination-options-menu-toggle-1")
            .Add(p => p.ItemCount, 20)
            .Add(p => p.PerPage, 10)
            .Add(p => p.Page, 2)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-pagination""
  id=""pagination-options-menu-1""
  style=""--pf-c-pagination__nav-page-select--c-form-control--width-chars: 2;""
>
  <div class=""pf-c-pagination__total-items""><b>11 - 20</b> of <b>20</b> </div>
  <div class=""pf-c-options-menu"">
    <div class=""pf-c-options-menu__toggle pf-m-plain pf-m-text"">
      <span class=""pf-c-options-menu__toggle-text""><b>11 - 20</b> of <b>20</b> </span>
      <button
        aria-label=""Items per page""
        id=""pagination-options-menu-toggle-1""
        class=""  pf-c-options-menu__toggle-button""
        type=""button""
        aria-expanded=""false""
        aria-haspopup=""true""
      >
        <span class=""pf-c-options-menu__toggle-button-icon"">
          <svg
            style=""vertical-align: -0.125em;""
            fill=""currentColor""
            height=""1em"" width=""1em""
            viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
            aria-hidden=""true"" role=""img""
          >
            <path
              d=""{CaretDownIcon.IconDefinition.SvgPath}"">
            </path>
          </svg>
        </span>
      </button>
    </div>
  </div>
  <nav class=""pf-c-pagination__nav"" aria-label=""Pagination"">
    <div class=""pf-c-pagination__nav-control pf-m-first"">
      <button
        data-action=""first""
        aria-disabled=""false""
        aria-label=""Go to first page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""previous""
        aria-disabled=""false""
        aria-label=""Go to previous page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-page-select"">
      <input
        class=""pf-c-form-control""
        aria-label=""Current page""
        type=""number""
        min=""1""
        max=""2""
        value=""2""
      >
      <span aria-hidden=""true"">of 2</span>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""next""
        aria-disabled=""true""
        aria-label=""Go to next page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control pf-m-last"">
      <button
        data-action=""last""
        aria-disabled=""true""
        aria-label=""Go to last page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
  </nav>
</div>
");
    }

    [Fact]
    public void CustomPerPageOptionsTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var options = new PerPageOptions[]
        {
            new() { Title = "some", Value = 1 }
        };

        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .AddUnmatched("id", "pagination-options-menu-1")
            .Add(p => p.OptionsToggleId, "pagination-options-menu-toggle-1")
            .Add(p => p.ItemCount, 40)
            .Add(p => p.PerPageOptions, options)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-pagination""
  id=""pagination-options-menu-1""
  style=""--pf-c-pagination__nav-page-select--c-form-control--width-chars: 2;""
>
  <div class=""pf-c-pagination__total-items""><b>1 - 10</b> of <b>40</b> </div>
  <div class=""pf-c-options-menu"">
    <div class=""pf-c-options-menu__toggle pf-m-plain pf-m-text"">
      <span class=""pf-c-options-menu__toggle-text""><b>1 - 10</b> of <b>40</b> </span>
      <button
        aria-label=""Items per page""
        id=""pagination-options-menu-toggle-1""
        class=""  pf-c-options-menu__toggle-button""
        type=""button""
        aria-expanded=""false""
        aria-haspopup=""true""
      >
        <span class=""pf-c-options-menu__toggle-button-icon"">
          <svg
            style=""vertical-align: -0.125em;""
            fill=""currentColor""
            height=""1em"" width=""1em""
            viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
            aria-hidden=""true"" role=""img""
           >
            <path
              d=""{CaretDownIcon.IconDefinition.SvgPath}"">
            </path>
          </svg>
        </span>
      </button>
    </div>
  </div>
  <nav class=""pf-c-pagination__nav"" aria-label=""Pagination"">
    <div class=""pf-c-pagination__nav-control pf-m-first"">
      <button
        data-action=""first""
        aria-disabled=""true""
        aria-label=""Go to first page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""previous""
        aria-disabled=""true""
        aria-label=""Go to previous page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-page-select"">
      <input
        class=""pf-c-form-control""
        aria-label=""Current page""
        type=""number""
        min=""1""
        max=""4""
        value=""1""
      >
      <span aria-hidden=""true"">of 4</span>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""next""
        aria-disabled=""false""
        aria-label=""Go to next page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control pf-m-last"">
      <button
        data-action=""last""
        aria-disabled=""false""
        aria-label=""Go to last page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
  </nav>
</div>
");
    }

    [Fact]
    public void EmptyPerPageOptionsTest()
    {
        // Arrange
        using var ctx = new TestContext();

        var options = new PerPageOptions[0];

        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .AddUnmatched("id", "pagination-options-menu-1")
            .Add(p => p.ItemCount, 40)
            .Add(p => p.PerPageOptions, options)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-pagination""
  id=""pagination-options-menu-1""
  style=""--pf-c-pagination__nav-page-select--c-form-control--width-chars: 2;""
>
  <div class=""pf-c-pagination__total-items""><b>1 - 10</b> of <b>40</b> </div>
  <div class=""pf-c-options-menu"">
    <div class=""pf-c-options-menu__toggle pf-m-plain pf-m-text""></div>
  </div>
  <nav class=""pf-c-pagination__nav"" aria-label=""Pagination"">
    <div class=""pf-c-pagination__nav-control pf-m-first"">
      <button
        data-action=""first""
        aria-disabled=""true""
        aria-label=""Go to first page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""previous""
        aria-disabled=""true""
        aria-label=""Go to previous page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-page-select"">
      <input
        class=""pf-c-form-control""
        aria-label=""Current page""
        type=""number""
        min=""1""
        max=""4""
        value=""1""
      >
      <span aria-hidden=""true"">of 4</span>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""next""
        aria-disabled=""false""
        aria-label=""Go to next page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control pf-m-last"">
      <button
        data-action=""last""
        aria-disabled=""false""
        aria-label=""Go to last page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
  </nav>
</div>
");
}

[Fact]
public void CustomStartEndTest()
{
    // Arrange
    using var ctx = new TestContext();

    // Setup Javascript interop
    ctx.SetupJavascriptInterop();

    // Act
    var cut = ctx.RenderComponent<Pagination>(parameters => parameters
        .AddUnmatched("id", "pagination-options-menu-1")
        .Add(p => p.OptionsToggleId, "pagination-options-menu-toggle-1")
        .Add(p => p.ItemCount, 40)
        .Add(p => p.ItemsStart, 5)
        .Add(p => p.ItemsEnd, 15)
    );

    // Assert
    cut.MarkupMatches(
$@"
<div
  class=""pf-c-pagination""
  id=""pagination-options-menu-1""
  style=""--pf-c-pagination__nav-page-select--c-form-control--width-chars: 2;""
>
  <div class=""pf-c-pagination__total-items""><b>1 - 10</b> of <b>40</b> </div>
  <div class=""pf-c-options-menu"">
    <div class=""pf-c-options-menu__toggle pf-m-plain pf-m-text"">
      <span class=""pf-c-options-menu__toggle-text""><b>5 - 15</b> of <b>40</b> </span>
      <button
        aria-label=""Items per page""
        id=""pagination-options-menu-toggle-1""
        class=""  pf-c-options-menu__toggle-button""
        type=""button""
        aria-expanded=""false""
        aria-haspopup=""true""
      >
        <span class=""pf-c-options-menu__toggle-button-icon"">
          <svg
            style=""vertical-align: -0.125em;""
            fill=""currentColor""
            height=""1em"" width=""1em""
            viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
            aria-hidden=""true"" role=""img""
          >
            <path
              d=""{CaretDownIcon.IconDefinition.SvgPath}"">
            </path>
          </svg>
        </span>
      </button>
    </div>
  </div>
  <nav class=""pf-c-pagination__nav"" aria-label=""Pagination"">
    <div class=""pf-c-pagination__nav-control pf-m-first"">
      <button
        data-action=""first""
        aria-disabled=""false""
        aria-label=""Go to first page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""previous""
        aria-disabled=""false""
        aria-label=""Go to previous page""
        class=""pf-c-button pf-m-plain"" type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-page-select"">
      <input
        class=""pf-c-form-control""
        aria-label=""Current page""
        type=""number""
        min=""1""
        max=""4""
        value=""1""
      >
      <span aria-hidden=""true"">of 4</span>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""next""
        aria-disabled=""false""
        aria-label=""Go to next page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control pf-m-last"">
      <button
        data-action=""last""
        aria-disabled=""false""
        aria-label=""Go to last page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
  </nav>
</div>
");
    }

    [Fact]
    public void TitlesTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var titles = new PaginationTitles
        {
            Items = "values",
            Page  = "books"
        };

        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .AddUnmatched("id", "pagination-options-menu-1")
            .Add(p => p.OptionsToggleId, "pagination-options-menu-toggle-1")
            .Add(p => p.ItemCount, 40)
            .Add(p => p.Titles, titles)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-pagination""
  id=""pagination-options-menu-1""
  style=""--pf-c-pagination__nav-page-select--c-form-control--width-chars: 2;""
>
  <div class=""pf-c-pagination__total-items""><b>1 - 10</b> of <b>40</b> values</div>
  <div class=""pf-c-options-menu"">
    <div class=""pf-c-options-menu__toggle pf-m-plain pf-m-text"">
      <span class=""pf-c-options-menu__toggle-text""><b>1 - 10</b> of <b>40</b> values</span>
      <button
        aria-label=""Items per page""
        id=""pagination-options-menu-toggle-1""
        class=""  pf-c-options-menu__toggle-button""
        type=""button""
        aria-expanded=""false""
        aria-haspopup=""true""
      >
        <span class=""pf-c-options-menu__toggle-button-icon"">
          <svg
            style=""vertical-align: -0.125em;""
            fill=""currentColor""
            height=""1em"" width=""1em""
            viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
            aria-hidden=""true"" role=""img""
          >
            <path
              d=""{CaretDownIcon.IconDefinition.SvgPath}"">
            </path>
          </svg>
        </span>
      </button>
    </div>
  </div>
  <nav class=""pf-c-pagination__nav"" aria-label=""Pagination"">
    <div class=""pf-c-pagination__nav-control pf-m-first"">
      <button
        data-action=""first""
        aria-disabled=""true""
        aria-label=""Go to first page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""previous""
        aria-disabled=""true""
        aria-label=""Go to previous page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-page-select"">
      <input
        class=""pf-c-form-control""
        aria-label=""Current page""
        type=""number""
        min=""1""
        max=""4""
        value=""1""
      >
      <span aria-hidden=""true"">of 4 bookss</span>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""next""
        aria-disabled=""false""
        aria-label=""Go to next page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control pf-m-last"">
      <button
        data-action=""last""
        aria-disabled=""false""
        aria-label=""Go to last page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
  </nav>
</div>
");
    }

    [Fact]
    public void UpDropDirectionTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Setup Javascript interop
        ctx.SetupJavascriptInterop();

        // Act
        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .AddUnmatched("id", "pagination-options-menu-1")
            .Add(p => p.OptionsToggleId, "pagination-options-menu-toggle-1")
            .Add(p => p.ItemCount, 40)
            .Add(p => p.DropDirection, DropdownDirection.Up)
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-pagination""
  id=""pagination-options-menu-1""
  style=""--pf-c-pagination__nav-page-select--c-form-control--width-chars: 2;""
>
  <div class=""pf-c-pagination__total-items""><b>1 - 10</b> of <b>40</b> </div>
  <div class=""pf-c-options-menu pf-m-top"">
    <div class=""pf-c-options-menu__toggle pf-m-plain pf-m-text"">
      <span class=""pf-c-options-menu__toggle-text""><b>1 - 10</b> of <b>40</b> </span>
      <button
        aria-label=""Items per page""
        id=""pagination-options-menu-toggle-1""
        class=""  pf-c-options-menu__toggle-button""
        type=""button""
        aria-expanded=""false""
        aria-haspopup=""true""
      >
        <span class=""pf-c-options-menu__toggle-button-icon"">
          <svg
            style=""vertical-align: -0.125em;""
            fill=""currentColor""
            height=""1em"" width=""1em""
            viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
            aria-hidden=""true"" role=""img""
          >
            <path
              d=""{CaretDownIcon.IconDefinition.SvgPath}"">
            </path>
          </svg>
        </span>
      </button>
    </div>
  </div>
  <nav class=""pf-c-pagination__nav"" aria-label=""Pagination"">
    <div class=""pf-c-pagination__nav-control pf-m-first"">
      <button
        data-action=""first""
        aria-disabled=""true""
        aria-label=""Go to first page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""previous""
        aria-disabled=""true""
        aria-label=""Go to previous page""
        class=""pf-c-button pf-m-plain pf-m-disabled""
        disabled=""""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleLeftIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-page-select"">
      <input
        class=""pf-c-form-control""
        aria-label=""Current page""
        type=""number""
        min=""1""
        max=""4""
        value=""1""
      >
      <span aria-hidden=""true"">of 4</span>
    </div>
    <div class=""pf-c-pagination__nav-control"">
      <button
        data-action=""next""
        aria-disabled=""false""
        aria-label=""Go to next page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-pagination__nav-control pf-m-last"">
      <button
        data-action=""last""
        aria-disabled=""false""
        aria-label=""Go to last page""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{AngleDoubleRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path
            d=""{AngleDoubleRightIcon.IconDefinition.SvgPath}"">
          </path>
        </svg>
      </button>
    </div>
  </nav>
</div>
");
    }
}
