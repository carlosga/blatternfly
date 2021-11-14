namespace Blatternfly.Components;

public sealed class PerPageOptions
{
    /// Option title.
    public string Title { get; set; }
    
    /// Option value.
    public int Value { get; set; }

    internal string Action { get => $"per-page-{Value}"; } 
}
