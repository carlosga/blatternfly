namespace Blatternfly.Components;

public partial class AlertActionLink
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
    /// A callback for when the alert action link is clicked.
    /// </summary>    
    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    private string CssClass => new CssBuilder()
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
