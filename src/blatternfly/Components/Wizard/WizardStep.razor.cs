namespace Blatternfly.Components;

public partial class WizardStep : ComponentBase
{
    [CascadingParameter] private Wizard Parent { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Optional identifier.
    [Parameter] public string Id { get; set; }

    /// Optional step index
    [Parameter] public int? Index { get; set; }

    /// The name of the step.
    [Parameter] public string Name { get; set; }

    /// @beta The content to render in the drawer panel (use when hasDrawer prop is set on the wizard).
    [Parameter] public RenderFragment DrawerPanelContent { get; set; }

    /// @beta Custom drawer toggle button that opens the drawer.
    [Parameter] public RenderFragment DrawerToggleButton { get; set; }

    /// Setting to true hides the side nav and footer.
    [Parameter] public bool IsFinishedStep { get; set; }

    /// Enables or disables the step in the navigation. Enabled by default.
    [Parameter] public bool CanJumpTo { get; set; } = true;

    /// (Unused if footer is controlled) Can change the Next button text.
    /// If nextButtonText is also set for the Wizard, this step specific one overrides it.
    [Parameter] public string NextButtonText { get; set; }

    /// (Unused if footer is controlled) The condition needed to enable the Next button.
    [Parameter] public bool? EnableNext { get; set; }

    ///  (Unused if footer is controlled) True to hide the Cancel button.
    [Parameter] public bool HideCancelButton { get; set; }

    /// (Unused if footer is controlled) True to hide the Back button.
    [Parameter] public bool HideBackButton { get; set; }

    /// Flag to disable the step in the navigation.
    [Parameter] public bool IsDisabled { get; set; }

    private bool IsDisabledValue => !CanJumpTo || IsDisabled;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Parent.AddStep(this);
    }
}