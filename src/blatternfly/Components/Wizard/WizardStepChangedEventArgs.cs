namespace Blatternfly.Components;

public sealed class WizardStepChangedEventArgs
{
    public int?   NewStep      { get; init; }
    public string NewStepName  { get; set; }
    public int?   PrevStep     { get; init; }
    public string PrevStepName { get; init; }
}
