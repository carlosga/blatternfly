namespace Blatternfly.Components;

public partial class CollapseColumn : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary></summary>
    [Parameter] public bool? IsOpen { get; set; }

    /// <summary></summary>
    [Parameter] public EventCallback<MouseEventArgs> OnToggle { get; set; }

    private string CssClass => new CssBuilder()
        .AddClass("pf-m-expanded", IsOpen.GetValueOrDefault())
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private async Task HandleToggle(MouseEventArgs args)
    {
        IsOpen = !IsOpen;
        await OnToggle.InvokeAsync(args);
    }
}