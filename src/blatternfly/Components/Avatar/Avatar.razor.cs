namespace Blatternfly.Components;

public partial class Avatar : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Attribute that specifies the URL of the image for the Avatar.
    /// </summary>
    [Parameter] public string Src { get; set; } = string.Empty;

    /// <summary>
    /// Attribute that specifies the alternate text of the image for the Avatar.
    /// </summary>
    [Parameter] public string Alt { get; set; }

    /// <summary>
    /// Border to add.
    /// </summary>
    [Parameter] public AvatarBorder? Border { get; set; }

    /// <summary>
    /// Size variant of avatar.
    /// </summary>
    [Parameter] public AvatarSize? Size { get; set; }

    private string CssClass => new CssBuilder("pf-c-avatar")
        .AddClass("pf-m-light", Border is AvatarBorder.Light)
        .AddClass("pf-m-dark" , Border is AvatarBorder.Dark)
        .AddClass("pf-m-sm"   , Size   is AvatarSize.Small)
        .AddClass("pf-m-md"   , Size   is AvatarSize.Medium)
        .AddClass("pf-m-lg"   , Size   is AvatarSize.Large)
        .AddClass("pf-m-xl"   , Size   is AvatarSize.ExtraLarge)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
