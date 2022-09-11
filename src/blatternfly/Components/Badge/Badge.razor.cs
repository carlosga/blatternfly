namespace Blatternfly.Components;

public partial class Badge : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Adds styling to the badge to indicate it has been read.</summary>
    [Parameter] public bool IsRead { get; set; }

    private string CssClass => new CssBuilder("pf-c-badge")
        .AddClass("pf-m-read"  , IsRead)
        .AddClass("pf-m-unread", !IsRead)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
