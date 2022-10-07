using System.Globalization;

namespace Blatternfly.Components;

public partial class Slider : ComponentBase
{
    private ElementReference SliderRailRef { get; set; }
    private ElementReference ThumbRef      { get; set; }

    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }
    [Inject] private IDomUtils DomUtils { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Flag indicating if the slider is discrete for custom steps. This will cause the slider to snap to the closest value.</summary>
    [Parameter] public bool AreCustomStepsContinuous { get; set; }

    /// <summary>One or more id's to use for the slider thumb description.</summary>
    [Parameter] public string AriaDescribedBy { get; set; }

    /// <summary>One or more id's to use for the slider thumb label.</summary>
    [Parameter] public string AriaLabelledBy { get; set; }

    /// <summary>Array of custom slider step objects (value and label of each step) for the slider.</summary>
    [Parameter] public SliderStepObject[] CustomSteps { get; set; }

    /// <summary>Adds a tooltip over the slider thumb containing the current value.</summary>
    [Parameter] public bool HasTooltipOverThumb { get; set; }

    /// <summary>Aria label for the input field.</summary>
    [Parameter] public string InputAriaLabel { get; set; } = "Slider value input";

    /// <summary>Label that is place after the input field.</summary>
    [Parameter] public string InputLabel { get; set; }

    /// <summary>Position of the input.</summary>
    [Parameter] public SliderInputPosition InputPosition { get; set; } = SliderInputPosition.Right;

    /// <summary>Value displayed in the input field.</summary>
    [Parameter] public decimal InputValue { get; set; }

    /// <summary>Value change callback. This is called when the slider input value changes.</summary>
    [Parameter] public EventCallback<SliderInputValueChangedEventArgs> InputValueChanged { get; set; }

    /// <summary>Adds disabled styling and disables the slider and the input component is present.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Flag to show value input field.</summary>
    [Parameter] public bool IsInputVisible { get; set; }

    /// <summary>Actions placed to the left of the slider.</summary>
    [Parameter] public RenderFragment LeftActions { get; set; }

    /// <summary>Minimum permitted value.</summary>
    [Parameter] public decimal Min { get; set; }

    /// <summary>The maximum permitted value.</summary>
    [Parameter] public decimal Max { get; set; } = 100.0M;

    /// <summary>Actions placed to the right of the slider.</summary>
    [Parameter] public RenderFragment RightActions { get; set; }

    /// <summary>Flag to indicate if boundaries should be shown for slider that does not have custom steps.</summary>
    [Parameter] public bool ShowBoundaries { get; set; } = true;

    /// <summary>Flag to indicate if ticks should be shown for slider that does not have custom steps.</summary>
    [Parameter] public bool ShowTicks { get; set; }

    /// <summary>The step interval.</summary>
    [Parameter] public decimal Step { get; set; } = 1.0M;

    /// <summary>Aria label for the thumb.</summary>
    [Parameter] public string ThumbAriaLabel { get; set; } = "Value";

    /// <summary>Current value.</summary>
    [Parameter] public decimal Value { get; set; }

    /// <summary>Form control value changed event callback.</summary>
    [Parameter] public EventCallback<decimal> ValueChanged { get; set; }

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-c-slider--value"                             , StylePercent.ToString(CultureInfo.InvariantCulture) + '%')
        .AddStyle("--pf-c-slider__value--c-form-control--width-chars", InputValue.ToString(CultureInfo.InvariantCulture).Length)
        .AddStyleFromAttributes(AdditionalAttributes)
        .Build();

    private string CssClass => new CssBuilder("pf-c-slider")
        .AddClass("pf-m-disabled", IsDisabled)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private decimal CurrentValue
    {
        get => Value;
        set
        {
            if (!EqualityComparer<decimal>.Default.Equals(value, Value))
            {
                Value = value;
                _ = ValueChanged.InvokeAsync(Value);
                StateHasChanged();
            }
        }
    }

    private decimal GetStepValue(decimal val, decimal min, decimal max) => ((val - min) * 100) / (max - min);
    private decimal GetPercentage(decimal current, decimal max) => (100.0M * current) / max;

    private bool     HasCustomSteps { get => CustomSteps is { Length: > 0 }; }
    private decimal  StylePercent   { get => ((CurrentValue - Min) * 100.0M) / (Max - Min); }
    private string   TooltipId      { get; set; }
    private string   ThumbId        { get; set; }
    private string   ThumbStyle     { get; set; }
    private bool     IsDragging     { get; set; }
    private int      TabIndex       { get => IsDisabled ? -1 : 0; }
    private decimal? SnapValue      { get; set; }
    private decimal  Diff           { get; set; }
    private decimal  ValueMin       { get => HasCustomSteps ? CustomSteps[0].Value : Min; }
    private decimal  ValueMax       { get => HasCustomSteps ? CustomSteps[^1].Value : Max; }
    private string   AriaDisabled   { get => IsDisabled ? "true" : "false"; }
    private string   AriaValueMin   { get => Min.ToString(CultureInfo.InvariantCulture); }
    private string   AriaValueMax   { get => Max.ToString(CultureInfo.InvariantCulture); }
    private string   AriaValueNow   { get => Value.ToString(CultureInfo.InvariantCulture); }
    private string   AriaValueText
    {
        get
        {
            if (!AreCustomStepsContinuous && HasCustomSteps)
            {
                var matchingStep = CustomSteps.SingleOrDefault(stepObj => stepObj.Value == CurrentValue);
                if (matchingStep is not null)
                {
                    return matchingStep.Label;
                }
            }
            return CurrentValue.ToString(CultureInfo.InvariantCulture);
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        TooltipId = ComponentIdGenerator.Generate("pf-c-slider-tooltip");
        ThumbId   = ComponentIdGenerator.Generate("pf-c-slider-thumb");
    }

    private async Task OnSliderRailClick(MouseEventArgs args)
    {
        if (IsDisabled)
        {
            return;
        }

        await HandleThumbMove(args);

        if (SnapValue.HasValue && !AreCustomStepsContinuous)
        {
            ThumbStyle   = $"--pf-c-slider--value: {SnapValue?.ToString(CultureInfo.InvariantCulture)}%";
            CurrentValue = SnapValue.Value;
        }
    }

    private async Task OnThumbClick(MouseEventArgs args)
    {
        if (IsDisabled)
        {
            return;
        }
        await ThumbRef.FocusAsync();
    }

    private async Task HandleMouseDown(MouseEventArgs args)
    {
        if (IsDisabled)
        {
            return;
        }

        var boudingClientRect = await DomUtils.GetBoundingClientRectAsync(ThumbRef);

        Diff       = (decimal)args.ClientX - (decimal)boudingClientRect.Left;
        IsDragging = true;
    }

    private async Task HandleMouseMove(MouseEventArgs args)
    {
        if (!IsDragging)
        {
            return;
        }

        await HandleThumbMove(args);
    }

    private Task HandleMouseUp(MouseEventArgs args)
    {
        IsDragging = false;
        Diff       = 0;

        return Task.CompletedTask;
    }

    private Task HandleMouseLeave()
    {
        if (IsDragging)
        {
            IsDragging = false;
            Diff       = 0;
        }

        return Task.CompletedTask;
    }

    private void HandleThumbKeys(KeyboardEventArgs args)
    {
        if (IsDisabled)
        {
            return;
        }

        var key = args.Key;
        if (key != Keys.ArrowLeft && key != Keys.ArrowRight)
        {
            return;
        }

        var newValue = CurrentValue;
        if (!AreCustomStepsContinuous && HasCustomSteps)
        {
            var currentStep = CustomSteps.SingleOrDefault(stepObj => stepObj.Value == CurrentValue);
            var stepIndex   = Array.IndexOf(CustomSteps, currentStep);
            if (key == Keys.ArrowRight)
            {
                if (stepIndex + 1 < CustomSteps.Length)
                {
                    newValue = CustomSteps[stepIndex + 1].Value;
                }
            }
            else if (key == Keys.ArrowLeft)
            {
                if (stepIndex - 1 >= 0)
                {
                newValue = CustomSteps[stepIndex - 1].Value;
                }
            }
        }
        else
        {
            if (key == Keys.ArrowRight)
            {
                newValue = CurrentValue + Step <= Max ? CurrentValue + Step : Max;
            }
            else if (key == Keys.ArrowLeft)
            {
                newValue = CurrentValue - Step >= Min ? CurrentValue - Step : Min;
            }
        }

        if (newValue != CurrentValue)
        {
            ThumbStyle   = $"--pf-c-slider--value:{newValue.ToString(CultureInfo.InvariantCulture)}%;";
            CurrentValue = newValue;
        }
    }

    private async Task HandleKeyPressOnInput(KeyboardEventArgs args)
    {
        if (args.Key == Keys.Enter)
        {
            if (InputValueChanged.HasDelegate)
            {
                await InputValueChanged.InvokeAsync(new SliderInputValueChangedEventArgs { Value = CurrentValue, InputValue = InputValue });
            }
        }
    }

    private async Task OnBlur()
    {
        if (InputValueChanged.HasDelegate)
        {
            await InputValueChanged.InvokeAsync(new SliderInputValueChangedEventArgs { Value = CurrentValue, InputValue = InputValue });
        }
    }

    private async Task HandleThumbMove<T>(T e) where T: EventArgs
    {
        var clientPosition = e switch
        {
            TouchEventArgs te => te.Touches.Length > 0 ? (decimal)te.Touches[0].ClientX : 0.0M,
            MouseEventArgs me => (decimal)me.ClientX,
            _                 => throw new InvalidOperationException()
        };

        var sliderClientRect = await DomUtils.GetBoundingClientRectAsync(SliderRailRef);
        var sliderOffset     = await DomUtils.GetOffsetSizeAsync(SliderRailRef);
        var thumbOffset      = await DomUtils.GetOffsetSizeAsync(ThumbRef);

        var newPosition = clientPosition - Diff - (decimal)sliderClientRect.Left;
        var end         = (decimal)sliderOffset.Width - (decimal)thumbOffset.Width;
        var start       = 0.0M;

        if (newPosition < start)
        {
            newPosition = 0.0M;
        }

        if (newPosition > end)
        {
            newPosition = end;
        }

        var newPercentage = GetPercentage(newPosition, end);

        ThumbStyle = $"--pf-c-slider--value:{newPercentage.ToString(CultureInfo.InvariantCulture)}%";

        // convert percentage to value
        var newValue = Math.Round(((newPercentage * (Max - Min)) / 100 + Min) * 100) / 100;

        CurrentValue = newValue;

        if (!HasCustomSteps)
        {
            // snap to new value if not custom steps
            SnapValue    = Math.Round((Math.Round((newValue - Min) / Step) * Step + Min) * 100) / 100;
            ThumbStyle   = $"--pf-c-slider--value:{SnapValue?.ToString(CultureInfo.InvariantCulture)}%";
            CurrentValue = SnapValue.Value;
        }

        // If custom steps are discrete, snap to closest step value.
        if (!AreCustomStepsContinuous && HasCustomSteps)
        {
            var percentage = newPercentage;
            if (CustomSteps[^1].Value != 100.0M)
            {
                percentage = (newPercentage * (Max - Min)) / 100 + Min;
            }
            var currentStep  = CustomSteps.FirstOrDefault(stepObj => stepObj.Value >= percentage);
            var stepIndex    = Array.IndexOf(CustomSteps, currentStep);
            if (CustomSteps[stepIndex].Value == percentage)
            {
                SnapValue = CustomSteps[stepIndex].Value;
            }
            else
            {
                var midpoint = (CustomSteps[stepIndex].Value + CustomSteps[stepIndex - 1].Value) / 2;
                SnapValue = midpoint > percentage ? CustomSteps[stepIndex - 1].Value : CustomSteps[stepIndex].Value;
            }
            CurrentValue = SnapValue.Value;
        }
    }
}