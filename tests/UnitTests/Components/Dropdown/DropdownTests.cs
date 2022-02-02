namespace Blatternfly.UnitTests.Components;

public class DropdownTests
{
    [Fact]
    public void DefaultTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<Dropdown>(parameters => parameters
            .AddDropdownItems()
            .Add<DropdownToggle>(p => p.Toggle, toggleParams => toggleParams
                .AddUnmatched("id", "Dropdown Toggle")
                .AddChildContent("Dropdown")
            )
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-dropdown""
>
  <button
    id=""Dropdown Toggle""
    class=""pf-c-dropdown__toggle""
    type=""button""
    aria-expanded=""false""
    aria-haspopup=""true""
  >
    <span class=""pf-c-dropdown__toggle-text"">Dropdown</span>
    <span class=""pf-c-dropdown__toggle-icon"">
      <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""{CaretDownIcon.IconDefinition.ViewBox}"" aria-hidden=""true"" role=""img"">
        <path d=""{CaretDownIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </span>
  </button>
</div>
");
    }

    [Fact]
    public void RightAlignedTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<Dropdown>(parameters => parameters
            .AddDropdownItems()
            .Add(p => p.Position, DropdownPosition.Right)
            .Add<DropdownToggle>(p => p.Toggle, toggleParams => toggleParams
                .AddUnmatched("id", "Dropdown Toggle")
                .AddChildContent("Dropdown")
            )
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-dropdown pf-m-align-right""
>
  <button
    id=""Dropdown Toggle""
    class=""pf-c-dropdown__toggle""
    type=""button""
    aria-expanded=""false""
    aria-haspopup=""true""
  >
    <span class=""pf-c-dropdown__toggle-text"">Dropdown</span>
    <span class=""pf-c-dropdown__toggle-icon"">
      <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""{CaretDownIcon.IconDefinition.ViewBox}"" aria-hidden=""true"" role=""img"">
        <path d=""{CaretDownIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </span>
  </button>
</div>
");
    }

    [Fact]
    public void AlignmentBreakpointsTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        var alignments= new Alignment
        {
            Small       = Alignments.Left,
            Medium      = Alignments.Right,
            Large       = Alignments.Left,
            ExtraLarge  = Alignments.Right,
            ExtraLarge2 = Alignments.Left
        };

        // Register services
        ctx.Services.AddSingleton<IWindowObserver>(new WindowObserver(ctx.JSInterop.JSRuntime));

        // Act
        var cut = ctx.RenderComponent<Dropdown>(parameters => parameters
            .AddDropdownItems()
            .Add(p => p.Alignments, alignments)
            .Add(p => p.IsOpen, true)
            .Add<DropdownToggle>(p => p.Toggle, toggleParams => toggleParams
                .AddUnmatched("id", "Dropdown Toggle")
                .AddChildContent("Dropdown")
            )
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-dropdown pf-m-expanded""
                                        >
  <button
    id=""Dropdown Toggle""
    class=""pf-c-dropdown__toggle""
    type=""button""
    aria-expanded=""false""
    aria-haspopup=""true""
  >
    <span class=""pf-c-dropdown__toggle-text"">Dropdown</span>
    <span class=""pf-c-dropdown__toggle-icon"">
      <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""{CaretDownIcon.IconDefinition.ViewBox}"" aria-hidden=""true"" role=""img"">
        <path d=""{CaretDownIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </span>
  </button>
  <ul
    id=""pf-dropdown-menu__Dropdown Toggle""
    aria-labelledby=""Dropdown Toggle""
    class=""pf-c-dropdown__menu pf-m-align-left-on-sm pf-m-align-right-on-md pf-m-align-left-on-lg pf-m-align-right-on-xl pf-m-align-left-on-2xl""
    role=""menu""
  >
    <li
      role=""menuitem""
    >
      <a
        class=""pf-c-dropdown__menu-item""
        tabindex=""-1""
      >
        Link
      </a>
    </li>
    <li
      role=""menuitem""
    >
      <button
        class=""pf-c-dropdown__menu-item""
        type=""button""
        tabindex=""-1""
      >
        Action
      </button>
    </li>
    <li
      role=""menuitem""
    >
      <a
        aria-disabled=""true""
        class=""pf-m-disabled pf-c-dropdown__menu-item""
        tabindex=""-1""
      >
        Disabled Link
      </a>
    </li>
    <li
      role=""menuitem""
    >
      <button
        aria-disabled=""true""
        class=""pf-m-disabled pf-c-dropdown__menu-item""
        type=""button""
        tabindex=""-1""
      >
        Disabled Action
      </button>
    </li>
    <li
      role=""separator""
    >
      <div
        class=""pf-c-divider""
        role=""separator""
      />
    </li>
    <li
      role=""menuitem""
    >
      <a
        class=""pf-c-dropdown__menu-item""
        tabindex=""-1""
      >
        Separated Link
      </a>
    </li>
    <li
      role=""menuitem""
    >
      <button
        class=""pf-c-dropdown__menu-item""
        type=""button""
        tabindex=""-1""
      >
        Separated Action
      </button>
    </li>
  </ul>
</div>
");
    }

    [Fact]
    public void DropdownUpTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<Dropdown>(parameters => parameters
            .AddDropdownItems()
            .Add(p => p.Direction, DropdownDirection.Up)
            .Add<DropdownToggle>(p => p.Toggle, toggleParams => toggleParams
                .AddUnmatched("id", "Dropdown Toggle")
                .AddChildContent("Dropdown")
            )
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-dropdown pf-m-top""
>
  <button
    id=""Dropdown Toggle""
    class=""pf-c-dropdown__toggle""
    type=""button""
    aria-expanded=""false""
    aria-haspopup=""true""
  >
    <span class=""pf-c-dropdown__toggle-text"">Dropdown</span>
    <span class=""pf-c-dropdown__toggle-icon"">
      <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""{CaretDownIcon.IconDefinition.ViewBox}"" aria-hidden=""true"" role=""img"">
        <path d=""{CaretDownIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </span>
  </button>
</div>
");
    }

    [Fact]
    public void DropdownUpAndRightAlignedTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<Dropdown>(parameters => parameters
            .AddDropdownItems()
            .Add(p => p.Direction, DropdownDirection.Up)
            .Add(p => p.Position, DropdownPosition.Right)
            .Add<DropdownToggle>(p => p.Toggle, toggleParams => toggleParams
                .AddUnmatched("id", "Dropdown Toggle")
                .AddChildContent("Dropdown")
            )
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-dropdown pf-m-top pf-m-align-right""
>
  <button
    id=""Dropdown Toggle""
    class=""pf-c-dropdown__toggle""
    type=""button""
    aria-expanded=""false""
    aria-haspopup=""true""
  >
    <span class=""pf-c-dropdown__toggle-text"">Dropdown</span>
    <span class=""pf-c-dropdown__toggle-icon"">
      <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""{CaretDownIcon.IconDefinition.ViewBox}"" aria-hidden=""true"" role=""img"">
        <path d=""{CaretDownIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </span>
  </button>
</div>
");
    }

    [Fact]
    public void ExpandedTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<Dropdown>(parameters => parameters
            .AddDropdownItems()
            .Add(p => p.IsOpen, true)
            .Add<DropdownToggle>(p => p.Toggle, toggleParams => toggleParams
                .AddUnmatched("id", "Dropdown Toggle")
                .AddChildContent("Dropdown")
            )
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-dropdown pf-m-expanded""
                                        >
  <button
    id=""Dropdown Toggle""
    class=""pf-c-dropdown__toggle""
    type=""button""
    aria-expanded=""false""
    aria-haspopup=""true""
  >
    <span class=""pf-c-dropdown__toggle-text"">Dropdown</span>
    <span class=""pf-c-dropdown__toggle-icon"">
      <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""{CaretDownIcon.IconDefinition.ViewBox}"" aria-hidden=""true"" role=""img"">
        <path d=""{CaretDownIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </span>
  </button>
  <ul
    id=""pf-dropdown-menu__Dropdown Toggle""
    aria-labelledby=""Dropdown Toggle""
    class=""pf-c-dropdown__menu""
    role=""menu""
  >
    <li
      role=""menuitem""
    >
      <a
        class=""pf-c-dropdown__menu-item""
        tabindex=""-1""
      >
        Link
      </a>
    </li>
    <li
      role=""menuitem""
    >
      <button
        class=""pf-c-dropdown__menu-item""
        type=""button""
        tabindex=""-1""
      >
        Action
      </button>
    </li>
    <li
      role=""menuitem""
    >
      <a
        aria-disabled=""true""
        class=""pf-m-disabled pf-c-dropdown__menu-item""
        tabindex=""-1""
      >
        Disabled Link
      </a>
    </li>
    <li
      role=""menuitem""
    >
      <button
        aria-disabled=""true""
        class=""pf-m-disabled pf-c-dropdown__menu-item""
        type=""button""
        tabindex=""-1""
      >
        Disabled Action
      </button>
    </li>
    <li
      role=""separator""
    >
      <div
        class=""pf-c-divider""
        role=""separator""
      />
    </li>
    <li
      role=""menuitem""
    >
      <a
        class=""pf-c-dropdown__menu-item""
        tabindex=""-1""
      >
        Separated Link
      </a>
    </li>
    <li
      role=""menuitem""
    >
      <button
        class=""pf-c-dropdown__menu-item""
        type=""button""
        tabindex=""-1""
      >
        Separated Action
      </button>
    </li>
  </ul>
</div>
");
    }

    [Fact]
    public void PrimaryTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<Dropdown>(parameters => parameters
            .AddDropdownItems()
            .Add<DropdownToggle>(p => p.Toggle, toggleParams => toggleParams
                .AddUnmatched("id", "Dropdown Toggle")
                .Add(p => p.ToggleVariant, ToggleVariant.Primary)
                .AddChildContent("Dropdown")
            )
        );

        // Assert
        cut.MarkupMatches(
$@"
<div
  class=""pf-c-dropdown""
>
  <button
    id=""Dropdown Toggle""
    class=""pf-c-dropdown__toggle pf-m-primary""
    type=""button""
    aria-expanded=""false""
    aria-haspopup=""true""
  >
    <span class=""pf-c-dropdown__toggle-text"">Dropdown</span>
    <span class=""pf-c-dropdown__toggle-icon"">
      <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""{CaretDownIcon.IconDefinition.ViewBox}"" aria-hidden=""true"" role=""img"">
        <path d=""{CaretDownIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </span>
  </button>
</div>
");
    }

    [Fact]
    public void SecondaryTest()
    {
        // Arrange
        using var ctx = new TestContext();

        // Add service configuration
        ctx.AddServices();

        // Act
        var cut = ctx.RenderComponent<Dropdown>(parameters => parameters
            .AddDropdownItems()
            .Add<DropdownToggle>(p => p.Toggle, toggleParams => toggleParams
                .AddUnmatched("id", "Dropdown Toggle")
                .Add(p => p.ToggleVariant, ToggleVariant.Secondary)
                .AddChildContent("Dropdown")
            )
        );

        // Assert
        cut.MarkupMatches(
            $@"
<div
  class=""pf-c-dropdown""
>
  <button
    id=""Dropdown Toggle""
    class=""pf-c-dropdown__toggle pf-m-secondary""
    type=""button""
    aria-expanded=""false""
    aria-haspopup=""true""
  >
    <span class=""pf-c-dropdown__toggle-text"">Dropdown</span>
    <span class=""pf-c-dropdown__toggle-icon"">
      <svg style=""vertical-align: -0.125em;"" fill=""currentColor"" height=""1em"" width=""1em"" viewBox=""{CaretDownIcon.IconDefinition.ViewBox}"" aria-hidden=""true"" role=""img"">
        <path d=""{CaretDownIcon.IconDefinition.SvgPath}""></path>
      </svg>
    </span>
  </button>
</div>
");
    }
}
