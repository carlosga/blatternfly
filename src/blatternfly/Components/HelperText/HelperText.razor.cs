namespace Blatternfly.Components;

public partial class HelperText : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Component type of the helper text container.
    /// </summary>
    [Parameter] public HelperTextComponent Component { get; set; } = HelperTextComponent.div;

    /// <summary>
    /// ID for the helper text container. The value of this prop can be passed into a form component's
    /// aria-describedby prop when you intend for all helper text items to be announced to
    /// assistive technologies.
    /// </summary>
    [Parameter] public string id { get; set; }

    /// <summary>
    /// Flag for indicating whether the helper text container is a live region. Use this prop when you
    /// expect or intend for any helper text items within the container to be dynamically updated.
    /// </summary>
    [Parameter] public bool IsLiveRegion { get; set; }

    private string CssClass => new CssBuilder("pf-c-helper-text")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string AriaLive { get => IsLiveRegion ? "polite" : null; }
    private string Container
    {
        get
        {
            return Component switch
            {
                HelperTextComponent.div => "div",
                HelperTextComponent.ul  => "ul",
                _                       => null
            };
        }
    }
}
