namespace Blatternfly.Components;

/// <summary>Per page options.</summary>
public sealed class PerPageOptions
{
    /// <summary>Option title.</summary>
    public string Title { get; set; }

    /// <summary>Option value.</summary>
    public int Value { get; set; }

    internal string Action { get => $"per-page-{Value}"; }
}
