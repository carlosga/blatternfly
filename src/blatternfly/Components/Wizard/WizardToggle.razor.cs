namespace Blatternfly.Components;

public partial class WizardToggle : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>The wizard steps.</summary>
    [Parameter] public List<WizardStep> Steps { get; set; }

    /// <summary>The currently active WizardStep.</summary>
    [Parameter] public WizardStep ActiveStep { get; set; }

    /// <summary>Set to true to remove body padding.</summary>
    [Parameter] public bool HasNoBodyPadding { get; set; }

    /// <summary>If the nav is open.</summary>
    [Parameter] public bool IsNavOpen { get; set; }

    /// <summary>Callback function for when the nav is toggled.</summary>
    [Parameter] public EventCallback<bool> OnNavToggle { get; set;  }

    /// <summary>The button's aria-label.</summary>
    [Parameter] public string AriaLabel { get; set; } = "Wizard Toggle";

    /// <summary>Sets aria-labelledby on the main element.</summary>
    [Parameter] public string MainAriaLabelledBy { get; set; }

    /// <summary>The main's aria-label.</summary>
    [Parameter] public string MainAriaLabel { get; set; }

    /// <summary>If the wizard is in-page.</summary>
    [Parameter] public bool IsInPage { get; set; } = true;

    /// <summary>@beta Flag indicating the wizard has a drawer for at least one of the wizard steps.</summary>
    [Parameter] public bool HasDrawer { get; set; }

    /// <summary>@beta Flag indicating the wizard drawer is expanded.</summary>
    [Parameter] public bool IsDrawerExpanded { get; set; }

    [Parameter] public RenderFragment Nav { get; set; }

    private string CssClass => new CssBuilder("pf-c-wizard__toggle")
        .AddClass("pf-m-expanded", IsNavOpen)
        .Build();

    private string MainComponent     { get => IsInPage ? "div" : "main"; }
    private string AriaExpanded      { get => IsNavOpen ? "true" : "false"; }
    private int    ActiveStepIndex   { get; set; }
    private string ActiveStepName    { get; set; }
    private string ActiveStepSubName { get; set; }

    private async Task NavToggleHandler()
    {
        await OnNavToggle.InvokeAsync(!IsNavOpen);
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Steps is not null && Steps.Count > 0)
        {
            for (var i = 0; i < Steps.Count; i++)
            {
                if ((!string.IsNullOrEmpty(ActiveStep.Id) && Steps[i].Id == ActiveStep.Id) || (Steps[i].Name == ActiveStep.Name))
                {
                    ActiveStepIndex = i + 1;
                    ActiveStepName  = Steps[i].Name;
                    break;
                }
                // else if (Steps[i].HasSteps)
                // {
                //   foreach (var step in Steps[i].Steps)
                //   {
                //     if ((ActiveStep.Id.HasValue && step.Id == ActiveStep.Id) || step.Name == ActiveStep.Name)
                //     {
                //       ActiveStepIndex   = i + 1;
                //       ActiveStepName    = Steps[i].Name;
                //       ActiveStepSubName = step.Name;
                //       break;
                //     }
                //   }
                // }
            }
        }
    }
}