namespace Blatternfly.Components;

public partial class Wizard : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Custom width of the wizard.</summary>
    [Parameter] public int? Width { get; set; }

    /// <summary>Custom height of the wizard.</summary>
    [Parameter] public int? Height { get; set; }

    /// <summary>The wizard title to display if header is desired.</summary>
    [Parameter] public string Title { get; set; }

    /// <summary>An optional id for the title.</summary>
    [Parameter] public string TitleId { get; set; }

    /// <summary>An optional id for the description.</summary>
    [Parameter] public string DescriptionId { get; set; }

    /// <summary>The wizard description.</summary>
    [Parameter] public RenderFragment Description { get; set; }

    /// <summary>Component type of the description.</summary>
    [Parameter] public WizardDescriptionComponent DescriptionComponent { get; set; } = WizardDescriptionComponent.p;

    /// <summary>Flag indicating whether the close button should be in the header.</summary>
    [Parameter] public bool HideClose { get; set; }

    /// <summary>Callback function to close the wizard.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }

    /// <summary>Callback function when a step in the nav is clicked.</summary>
    [Parameter] public EventCallback<WizardStepChangedEventArgs> OnGoToStep { get; set; }

    /// <summary>The current step the wizard is on (1 or higher).</summary>
    [Parameter] public int StartAtStep { get; set; } = 1;

    /// <summary>Aria-label for the Nav.</summary>
    [Parameter] public string NavAriaLabel { get; set; }

    /// <summary>Sets aria-labelledby on nav element.</summary>
    [Parameter] public string NavAriaLabelledBy { get; set; }

    /// <summary>Aria-label for the main element.</summary>
    [Parameter] public string MainAriaLabel { get; set; }

    /// <summary>Sets aria-labelledby on the main element.</summary>
    [Parameter] public string MainAriaLabelledBy { get; set; }

    /// <summary>Can remove the default padding around the main body content by setting this to true.</summary>
    [Parameter] public bool HasNoBodyPadding { get; set; }

    /// <summary>(Use to control the footer) Passing in a footer component lets you control the buttons yourself.</summary>
    [Parameter] public RenderFragment Footer { get; set; }

    /// <summary>(Unused if footer is controlled) Callback function to save at the end of the wizard, if not specified uses onClose.</summary>
    [Parameter] public EventCallback OnSave { get; set; }

    /// <summary>(Unused if footer is controlled) Callback function after Next button is clicked.</summary>
    [Parameter] public EventCallback<WizardStepChangedEventArgs> OnNext { get; set; }

    /// <summary>(Unused if footer is controlled) Callback function after Back button is clicked.</summary>
    [Parameter] public EventCallback<WizardStepChangedEventArgs> OnBack { get; set; }

    /// <summary>(Unused if footer is controlled) The Next button text.</summary>
    [Parameter] public string NextButtonText { get; set; } = "Next";

    /// <summary>(Unused if footer is controlled) The Back button text.</summary>
    [Parameter] public string BackButtonText { get; set; } = "Back";

    /// <summary>(Unused if footer is controlled) The Cancel button text.</summary>
    [Parameter] public string CancelButtonText { get; set; } = "Cancel";

    /// <summary>(Unused if footer is controlled) aria-label for the close button.</summary>
    [Parameter] public string CloseButtonAriaLabel { get; set; } = "Close";

    /// <summary>Flag indicating Wizard modal is open. Wizard will be placed into a modal if this prop is provided.</summary>
    [Parameter] public bool? IsOpen { get; set; }

    /// <summary>Flag indicating nav items with sub steps are expandable.</summary>
    [Parameter] public bool IsNavExpandable { get; set; }

    /// <summary>Callback function to signal the current step in the wizard.</summary>
    [Parameter] public EventCallback<WizardStep> OnCurrentStepChanged { get; set; }

    [Parameter] public int  CurrentStep { get; set; }

    [Parameter] public bool IsNavOpen { get; set; }

    private string CssStyle => new StyleBuilder()
        .AddStyle("height", () => $"{Height.Value}px", Height.HasValue)
        .AddStyle("width" , () => $"{Width.Value}px" , Width.HasValue)
        .Build();

    private string CssClass => new CssBuilder("pf-c-wizard")
        .AddClass("pf-m-finished", ActiveStep is not null && ActiveStep.IsFinishedStep)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private static int _currentId = 1;

    private int _newId;

    private List<WizardStep> FlattenedSteps { get; set; } = new(5);

    internal int  GetFlattenedStepsIndex(WizardStep step) => FlattenedSteps.IndexOf(step) + 1;
    internal bool IsCurrentStep(WizardStep step)          => HasSteps && ActiveStep.Name == step.Name;

    internal bool IsValid { get => ActiveStep is not null && ActiveStep.EnableNext.HasValue ? ActiveStep.EnableNext.Value : true; }

    private bool       IsInPage        { get => !IsOpen.HasValue; }
    private bool       HasSteps        { get => FlattenedSteps.Count > 0; }
    private int        AdjustedStep    { get => HasSteps && FlattenedSteps.Count < CurrentStep ? FlattenedSteps.Count : CurrentStep; }
    private WizardStep ActiveStep      { get => HasSteps ? FlattenedSteps[AdjustedStep - 1] : null; }
    private bool       FirstStep       { get => HasSteps && ActiveStep == FlattenedSteps[0]; }

    private string FooterNextButtonText { get => ActiveStep?.NextButtonText ?? NextButtonText; }
    private string NavAriaLabelBy
    {
        get
        {
            var cond1 = Title ?? NavAriaLabelledBy;
            var cond2 = NavAriaLabelledBy ?? TitleId;

            if (!string.IsNullOrEmpty(cond1) && !string.IsNullOrEmpty(cond2))
            {
                return cond2;
            }
            else if (!string.IsNullOrEmpty(cond1) && string.IsNullOrEmpty(cond2))
            {
                return cond1;
            }
            else if (!string.IsNullOrEmpty(cond1) && string.IsNullOrEmpty(cond2))
            {
                return cond2;
            }
            return null;
        }
    }

    private string MainAriaLabelBy
    {
        get
        {
            var cond1 = Title ?? MainAriaLabelledBy;
            var cond2 = MainAriaLabelledBy ?? TitleId;

            if (!string.IsNullOrEmpty(cond1) && !string.IsNullOrEmpty(cond2))
            {
                return cond2;
            }
            else if (!string.IsNullOrEmpty(cond1) && string.IsNullOrEmpty(cond2))
            {
                return cond1;
            }
            else if (!string.IsNullOrEmpty(cond1) && string.IsNullOrEmpty(cond2))
            {
                return cond2;
            }
            return null;
        }
    }

    internal void AddStep(WizardStep step)
    {
        FlattenedSteps.Add(step);
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        _newId          = Interlocked.Increment(ref _currentId);
        TitleId       ??= $"pf-wizard-title-{_newId}";
        DescriptionId ??= $"pf-wizard-description-{_newId}";
        CurrentStep     = StartAtStep;
        IsNavOpen       = false;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await SetCurrentStepAsync(StartAtStep);
            StateHasChanged();
        }
    }

    internal async Task SetCurrentStepAsync(int step)
    {
        CurrentStep = step;

        var currentStepObject = FlattenedSteps[CurrentStep - 1];

        await OnCurrentStepChanged.InvokeAsync(currentStepObject);
    }

    internal async Task GoToStep(int step)
    {
        var maxSteps = FlattenedSteps.Count;
        if (step < 1)
        {
            step = 1;
        }
        else if (step > maxSteps)
        {
            step = maxSteps;
        }
        var args = new WizardStepChangedEventArgs
        {
            NewStepId     = FlattenedSteps[step - 1].Id,
            NewStepIndex  = FlattenedSteps[step - 1].Index,
            NewStepName   = FlattenedSteps[step - 1].Name,
            PrevStepId    = FlattenedSteps[CurrentStep - 1].Id,
            PrevStepIndex = FlattenedSteps[CurrentStep - 1].Index,
            PrevStepName  = FlattenedSteps[CurrentStep - 1].Name
        };
        await SetCurrentStepAsync(step);
        IsNavOpen = false;
        await OnGoToStep.InvokeAsync(args);
    }

    private async Task OnNextHandler()
    {
        var maxSteps = FlattenedSteps.Count;
        if (CurrentStep >= maxSteps)
        {
            // Hit the save button at the end of the wizard
            await OnSave.InvokeAsync();
            await OnClose.InvokeAsync();
        }
        else
        {
            var newStep = CurrentStep;

            for (var nextStep = CurrentStep; nextStep <= maxSteps; nextStep++)
            {
                if (nextStep >= FlattenedSteps.Count)
                {
                    return;
                }

                if (!FlattenedSteps[nextStep].IsDisabled)
                {
                    newStep = nextStep + 1;
                    break;
                }
            }
            var args = new WizardStepChangedEventArgs
            {
                NewStepId     = FlattenedSteps[newStep - 1].Id,
                NewStepIndex  = FlattenedSteps[newStep - 1].Index,
                NewStepName   = FlattenedSteps[newStep - 1].Name,
                PrevStepId    = FlattenedSteps[CurrentStep - 1].Id,
                PrevStepIndex = FlattenedSteps[CurrentStep - 1].Index,
                PrevStepName  = FlattenedSteps[CurrentStep - 1].Name
            };
            await SetCurrentStepAsync(newStep);
            await OnNext.InvokeAsync(args);
        }
    }

    private async Task OnBackHandler()
    {
        if (FlattenedSteps.Count < CurrentStep)
        {
            // Previous step was removed, just update the currentStep state
            CurrentStep = FlattenedSteps.Count;
        }
        else
        {
            var newStep = CurrentStep;

            for (var prevStep = CurrentStep; prevStep >= 0; prevStep--)
            {
                if ((prevStep - 2) < 0)
                {
                    return;
                }

                if (!FlattenedSteps[prevStep - 2].IsDisabled)
                {
                    newStep = prevStep - 1 <= 1 ? 1 : prevStep - 1;
                    break;
                }
            }

            var args = new WizardStepChangedEventArgs
            {
                NewStepId     = FlattenedSteps[newStep - 1].Id,
                NewStepIndex  = FlattenedSteps[newStep - 1].Index,
                NewStepName   = FlattenedSteps[newStep - 1].Name,
                PrevStepId    = FlattenedSteps[CurrentStep - 1].Id,
                PrevStepIndex = FlattenedSteps[CurrentStep - 1].Index,
                PrevStepName  = FlattenedSteps[CurrentStep - 1].Name
            };
            await SetCurrentStepAsync(newStep);
            await OnBack.InvokeAsync(args);
        }
    }

    private async Task OnCloseHandler()
    {
        await OnClose.InvokeAsync();
    }

    private void OnNavToggle()
    {
        IsNavOpen = !IsNavOpen;
    }
}