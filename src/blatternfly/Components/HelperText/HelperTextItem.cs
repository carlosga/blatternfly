namespace Blatternfly.Components;

public class HelperTextItem : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Sets the component type of the helper text item.
    [Parameter] public HelperTextItemComponent Component { get; set; } = HelperTextItemComponent.div;

    /// Variant styling of the helper text item.
    [Parameter] public HelperTextItemVariant Variant { get; set; } = HelperTextItemVariant.Default;

    /// Custom icon prefixing the helper text. This property will override the default icon paired with each helper text variant.
    [Parameter] public RenderFragment Icon { get; set; }

    /// Flag indicating the helper text item is dynamic. This prop should be used when the
    /// text content of the helper text item will never change, but the icon and styling will
    /// be dynamically updated via the `variant` prop.
    [Parameter] public bool IsDynamic { get; set; }

    /// Flag indicating the helper text should have an icon. Dynamic helper texts include icons by default while static helper texts do not.
    [Parameter] public bool HasIcon { get; set; }

    /// ID for the helper text item. The value of this prop can be passed into a form component's
    /// aria-describedby prop when you intend for only specific helper text items to be announced to
    /// assistive technologies.
    [Parameter] public string id { get; set; }

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
        builder.AddAttribute(2, "id", id);
        builder.AddAttribute(3, "class", CssClass);

        if (Icon is not null)
        {
            builder.OpenElement(4, "span");
            builder.AddAttribute(5, "class", "pf-c-helper-text__item-icon");
            builder.AddAttribute(6, "aria-hidden", "true");
            builder.AddContent(7, Icon);
            builder.CloseElement();
        }
        if ((HasIcon || IsDynamic) && Icon is null)
        {
            builder.OpenElement(8, "span");
            builder.AddAttribute(9, "class", "pf-c-helper-text__item-icon");
            builder.AddAttribute(10, "aria-hidden", "true");
            if (Variant is HelperTextItemVariant.Default or HelperTextItemVariant.Indeterminate)
            {
                builder.OpenComponent<MinusIcon>(11);
            }
            else if (Variant is HelperTextItemVariant.Warning)
            {
                builder.OpenComponent<ExclamationTriangleIcon>(12);
            }
            else if (Variant is HelperTextItemVariant.Success)
            {
                builder.OpenComponent<CheckCircleIcon>(13);
            }
            else if (Variant is HelperTextItemVariant.Error)
            {
                builder.OpenComponent<ExclamationCircleIcon>(14);
            }
            builder.CloseComponent();
            builder.CloseElement();
        }

        builder.OpenElement(16, "span");
        builder.AddAttribute(17, "class", "pf-c-helper-text__item-text");
        builder.AddContent(18, ChildContent);
        builder.CloseElement();

        builder.CloseElement();
    }
}
