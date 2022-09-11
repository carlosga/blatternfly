namespace Blatternfly.Components;

public partial class CardActions : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Flag indicating that the actions have no offset.</summary>
    [Parameter] public bool HasNoOffset { get; set; }

    private string CssClass => new CssBuilder("pf-c-card__actions")
        .AddClass("pf-m-no-offset", HasNoOffset)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}