namespace Blatternfly.Events
{
    public sealed class KeyboardEvent
    {
        public string Key { get; set; } = default!;
        public string Code { get; set; } = default!;
        public float Location { get; set; }
        public bool Repeat { get; set; }
        public bool CtrlKey { get; set; }
        public bool ShiftKey { get; set; }
        public bool AltKey { get; set; }
        public bool MetaKey { get; set; }
        public string Type { get; set; } = default!;

        public override string ToString()
        {
            return $"{Key} {Code}";
        }
    }
}
