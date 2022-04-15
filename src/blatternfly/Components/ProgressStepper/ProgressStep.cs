using System;

namespace Blatternfly.Components;

public class ProgressStep : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Variant of the progress step. Each variant has a default icon.
    [Parameter] public ProgressStepVariant Variant { get; set; } = ProgressStepVariant.Default;

    /// Flag indicating the progress step is the current step.
    [Parameter] public bool IsCurrent { get; set; }

    /// Custom icon of a progress step. Will override default icons provided by the variant.
    [Parameter] public RenderFragment Icon { get; set; }

    /// Description text of a progress step.
    [Parameter] public string Description { get; set; }

    /// ID of the title of the progress step.
    [Parameter] public string TitleId { get; set; }

    /// Popover for a progress step.
    [Parameter] public RenderFragment Popover { get; set; }

    /// @hide Forwarded reference to title container
    [Parameter] public ElementReference InnerRef { get; set; }

    private string CssClass => new CssBuilder("pf-c-progress-stepper__step")
        .AddClass("pf-m-success", Variant is ProgressStepVariant.Success)
        .AddClass("pf-m-info"   , Variant is ProgressStepVariant.Info)
        .AddClass("pf-m-pending", Variant is ProgressStepVariant.Pending)
        .AddClass("pf-m-warning", Variant is ProgressStepVariant.Warning)
        .AddClass("pf-m-danger" , Variant is ProgressStepVariant.Danger)
        .AddClass("pf-m-current", IsCurrent)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string TitleCssClass => new CssBuilder("pf-c-progress-stepper__step-title")
        .AddClass("pf-m-help-text", Popover is not null)
        .Build();

    private string InternalId    { get => AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id); }
    private string TitleTabIndex { get => Popover is not null ? "0" : null; }
    private string TitleRole     { get => Popover is not null ? "button" : null; }
    private string TitleType     { get => Popover is not null ? "button" : null; }
    private string TitleAriaLabelledBy
    {
        get => !string.IsNullOrEmpty(InternalId) && !string.IsNullOrEmpty(TitleId) ? $"{InternalId} {TitleId}" : null;
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (string.IsNullOrEmpty(InternalId) || string.IsNullOrEmpty(TitleId))
        {
            throw new InvalidCastException(
                "ProgressStep: The titleId and id properties are required to make this component accessible, and one or both of these properties are missing.");
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "li");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);

        builder.OpenElement(3, "div");
        builder.AddAttribute(4, "class", "pf-c-progress-stepper__step-connector");

        builder.OpenElement(5, "span");
        builder.AddAttribute(6, "class", "pf-c-progress-stepper__step-icon");

        if (Icon is not null)
        {
            builder.AddContent(7, Icon);
        }
        else if (Variant is ProgressStepVariant.Success)
        {
            builder.OpenComponent<CheckCircleIcon>(8);
            builder.CloseComponent();
        }
        else if (Variant is ProgressStepVariant.Info)
        {
            builder.OpenComponent<ResourcesFullIcon>(9);
            builder.CloseComponent();
        }
        else if (Variant is ProgressStepVariant.Warning)
        {
            builder.OpenComponent<ExclamationTriangleIcon>(10);
            builder.CloseComponent();
        }
        else if (Variant is ProgressStepVariant.Danger)
        {
            builder.OpenComponent<ExclamationCircleIcon>(11);
            builder.CloseComponent();
        }

        builder.CloseElement();

        builder.CloseElement();

        builder.OpenElement(12, "div");
        builder.AddAttribute(13, "class", "pf-c-progress-stepper__step-main");

        builder.OpenElement(14, Popover is not null ? "span" : "div");
        builder.AddAttribute(15, "class", TitleCssClass);
        builder.AddAttribute(16, "id", TitleId);
        builder.AddAttribute(17, "tabindex", TitleTabIndex);
        builder.AddAttribute(18, "role", TitleRole);
        builder.AddAttribute(19, "type", TitleType);
        builder.AddAttribute(20, "aria-labelledby", @TitleAriaLabelledBy);
        builder.AddElementReferenceCapture(21, __inputReference => InnerRef = __inputReference);

        builder.AddContent(22, ChildContent);
        builder.AddContent(23, Popover);

        builder.CloseElement();

        if (!string.IsNullOrEmpty(Description))
        {
            builder.OpenElement(24, "div");
            builder.AddAttribute(25, "class", "pf-c-progress-stepper__step-description");
            builder.AddContent(26, Description);
            builder.CloseElement();
        }

        builder.CloseElement();

        builder.CloseElement();
    }
}
