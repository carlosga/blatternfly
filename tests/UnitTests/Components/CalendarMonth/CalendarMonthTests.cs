using System;
using System.Globalization;
using Blatternfly.Components;
using Bunit;
using Xunit;

namespace Blatternfly.UnitTests.Components
{
    public class CalendarMonthTests
    {
        [Fact(Skip = "Disabled")]
        public void DefaultTest()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<CalendarMonth>(parameters => parameters
                .Add(p => p.Locale, CultureInfo.GetCultureInfo("en-US"))
                .Add(p => p.Date, new DateTime(2021, 08, 20))
            );

            // Assert
            cut.MarkupMatches(
$@"
<div class=""pf-c-calendar-month"">
  <div class=""pf-c-calendar-month__header"">
    <div class=""pf-c-calendar-month__header-nav-control pf-m-prev-month"">
      <button
        aria-disabled=""false""
        aria-label=""Previous month""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{ArrowLeftIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path d=""{ArrowLeftIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </button>
    </div>
    <div class=""pf-c-calendar-month__header-month"">
      <span id=""hidden-month-span-1"" hidden="""">Month</span>
      <div
        class=""pf-c-select""
        style=""width: 140px;""
      >
        <button
          id=""pf-select-toggle-id-6""
          aria-labelledby=""hidden-month-span-1 pf-select-toggle-id-3""
          aria-expanded=""false""
          aria-haspopup=""listbox""
          type=""button""
          class=""pf-c-select__toggle""
        >
          <div class=""pf-c-select__toggle-wrapper"">
            <span class=""pf-c-select__toggle-text"">August</span>
          </div>
          <span class=""pf-c-select__toggle-arrow"">
            <svg
              style=""vertical-align: -0.125em;""
              fill=""currentColor""
              height=""1em""
              width=""1em""
              viewBox=""{CaretDownIcon.IconDefinition.ViewBox}""
              aria-hidden=""true""
              role=""img""
            >
              <path d=""{CaretDownIcon.IconDefinition.SvgPath}""></path>
            </svg>
          </span>
        </button>
      </div>
    </div>
    <div class=""pf-c-calendar-month__header-year"">
      <input
        aria-label=""Select year""
        class=""pf-c-form-control""
        type=""number""
        aria-invalid=""false""
        value=""2021""
      >
    </div>
    <div class=""pf-c-calendar-month__header-nav-control pf-m-next-month"">
      <button
        aria-disabled=""false""
        aria-label=""Next month""
        class=""pf-c-button pf-m-plain""
        type=""button""
      >
        <svg
          style=""vertical-align: -0.125em;""
          fill=""currentColor""
          height=""1em""
          width=""1em""
          viewBox=""{ArrowRightIcon.IconDefinition.ViewBox}""
          aria-hidden=""true""
          role=""img""
        >
          <path d=""{ArrowRightIcon.IconDefinition.SvgPath}""></path>
        </svg>
      </button>
    </div>
  </div>
  <table class=""pf-c-calendar-month__calendar"">
    <thead class=""pf-c-calendar-month__days"">
      <tr>
        <th class=""pf-c-calendar-month__day"" scope=""col""><span class=""pf-screen-reader"">Sunday</span><span aria-hidden=""true"">S</span></th>
        <th class=""pf-c-calendar-month__day"" scope=""col""><span class=""pf-screen-reader"">Monday</span><span aria-hidden=""true"">M</span></th>
        <th class=""pf-c-calendar-month__day"" scope=""col""><span class=""pf-screen-reader"">Tuesday</span><span aria-hidden=""true"">T</span></th>
        <th class=""pf-c-calendar-month__day"" scope=""col""><span class=""pf-screen-reader"">Wednesday</span><span aria-hidden=""true"">W</span></th>
        <th class=""pf-c-calendar-month__day"" scope=""col""><span class=""pf-screen-reader"">Thursday</span><span aria-hidden=""true"">T</span></th>
        <th class=""pf-c-calendar-month__day"" scope=""col""><span class=""pf-screen-reader"">Friday</span><span aria-hidden=""true"">F</span></th>
        <th class=""pf-c-calendar-month__day"" scope=""col""><span class=""pf-screen-reader"">Saturday</span><span aria-hidden=""true"">S</span></th>
      </tr>
    </thead>
    <tbody>
      <tr class=""pf-c-calendar-month__dates-row"">
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""0"" aria-label=""01 August 2021"">1</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""02 August 2021"">2</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""03 August 2021"">3</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""04 August 2021"">4</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""05 August 2021"">5</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""06 August 2021"">6</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""07 August 2021"">7</button></td>
      </tr>
      <tr class=""pf-c-calendar-month__dates-row"">
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""08 August 2021"">8</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""09 August 2021"">9</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""10 August 2021"">10</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""11 August 2021"">11</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""12 August 2021"">12</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""13 August 2021"">13</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""14 August 2021"">14</button></td>
      </tr>
      <tr class=""pf-c-calendar-month__dates-row"">
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""15 August 2021"">15</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""16 August 2021"">16</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""17 August 2021"">17</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""18 August 2021"">18</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""19 August 2021"">19</button></td>
        <td class=""pf-c-calendar-month__dates-cell pf-m-current pf-m-selected"">
          <button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""0"" aria-label=""20 August 2021"">20</button>
        </td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""21 August 2021"">21</button></td>
      </tr>
      <tr class=""pf-c-calendar-month__dates-row"">
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""22 August 2021"">22</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""23 August 2021"">23</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""24 August 2021"">24</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""25 August 2021"">25</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""26 August 2021"">26</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""27 August 2021"">27</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""28 August 2021"">28</button></td>
      </tr>
      <tr class=""pf-c-calendar-month__dates-row"">
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""29 August 2021"">29</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""30 August 2021"">30</button></td>
        <td class=""pf-c-calendar-month__dates-cell""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""31 August 2021"">31</button></td>
        <td class=""pf-c-calendar-month__dates-cell pf-m-adjacent-month""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""01 September 2021"">1</button></td>
        <td class=""pf-c-calendar-month__dates-cell pf-m-adjacent-month""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""02 September 2021"">2</button></td>
        <td class=""pf-c-calendar-month__dates-cell pf-m-adjacent-month""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""03 September 2021"">3</button></td>
        <td class=""pf-c-calendar-month__dates-cell pf-m-adjacent-month""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""04 September 2021"">4</button></td>
      </tr>
      <tr class=""pf-c-calendar-month__dates-row"">
        <td class=""pf-c-calendar-month__dates-cell pf-m-adjacent-month""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""05 September 2021"">5</button></td>
        <td class=""pf-c-calendar-month__dates-cell pf-m-adjacent-month""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""06 September 2021"">6</button></td>
        <td class=""pf-c-calendar-month__dates-cell pf-m-adjacent-month""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""07 September 2021"">7</button></td>
        <td class=""pf-c-calendar-month__dates-cell pf-m-adjacent-month""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""08 September 2021"">8</button></td>
        <td class=""pf-c-calendar-month__dates-cell pf-m-adjacent-month""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""09 September 2021"">9</button></td>
        <td class=""pf-c-calendar-month__dates-cell pf-m-adjacent-month""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""10 September 2021"">10</button></td>
        <td class=""pf-c-calendar-month__dates-cell pf-m-adjacent-month""><button class=""pf-c-calendar-month__date"" type=""button"" tabindex=""-1"" aria-label=""11 September 2021"">11</button></td>
      </tr>
    </tbody>
  </table>
</div>
");
        }        
    }
}
