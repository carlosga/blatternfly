using Microsoft.AspNetCore.Components;

namespace Blatternfly.Components
{
    public sealed class WizardStep
    {
      /// Optional identifier.
      public int Id { get; set; }

      /// The name of the step.
      public string Name { get; set; }

      /// The component to render in the main body.
      public RenderFragment Component { get; set; }

      /// Setting to true hides the side nav and footer.
      public bool IsFinishedStep { get; set; }

      /// Enables or disables the step in the navigation. Enabled by default.
      public bool CanJumpTo { get; set; }

      /// Sub steps.
      public WizardStep[] Steps { get; set; }

      /// Props to pass to the WizardNavItem.
      public WizardNavItemProps StepNavItemProps { get; set; }

      /// (Unused if footer is controlled) Can change the Next button text.
      /// If nextButtonText is also set for the Wizard, this step specific one overrides it.
      public string NextButtonText { get; set; }

      /// (Unused if footer is controlled) The condition needed to enable the Next button.
      public bool EnableNext { get; set; }

      ///  (Unused if footer is controlled) True to hide the Cancel button.
      public bool HideCancelButton { get; set; }

      /// (Unused if footer is controlled) True to hide the Back button.
      public bool HideBackButton { get; set; }
      
      internal bool HasSteps { get => Steps is not null && Steps.Length > 0; }
    }
}
