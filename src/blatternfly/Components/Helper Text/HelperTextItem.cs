namespace Blatternfly.Components;

public class HelperTextItem : BaseComponent
{
    /// Sets the component type of the helper text item.
    [Parameter] public HelperTextItemComponent Component { get; set; } = HelperTextItemComponent.div;

    /// Variant styling of the helper text item.
    [Parameter] public HelperTextItemVariant Variant { get; set; } = HelperTextItemVariant.Default;

    /// Custom icon prefixing the helper text. This property will override the default icon paired with each helper text variant.
    [Parameter] public RenderFragment Icon { get; set; }

    /// Flag indicating the helper text item is dynamic.
    [Parameter] public bool IsDynamic { get; set; }

    /// Flag indicating the helper text should have an icon. Dynamic helper texts include icons by default while static helper texts do not.
    [Parameter] public bool HasIcon { get; set; }

    private string CssClass => new CssBuilder("pf-c-helper-text__item")
        .AddClass("pf-m-indeterminate" , Variant == HelperTextItemVariant.Indeterminate)
        .AddClass("pf-m-warning"       , Variant == HelperTextItemVariant.Warning)
        .AddClass("pf-m-success"       , Variant == HelperTextItemVariant.Success)
        .AddClass("pf-m-error"         , Variant == HelperTextItemVariant.Error)
        .AddClass("pf-m-dynamic"       , IsDynamic)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var index = 0;
        var component = Component switch
        {
            HelperTextItemComponent.div => "div",
            HelperTextItemComponent.li  => "li",
            _                           => "div"
        };

        builder.OpenElement(index++, component);
        builder.AddMultipleAttributes(index++, AdditionalAttributes);
        builder.AddAttribute(index++, "class", CssClass);

        if (Icon is not null)
        {
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-helper-text__item-icon");
            builder.AddAttribute(index++, "aria-hidden", "true");
            builder.AddContent(index++, Icon);
            builder.CloseElement();
        }
        if ((HasIcon || IsDynamic) && Icon is null)
        {
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-helper-text__item-icon");
            builder.AddAttribute(index++, "aria-hidden", "true");
            if (Variant is HelperTextItemVariant.Default or HelperTextItemVariant.Indeterminate)
            {
                builder.OpenComponent<MinusIcon>(index++);
            }
            else if (Variant == HelperTextItemVariant.Warning)
            {
                builder.OpenComponent<ExclamationTriangleIcon>(index++);
            }
            else if (Variant == HelperTextItemVariant.Success)
            {
                builder.OpenComponent<CheckCircleIcon>(index++);
            }
            else if (Variant == HelperTextItemVariant.Error)
            {
                builder.OpenComponent<ExclamationCircleIcon>(index++);
            }
            builder.CloseComponent();
            builder.CloseElement();
        }

        builder.OpenElement(index++, "span");
        builder.AddAttribute(index++, "class", "pf-c-helper-text__item-text");
        builder.AddContent(index++, ChildContent);
        builder.CloseElement();

        builder.CloseElement();
    }
}
