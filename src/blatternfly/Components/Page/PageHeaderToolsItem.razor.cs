namespace Blatternfly.Components;

public partial class PageHeaderToolsItem : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Parent Page Component.</summary>
    [CascadingParameter] public Page ParentPage { get; set; }

    /// <summary>Visibility at various breakpoints.</summary>
    [Parameter] public VisibilityModifiers Visibility { get; set; }

    /// <summary>True to make an icon button appear selected.</summary>
    [Parameter] public bool IsSelected { get; set; }

    private string CssClass => new CssBuilder("pf-c-page__header-tools-item")
        .AddClass("pf-m-current", IsSelected)
        .AddClass(Visibility?.CssClass(ParentPage?.WidthBreakpoint))
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}