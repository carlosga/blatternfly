namespace Blatternfly.Components;

public partial class Progress : ComponentBase
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Size variant of progress.</summary>
    [Parameter] public ProgressSize? Size { get; set; }

    /// <summary>Where the measure percent will be located.</summary>
    [Parameter] public ProgressMeasureLocation MeasureLocation { get; set; } = ProgressMeasureLocation.Top;

    /// <summary>Status variant of progress.</summary>
    [Parameter] public ProgressVariant? Variant { get; set; }

    /// <summary>Title above progress.</summary>
    [Parameter] public string Title { get; set; }

    /// <summary>Text description of current progress value to display instead of percentage.</summary>
    [Parameter] public RenderFragment Label { get; set; }

    /// <summary>Actual value of progress.</summary>
    [Parameter] public decimal Value { get; set; } = decimal.Zero;

    /// <summary>Minimal value of progress.</summary>
    [Parameter] public decimal Min { get; set; } = decimal.Zero;

    /// <summary>Maximum value of progress.</summary>
    [Parameter] public decimal Max { get; set; } = 100.0M;

    /// <summary>Accessible text description of current progress value, for when value is not a percentage. Use with label.</summary>
    [Parameter] public string ValueText { get; set; }

    /// <summary>Indicate whether to truncate the title.</summary>
    [Parameter] public bool IsTitleTruncated { get; set; }

    /// <summary>Adds accessible text to the ProgressBar. Required when title not used and there is not any label associated with the progress bar.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Associates the ProgressBar with it's label for accessibility purposes. Required when title not used.</summary>
    [Parameter] public string AriaLabelledBy { get; set; }

    /// Position of the tooltip which is displayed if text is truncated.
    [Parameter] public TooltipPosition TooltipPosition { get; set; } = TooltipPosition.Top;

    private string CssClass => new CssBuilder("pf-c-progress")
        .AddClass("pf-m-danger"    , Variant is ProgressVariant.Danger)
        .AddClass("pf-m-success"   , Variant is ProgressVariant.Success)
        .AddClass("pf-m-warning"   , Variant is ProgressVariant.Warning)
        .AddClass("pf-m-inside"    , MeasureLocation is ProgressMeasureLocation.Inside)
        .AddClass("pf-m-outside"   , MeasureLocation is ProgressMeasureLocation.Outside)
        .AddClass("pf-m-lg"        , MeasureLocation is ProgressMeasureLocation.Inside)
        .AddClass("pf-m-lg"        , MeasureLocation is not ProgressMeasureLocation.Inside && Size is ProgressSize.Large)
        .AddClass("pf-m-sm"        , MeasureLocation is not ProgressMeasureLocation.Inside && Size is ProgressSize.Small)
        .AddClass("pf-m-singleline", string.IsNullOrEmpty(Title))
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string  InternalId  { get; set; }
    private decimal ScaledValue { get => Math.Min(100.0M, Math.Max(0, Math.Floor(((Value - Min) / (Max - Min)) * 100.0M))); }
    private ProgressAriaProps AriaProps
    {
        get
        {
            var ariaProps = new ProgressAriaProps
            {
                Min  = Min,
                Now  = Value,
                Max  = Max,
                Text = ValueText
            };

            if (!string.IsNullOrEmpty(Title) || !string.IsNullOrEmpty(AriaLabelledBy))
            {
                ariaProps.LabelledBy = !string.IsNullOrEmpty(Title) ? $"{InternalId}-description" : AriaLabelledBy;
            }
            if (!string.IsNullOrEmpty(AriaLabel))
            {
                ariaProps.Label = AriaLabel;
            }

            return ariaProps;
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        InternalId = AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id) ?? ComponentIdGenerator.Generate();

#if (RELEASE)
        if (string.IsNullOrEmpty(Title) && string.IsNullOrEmpty(AriaLabelledBy) && string.IsNullOrEmpty(AriaLabel))
        {
            throw new InvalidOperationException("Progress: One of aria-label or aria-labelledby properties should be passed when using the progress component without a title.");
        }
#endif
    }
}
