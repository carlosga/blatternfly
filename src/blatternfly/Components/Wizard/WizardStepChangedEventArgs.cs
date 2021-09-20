namespace Blatternfly.Components
{
    public sealed class WizardStepChangedEventArgs
    {
        public int NewStep { get; init; }
        public int PrevStep { get; init; }
    }
}
