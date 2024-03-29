namespace Blatternfly.Components;

public partial class PopoverDialog : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>PopoverDialog position.</summary>
    [Parameter] public PopoverDialogPosition? Position { get; set; } = PopoverDialogPosition.Top;

    private string CssClass => new CssBuilder("pf-c-popover")
        .AddClass("pf-m-top"   , Position is null or PopoverDialogPosition.Top)
        .AddClass("pf-m-bottom", Position is PopoverDialogPosition.Bottom)
        .AddClass("pf-m-left"  , Position is PopoverDialogPosition.Left)
        .AddClass("pf-m-right" , Position is PopoverDialogPosition.Right)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}