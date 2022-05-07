namespace Blatternfly.Components;

public sealed class WizardStepChangedEventArgs
{
    public string NewStepId     { get; init; }
    public int?   NewStepIndex  { get; init; }
    public string NewStepName   { get; set; }
    public string PrevStepId    { get; init; }
    public int?   PrevStepIndex { get; init; }
    public string PrevStepName  { get; init; }
}
