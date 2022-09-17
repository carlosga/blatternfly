namespace Blatternfly.Components;

public partial class SelectColumn : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary></summary>
    [Parameter] public string Name { get; set; }

    /// <summary></summary>
    [Parameter] public EventCallback<bool> OnSelect { get; set; }

    /// <summary></summary>
    [Parameter] public RowSelectVariant SelectVariant { get; set; }

    /// <summary></summary>
    [Parameter] public bool IsSelected { get; set; }

    /// <summary></summary>
    [Parameter] public bool DisableSelection { get; set; }

    private string Variant
    {
        get => SelectVariant switch
        {
            RowSelectVariant.Checkbox => "checkbox",
            _                         => null
        };
    }

    private async Task ValueChanged(ChangeEventArgs args)
    {
        var value = Convert.ToBoolean(args.Value);

        await OnSelect.InvokeAsync(value);
    }
}