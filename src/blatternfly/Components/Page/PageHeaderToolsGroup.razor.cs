namespace Blatternfly.Components;

public partial class PageHeaderToolsGroup : ComponentBase
{
    [CascadingParameter] private Page ParentPage { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Visibility at various breakpoints.</summary>
    [Parameter] public VisibilityModifiers Visibility { get; set; }

    private string CssClass => new CssBuilder("pf-c-page__header-tools-group")
        .AddClass(Visibility?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}