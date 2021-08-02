namespace Blatternfly.Components
{
    public readonly struct ToggleState
    {
        public bool IsOpen { get; }
        public bool BubbleEvent { get; }
  
        internal ToggleState(bool isOpen, bool bubbleEvent)
        {
            IsOpen      = isOpen;
            BubbleEvent = bubbleEvent;
        }
    }
}
