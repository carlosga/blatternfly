namespace Blatternfly.Components;

/// <summary>Wizard step changed event args.</summary>
public sealed class WizardStepChangedEventArgs
{
    /// <summary>New step id.</summary>
    public string NewStepId { get; init; }

    /// <summary>New step index.</summary>
    public int? NewStepIndex { get; init; }

    /// <summary>New step name.</summary>
    public string NewStepName { get; set; }

    /// <summary>Previous step id.</summary>
    public string PrevStepId { get; init; }

    /// <summary>Previous step index.</summary>
    public int? PrevStepIndex { get; init; }

    /// <summary>Previous step name.</summary>
    public string PrevStepName { get; init; }
}
