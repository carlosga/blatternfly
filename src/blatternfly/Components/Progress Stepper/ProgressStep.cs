using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components;

public class ProgressStep : BaseComponent
{
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

    private string TitleTabIndex { get => Popover is not null ? "0" : null; }
    private string TitleRole     { get => Popover is not null ? "button" : null; }
    private string TitleType     { get => Popover is not null ? "button" : null; }
    private string TitleAriaLabelledBy
    {
        get => !string.IsNullOrEmpty(InternalId) && !string.IsNullOrEmpty(TitleId) ? $"{InternalId} {TitleId}" : null;
    }

    private CssBuilder CssClass => new CssBuilder("pf-c-progress-stepper__step") 
        .AddClass("pf-m-success", Variant == ProgressStepVariant.Success)
        .AddClass("pf-m-info"   , Variant == ProgressStepVariant.Info)
        .AddClass("pf-m-pending", Variant == ProgressStepVariant.Pending) 
        .AddClass("pf-m-warning", Variant == ProgressStepVariant.Warning)
        .AddClass("pf-m-danger" , Variant == ProgressStepVariant.Danger)
        .AddClass("pf-m-current", IsCurrent)
        .AddClassFromAttributes(AdditionalAttributes);

    private CssBuilder TitleCssClass => new CssBuilder("pf-c-progress-stepper__step-title")
        .AddClass("pf-m-help-text", Popover is not null);

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
        var index = 0;
        
        builder.OpenElement(index++, "li");
        builder.AddMultipleAttributes(index++, AdditionalAttributes);
        builder.AddAttribute(index++, "class", CssClass.Build());

        builder.OpenElement(index++, "div");
        builder.AddAttribute(index++, "class", "pf-c-progress-stepper__step-connector");
        
        builder.OpenElement(index++, "span");
        builder.AddAttribute(index++, "class", "pf-c-progress-stepper__step-icon");
        
        if (Icon is not null)
        {
            builder.AddContent(index++, Icon);    
        }
        else if (Variant == ProgressStepVariant.Success)
        {
            builder.OpenComponent<CheckCircleIcon>(index++);
            builder.CloseComponent();
        }
        else if (Variant == ProgressStepVariant.Info)
        {
            builder.OpenComponent<ResourcesFullIcon>(index++);
            builder.CloseComponent();
        }
        else if (Variant == ProgressStepVariant.Warning)
        {
            builder.OpenComponent<ExclamationTriangleIcon>(index++);
            builder.CloseComponent();
        }
        else if (Variant == ProgressStepVariant.Danger)
        {
            builder.OpenComponent<ExclamationCircleIcon>(index++);
            builder.CloseComponent();
        }
        
        builder.CloseElement(); 

        builder.CloseElement();
        
        builder.OpenElement(index++, "div");
        builder.AddAttribute(index++, "class", "pf-c-progress-stepper__step-main");
        
        builder.OpenElement(index++, Popover is not null ? "span" : "div");
        builder.AddAttribute(index++, "class", TitleCssClass);
        builder.AddAttribute(index++, "id", TitleId);
        builder.AddAttribute(index++, "tabindex", TitleTabIndex);
        builder.AddAttribute(index++, "role", TitleRole);
        builder.AddAttribute(index++, "type", TitleType);
        builder.AddAttribute(index++, "aria-labelledby", @TitleAriaLabelledBy);
        builder.AddElementReferenceCapture(index++, __inputReference => InnerRef = __inputReference);
        
        builder.AddContent(index++, ChildContent);
        builder.AddContent(index++, Popover);
        
        builder.CloseElement();

        if (!string.IsNullOrEmpty(Description))
        {
            builder.OpenElement(index++, "div");
            builder.AddAttribute(index++, "class", "pf-c-progress-stepper__step-description");
            builder.AddContent(index, Description);
            builder.CloseElement();
        }
        
        builder.CloseElement();

        builder.CloseElement();
    }
}
