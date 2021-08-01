namespace Blatternfly
{
    public struct KeyboardEvent
    {
        public bool AltKey { get; set; }
        public string Code { get; set; }
        public bool CtrlKey { get; set; }
        public bool IsComposing { get; set; }
        public string Key { get; set; }
        public float Locale { get; set; }
        public float Location { get; set; }
        public bool MetaKey { get; set; }
        public bool Repeat { get; set; }
        public bool ShiftKey { get; set; }
    }
}
