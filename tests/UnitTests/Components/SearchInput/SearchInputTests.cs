namespace Blatternfly.UnitTests.Components;

public class SearchInputTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<SearchInput>(parameters => parameters
            .Add(p => p.AriaLabel, "simple text input")
            .Add(p => p.Value, "test input")
            .Add(p => p.OnChange, () => {})
            .Add(p => p.OnNextClick, () => {})
            .Add(p => p.OnPreviousClick, () => {})
            .Add(p => p.OnClear, () => {})
            .Add(p => p.OnSearch, () => {})
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-search-input""
  id=""pf-c-search-input-1""
>
  <div
    class=""pf-c-input-group""
  >
    <div
      class=""pf-c-search-input__bar""
    >
      <span
        class=""pf-c-search-input__text""
      >
        <span
          class=""pf-c-search-input__icon""
        >
          <svg
            aria-hidden=""true""
            fill=""currentColor""
            height=""1em""
            role=""img""
            style=""vertical-align: -0.125em;""
            viewBox=""0 0 512 512""
            width=""1em""
          >
            <path
              d=""M505 442.7L405.3 343c-4.5-4.5-10.6-7-17-7H372c27.6-35.3 44-79.7 44-128C416 93.1 322.9 0 208 0S0 93.1 0 208s93.1 208 208 208c48.3 0 92.7-16.4 128-44v16.3c0 6.4 2.5 12.5 7 17l99.7 99.7c9.4 9.4 24.6 9.4 33.9 0l28.3-28.3c9.4-9.4 9.4-24.6.1-34zM208 336c-70.7 0-128-57.2-128-128 0-70.7 57.2-128 128-128 70.7 0 128 57.2 128 128 0 70.7-57.2 128-128 128z""
            />
          </svg>
        </span>
        <input
          aria-label=""simple text input""
          class=""pf-c-search-input__text-input""
          value=""test input""
        />
      </span>
      <span
        class=""pf-c-search-input__utilities""
      >
        <span
          class=""pf-c-search-input__nav""
        >
          <button
            aria-disabled=""false""
            aria-label=""Previous""
            class=""pf-c-button pf-m-plain""
            type=""button""
          >
            <svg
              aria-hidden=""true""
              fill=""currentColor""
              height=""1em""
              role=""img""
              style=""vertical-align: -0.125em;""
              viewBox=""0 0 320 512""
              width=""1em""
            >
              <path
                d=""M177 159.7l136 136c9.4 9.4 9.4 24.6 0 33.9l-22.6 22.6c-9.4 9.4-24.6 9.4-33.9 0L160 255.9l-96.4 96.4c-9.4 9.4-24.6 9.4-33.9 0L7 329.7c-9.4-9.4-9.4-24.6 0-33.9l136-136c9.4-9.5 24.6-9.5 34-.1z""
              />
            </svg>
          </button>
          <button
            aria-disabled=""false""
            aria-label=""Next""
            class=""pf-c-button pf-m-plain""
            type=""button""
          >
            <svg
              aria-hidden=""true""
              fill=""currentColor""
              height=""1em""
              role=""img""
              style=""vertical-align: -0.125em;""
              viewBox=""0 0 320 512""
              width=""1em""
            >
              <path
                d=""M143 352.3L7 216.3c-9.4-9.4-9.4-24.6 0-33.9l22.6-22.6c9.4-9.4 24.6-9.4 33.9 0l96.4 96.4 96.4-96.4c9.4-9.4 24.6-9.4 33.9 0l22.6 22.6c9.4 9.4 9.4 24.6 0 33.9l-136 136c-9.2 9.4-24.4 9.4-33.8 0z""
              />
            </svg>
          </button>
        </span>
        <span
          class=""pf-c-search-input__clear""
        >
          <button
            aria-disabled=""false""
            aria-label=""Reset""
            class=""pf-c-button pf-m-plain""
            type=""button""
          >
            <svg
              aria-hidden=""true""
              fill=""currentColor""
              height=""1em""
              role=""img""
              style=""vertical-align: -0.125em;""
              viewBox=""0 0 352 512""
              width=""1em""
            >
              <path
                d=""M242.72 256l100.07-100.07c12.28-12.28 12.28-32.19 0-44.48l-22.24-22.24c-12.28-12.28-32.19-12.28-44.48 0L176 189.28 75.93 89.21c-12.28-12.28-32.19-12.28-44.48 0L9.21 111.45c-12.28 12.28-12.28 32.19 0 44.48L109.28 256 9.21 356.07c-12.28 12.28-12.28 32.19 0 44.48l22.24 22.24c12.28 12.28 32.2 12.28 44.48 0L176 322.72l100.07 100.07c12.28 12.28 32.2 12.28 44.48 0l22.24-22.24c12.28-12.28 12.28-32.19 0-44.48L242.72 256z""
              />
            </svg>
          </button>
        </span>
      </span>
    </div>
    <button
      aria-disabled=""false""
      aria-label=""Search""
      class=""pf-c-button pf-m-control""
      type=""submit""
    >
      <svg
        aria-hidden=""true""
        fill=""currentColor""
        height=""1em""
        role=""img""
        style=""vertical-align: -0.125em;""
        viewBox=""0 0 448 512""
        width=""1em""
      >
        <path
          d=""M190.5 66.9l22.2-22.2c9.4-9.4 24.6-9.4 33.9 0L441 239c9.4 9.4 9.4 24.6 0 33.9L246.6 467.3c-9.4 9.4-24.6 9.4-33.9 0l-22.2-22.2c-9.5-9.5-9.3-25 .4-34.3L311.4 296H24c-13.3 0-24-10.7-24-24v-32c0-13.3 10.7-24 24-24h287.4L190.9 101.2c-9.8-9.3-10-24.8-.4-34.3z""
        />
      </svg>
    </button>
  </div>
</div>
");
    }

    [Fact]
    public void WithHintTest()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<SearchInput>(parameters => parameters
            .Add(p => p.Hint, "test hint")
            .Add(p => p.AriaLabel, "simple text input")
            .Add(p => p.Value, "test input")
            .Add(p => p.OnChange, () => {})
            .Add(p => p.OnNextClick, () => {})
            .Add(p => p.OnPreviousClick, () => {})
            .Add(p => p.OnClear, () => {})
            .Add(p => p.OnSearch, () => {})
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-search-input""
  id=""pf-c-search-input-1""
>
  <div
    class=""pf-c-input-group""
  >
    <div
      class=""pf-c-search-input__bar""
    >
      <span
        class=""pf-c-search-input__text""
      >
        <span
          class=""pf-c-search-input__icon""
        >
          <svg
            aria-hidden=""true""
            fill=""currentColor""
            height=""1em""
            role=""img""
            style=""vertical-align: -0.125em;""
            viewBox=""0 0 512 512""
            width=""1em""
          >
            <path
              d=""M505 442.7L405.3 343c-4.5-4.5-10.6-7-17-7H372c27.6-35.3 44-79.7 44-128C416 93.1 322.9 0 208 0S0 93.1 0 208s93.1 208 208 208c48.3 0 92.7-16.4 128-44v16.3c0 6.4 2.5 12.5 7 17l99.7 99.7c9.4 9.4 24.6 9.4 33.9 0l28.3-28.3c9.4-9.4 9.4-24.6.1-34zM208 336c-70.7 0-128-57.2-128-128 0-70.7 57.2-128 128-128 70.7 0 128 57.2 128 128 0 70.7-57.2 128-128 128z""
            />
          </svg>
        </span>
        <input
          aria-hidden=""true""
          class=""pf-c-search-input__text-input pf-m-hint""
          disabled=""""
          type=""text""
          value=""test hint""
        />
        <input
          aria-label=""simple text input""
          class=""pf-c-search-input__text-input""
          value=""test input""
        />
      </span>
      <span
        class=""pf-c-search-input__utilities""
      >
        <span
          class=""pf-c-search-input__nav""
        >
          <button
            aria-disabled=""false""
            aria-label=""Previous""
            class=""pf-c-button pf-m-plain""
            type=""button""
          >
            <svg
              aria-hidden=""true""
              fill=""currentColor""
              height=""1em""
              role=""img""
              style=""vertical-align: -0.125em;""
              viewBox=""0 0 320 512""
              width=""1em""
            >
              <path
                d=""M177 159.7l136 136c9.4 9.4 9.4 24.6 0 33.9l-22.6 22.6c-9.4 9.4-24.6 9.4-33.9 0L160 255.9l-96.4 96.4c-9.4 9.4-24.6 9.4-33.9 0L7 329.7c-9.4-9.4-9.4-24.6 0-33.9l136-136c9.4-9.5 24.6-9.5 34-.1z""
              />
            </svg>
          </button>
          <button
            aria-disabled=""false""
            aria-label=""Next""
            class=""pf-c-button pf-m-plain""
            type=""button""
          >
            <svg
              aria-hidden=""true""
              fill=""currentColor""
              height=""1em""
              role=""img""
              style=""vertical-align: -0.125em;""
              viewBox=""0 0 320 512""
              width=""1em""
            >
              <path
                d=""M143 352.3L7 216.3c-9.4-9.4-9.4-24.6 0-33.9l22.6-22.6c9.4-9.4 24.6-9.4 33.9 0l96.4 96.4 96.4-96.4c9.4-9.4 24.6-9.4 33.9 0l22.6 22.6c9.4 9.4 9.4 24.6 0 33.9l-136 136c-9.2 9.4-24.4 9.4-33.8 0z""
              />
            </svg>
          </button>
        </span>
        <span
          class=""pf-c-search-input__clear""
        >
          <button
            aria-disabled=""false""
            aria-label=""Reset""
            class=""pf-c-button pf-m-plain""
            type=""button""
          >
            <svg
              aria-hidden=""true""
              fill=""currentColor""
              height=""1em""
              role=""img""
              style=""vertical-align: -0.125em;""
              viewBox=""0 0 352 512""
              width=""1em""
            >
              <path
                d=""M242.72 256l100.07-100.07c12.28-12.28 12.28-32.19 0-44.48l-22.24-22.24c-12.28-12.28-32.19-12.28-44.48 0L176 189.28 75.93 89.21c-12.28-12.28-32.19-12.28-44.48 0L9.21 111.45c-12.28 12.28-12.28 32.19 0 44.48L109.28 256 9.21 356.07c-12.28 12.28-12.28 32.19 0 44.48l22.24 22.24c12.28 12.28 32.2 12.28 44.48 0L176 322.72l100.07 100.07c12.28 12.28 32.2 12.28 44.48 0l22.24-22.24c12.28-12.28 12.28-32.19 0-44.48L242.72 256z""
              />
            </svg>
          </button>
        </span>
      </span>
    </div>
    <button
      aria-disabled=""false""
      aria-label=""Search""
      class=""pf-c-button pf-m-control""
      type=""submit""
    >
      <svg
        aria-hidden=""true""
        fill=""currentColor""
        height=""1em""
        role=""img""
        style=""vertical-align: -0.125em;""
        viewBox=""0 0 448 512""
        width=""1em""
      >
        <path
          d=""M190.5 66.9l22.2-22.2c9.4-9.4 24.6-9.4 33.9 0L441 239c9.4 9.4 9.4 24.6 0 33.9L246.6 467.3c-9.4 9.4-24.6 9.4-33.9 0l-22.2-22.2c-9.5-9.5-9.3-25 .4-34.3L311.4 296H24c-13.3 0-24-10.7-24-24v-32c0-13.3 10.7-24 24-24h287.4L190.9 101.2c-9.8-9.3-10-24.8-.4-34.3z""
        />
      </svg>
    </button>
  </div>
</div>
");
    }

    [Fact]
    public void WithResultCount()
    {
        // Arrange
        using var ctx = Helper.CreateTestContext();

        // Act
        var cut = ctx.RenderComponent<SearchInput>(parameters => parameters
            .Add(p => p.ResultsCount, "3")
            .Add(p => p.AriaLabel, "simple text input")
            .Add(p => p.Value, "test input")
            .Add(p => p.OnChange, () => {})
            .Add(p => p.OnNextClick, () => {})
            .Add(p => p.OnPreviousClick, () => {})
            .Add(p => p.OnClear, () => {})
            .Add(p => p.OnSearch, () => {})
            .AddUnmatched("data-testid", "test-id")
        );

        // Assert
        cut.MarkupMatches(
$@"
<div class=""pf-c-search-input"" data-testid=""test-id"" id=""pf-c-search-input-1"">
  <div class=""pf-c-input-group"">
    <div class=""pf-c-search-input__bar"">
      <span class=""pf-c-search-input__text"">
        <span class=""pf-c-search-input__icon"">
          <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""0 0 512 512"" aria-hidden=""true"" role=""img"">
            <path d=""M505 442.7L405.3 343c-4.5-4.5-10.6-7-17-7H372c27.6-35.3 44-79.7 44-128C416 93.1 322.9 0 208 0S0 93.1 0 208s93.1 208 208 208c48.3 0 92.7-16.4 128-44v16.3c0 6.4 2.5 12.5 7 17l99.7 99.7c9.4 9.4 24.6 9.4 33.9 0l28.3-28.3c9.4-9.4 9.4-24.6.1-34zM208 336c-70.7 0-128-57.2-128-128 0-70.7 57.2-128 128-128 70.7 0 128 57.2 128 128 0 70.7-57.2 128-128 128z""></path>
          </svg>
        </span>
        <input class=""pf-c-search-input__text-input"" aria-label=""simple text input"" value=""test input"">
      </span>
      <span class=""pf-c-search-input__utilities"">
        <span class=""pf-c-search-input__count""><span class=""pf-c-badge pf-m-read"">3</span></span>
        <span class=""pf-c-search-input__nav"">
          <button aria-disabled=""false"" aria-label=""Previous"" class=""pf-c-button pf-m-plain"" type=""button"">
            <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""0 0 320 512"" aria-hidden=""true"" role=""img"">
              <path d=""M177 159.7l136 136c9.4 9.4 9.4 24.6 0 33.9l-22.6 22.6c-9.4 9.4-24.6 9.4-33.9 0L160 255.9l-96.4 96.4c-9.4 9.4-24.6 9.4-33.9 0L7 329.7c-9.4-9.4-9.4-24.6 0-33.9l136-136c9.4-9.5 24.6-9.5 34-.1z""></path>
            </svg>
          </button>
          <button aria-disabled=""false"" aria-label=""Next"" class=""pf-c-button pf-m-plain"" type=""button"">
            <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""0 0 320 512"" aria-hidden=""true"" role=""img"">
              <path d=""M143 352.3L7 216.3c-9.4-9.4-9.4-24.6 0-33.9l22.6-22.6c9.4-9.4 24.6-9.4 33.9 0l96.4 96.4 96.4-96.4c9.4-9.4 24.6-9.4 33.9 0l22.6 22.6c9.4 9.4 9.4 24.6 0 33.9l-136 136c-9.2 9.4-24.4 9.4-33.8 0z""></path>
            </svg>
          </button>
        </span>
        <span class=""pf-c-search-input__clear"">
          <button aria-disabled=""false"" aria-label=""Reset"" class=""pf-c-button pf-m-plain"" type=""button"">
            <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""0 0 352 512""aria-hidden=""true"" role=""img"">
              <path d=""M242.72 256l100.07-100.07c12.28-12.28 12.28-32.19 0-44.48l-22.24-22.24c-12.28-12.28-32.19-12.28-44.48 0L176 189.28 75.93 89.21c-12.28-12.28-32.19-12.28-44.48 0L9.21 111.45c-12.28 12.28-12.28 32.19 0 44.48L109.28 256 9.21 356.07c-12.28 12.28-12.28 32.19 0 44.48l22.24 22.24c12.28 12.28 32.2 12.28 44.48 0L176 322.72l100.07 100.07c12.28 12.28 32.2 12.28 44.48 0l22.24-22.24c12.28-12.28 12.28-32.19 0-44.48L242.72 256z""></path>
            </svg>
          </button>
        </span>
      </span>
    </div>
    <button aria-disabled=""false"" aria-label=""Search"" class=""pf-c-button pf-m-control"" type=""submit"">
      <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""0 0 448 512"" aria-hidden=""true"" role=""img"">
        <path d=""M190.5 66.9l22.2-22.2c9.4-9.4 24.6-9.4 33.9 0L441 239c9.4 9.4 9.4 24.6 0 33.9L246.6 467.3c-9.4 9.4-24.6 9.4-33.9 0l-22.2-22.2c-9.5-9.5-9.3-25 .4-34.3L311.4 296H24c-13.3 0-24-10.7-24-24v-32c0-13.3 10.7-24 24-24h287.4L190.9 101.2c-9.8-9.3-10-24.8-.4-34.3z""></path>
      </svg>
    </button>
  </div>
</div>");
    }
}
