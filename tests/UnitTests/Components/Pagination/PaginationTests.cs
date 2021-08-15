using Blatternfly.Components;
using Blatternfly.Observers;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class PaginationTests
    {
        [Fact]
        public void Default()
        {
            // Arrange
            using var ctx = new TestContext();
            ctx.JSInterop.Mode = JSRuntimeMode.Strict;
            
            ctx.JSInterop.SetupVoid("Blatternfly.Dropdown.onKeyDown", _ => true);
            ctx.JSInterop.Setup<Size>("Blatternfly.Window.innerSize").SetResult(new Size { Width = 3840, Height = 2160 });

            // Register services
            ctx.Services.AddSingleton<IWindowObserver>(new WindowObserver(ctx.JSInterop.JSRuntime));
            
            // Act
            var cut = ctx.RenderComponent<Pagination>(parameters => parameters
                .Add(p => p.ItemCount, 20)
                .AddUnmatched("id", "pagination-options-menu-1")
            );

            // Assert
            cut.MarkupMatches(
@$"
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
      <input class=""pf-c-form-control"" aria-label=""Current page"" type=""number"" min=""1"" max=""2"" value=""1"">
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
    }
}
