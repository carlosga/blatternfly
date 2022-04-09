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
        .AddClass("pf-m-indeterminate" , Variant is HelperTextItemVariant.Indeterminate)
        .AddClass("pf-m-warning"       , Variant is HelperTextItemVariant.Warning)
        .AddClass("pf-m-success"       , Variant is HelperTextItemVariant.Success)
        .AddClass("pf-m-error"         , Variant is HelperTextItemVariant.Error)
        .AddClass("pf-m-dynamic"       , IsDynamic)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var component = Component switch
        {
            HelperTextItemComponent.div => "div",
            HelperTextItemComponent.li  => "li",
            _                           => "div"
        };

        builder.OpenElement(0, component);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);

        if (Icon is not null)
        {
            builder.OpenElement(3, "span");
            builder.AddAttribute(4, "class", "pf-c-helper-text__item-icon");
            builder.AddAttribute(5, "aria-hidden", "true");
            builder.AddContent(6, Icon);
            builder.CloseElement();
        }
        if ((HasIcon || IsDynamic) && Icon is null)
        {
            builder.OpenElement(7, "span");
            builder.AddAttribute(8, "class", "pf-c-helper-text__item-icon");
            builder.AddAttribute(9, "aria-hidden", "true");
            if (Variant is HelperTextItemVariant.Default or HelperTextItemVariant.Indeterminate)
            {
                builder.OpenComponent<MinusIcon>(10);
            }
            else if (Variant == HelperTextItemVariant.Warning)
            {
                builder.OpenComponent<ExclamationTriangleIcon>(11);
            }
            else if (Variant == HelperTextItemVariant.Success)
            {
                builder.OpenComponent<CheckCircleIcon>(12);
            }
            else if (Variant == HelperTextItemVariant.Error)
            {
                builder.OpenComponent<ExclamationCircleIcon>(13);
            }
            builder.CloseComponent();
            builder.CloseElement();
        }

        builder.OpenElement(14, "span");
        builder.AddAttribute(15, "class", "pf-c-helper-text__item-text");
        builder.AddContent(16, ChildContent);
        builder.CloseElement();

        builder.CloseElement();
    }
}
