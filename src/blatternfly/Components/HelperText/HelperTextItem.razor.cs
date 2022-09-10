namespace Blatternfly.Components;

public partial class HelperTextItem : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Sets the component type of the helper text item.
    /// </summary>
    [Parameter]
    public HelperTextItemComponent Component { get; set; } = HelperTextItemComponent.div;

    /// <summary>
    /// Variant styling of the helper text item.
    /// </summary>
    [Parameter]
    public HelperTextItemVariant Variant { get; set; } = HelperTextItemVariant.Default;

    /// <summary>
    /// Custom icon prefixing the helper text. This property will override the default icon paired with each helper text variant.
    /// </summary>
    [Parameter]
    public RenderFragment Icon { get; set; }

    /// <summary>
    /// Flag indicating the helper text item is dynamic. This prop should be used when the
    /// text content of the helper text item will never change, but the icon and styling will
    /// be dynamically updated via the `variant` prop.
    /// </summary>
    [Parameter]
    public bool IsDynamic { get; set; }

    /// <summary>
    /// Flag indicating the helper text should have an icon. Dynamic helper texts include icons by default while static helper texts do not.
    /// </summary>
    [Parameter]
    public bool HasIcon { get; set; }

    /// <summary>
    /// ID for the helper text item. The value of this prop can be passed into a form component's
    /// aria-describedby prop when you intend for only specific helper text items to be announced to
    /// assistive technologies.
    /// </summary>
    [Parameter]
    public string id { get; set; }

    /// <summary>
    /// Text that is only accessible to screen readers in order to announce the status of a helper text item.
    /// This prop can only be used when the isDynamic prop is also passed in.
    /// </summary>
    [Parameter]
    public string ScreenReaderText { get; set; }

    private string CssClass => new CssBuilder("pf-c-helper-text__item")
        .AddClass("pf-m-indeterminate" , Variant is HelperTextItemVariant.Indeterminate)
        .AddClass("pf-m-warning"       , Variant is HelperTextItemVariant.Warning)
        .AddClass("pf-m-success"       , Variant is HelperTextItemVariant.Success)
        .AddClass("pf-m-error"         , Variant is HelperTextItemVariant.Error)
        .AddClass("pf-m-dynamic"       , IsDynamic)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string Container
    {
        get
        {
            return Component switch
            {
                HelperTextItemComponent.div => "div",
                HelperTextItemComponent.li  => "li",
                _                           => "div"
            };
        }
    }

    private string ScreenReaderTextValue
    {
        get
        {
            return string.IsNullOrEmpty(ScreenReaderText)
                ? $": {Variant} status;"
                    : $": {ScreenReaderText};";
        }
    }
}
