namespace Blatternfly.Components;

public partial class SidebarContent : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Removes the background color.</summary>
    [Parameter] public bool HasNoBackground { get; set; }

    private string CssClass => new CssBuilder("pf-c-sidebar__content")
        .AddClass("pf-m-no-background", HasNoBackground)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}