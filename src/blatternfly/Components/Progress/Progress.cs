namespace Blatternfly.Components;

public class Progress : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Size variant of progress.
    [Parameter] public ProgressSize? Size { get; set; }

    /// Where the measure percent will be located.
    [Parameter] public ProgressMeasureLocation MeasureLocation { get; set; } = ProgressMeasureLocation.Top;

    /// Status variant of progress.
    [Parameter] public ProgressVariant? Variant { get; set; }

    /// Title above progress.
    [Parameter] public string Title { get; set; }

    /// Text description of current progress value to display instead of percentage.
    [Parameter] public RenderFragment Label { get; set; }

    /// Actual value of progress.
    [Parameter] public decimal Value { get; set; } = decimal.Zero;

    /// Minimal value of progress.
    [Parameter] public decimal Min { get; set; } = decimal.Zero;

    /// Maximum value of progress.
    [Parameter] public decimal Max { get; set; } = 100.0M;

    /// Accessible text description of current progress value, for when value is not a percentage. Use with label.
    [Parameter] public string ValueText { get; set; }

    /// Indicate whether to truncate the title.
    [Parameter] public bool IsTitleTruncated { get; set; }

    /// Adds accessible text to the ProgressBar. Required when title not used and there is not any label associated with the progress bar.
    [Parameter] public string AriaLabel { get; set; }

    /// Associates the ProgressBar with it's label for accessibility purposes. Required when title not used.
    [Parameter] public string AriaLabelledBy { get; set; }

    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

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

    private string InternalId { get => AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id); }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var id          = InternalId ?? ComponentIdGenerator.Generate();
        var scaledValue = Math.Min(100.0M, Math.Max(0, Math.Floor(((Value - Min) / (Max - Min)) * 100.0M)));
        var ariaProps   = new ProgressAriaProps
        {
            Min  = Min
          , Now  = Value
          , Max  = Max
          , Text = ValueText
        };

        if (!string.IsNullOrEmpty(Title) || !string.IsNullOrEmpty(AriaLabelledBy))
        {
            ariaProps.LabelledBy = !string.IsNullOrEmpty(Title) ? $"{id}-description" : AriaLabelledBy;
        }
        if (!string.IsNullOrEmpty(AriaLabel))
        {
            ariaProps.Label = AriaLabel;
        }

        builder.OpenElement(0, "div");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "id", id);

        builder.OpenComponent<ProgressContainer>(4);
        builder.AddAttribute(5, "ParentId", id);
        builder.AddAttribute(6, "Value", scaledValue);
        builder.AddAttribute(7, "Title", Title);
        builder.AddAttribute(8, "Label", Label);
        builder.AddAttribute(9, "Variant", Variant);
        builder.AddAttribute(10, "MeasureLocation", MeasureLocation);
        builder.AddAttribute(11, "AriaProps", ariaProps);
        builder.AddAttribute(12, "IsTitleTruncated", IsTitleTruncated);
        builder.CloseComponent();

        builder.CloseElement();
    }
}
