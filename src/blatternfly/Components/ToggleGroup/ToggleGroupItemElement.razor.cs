namespace Blatternfly.Components;

public partial class ToggleGroupItemElement : ComponentBase
{
    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Adds toggle group item variant styles.</summary>
    [Parameter] public ToggleGroupItemVariant? Variant { get; set; }

    private string CssClass => new CssBuilder()
      .AddClass("pf-c-toggle-group__icon", Variant is ToggleGroupItemVariant.Icon)
      .AddClass("pf-c-toggle-group__text", Variant is ToggleGroupItemVariant.Text)
      .Build();
}