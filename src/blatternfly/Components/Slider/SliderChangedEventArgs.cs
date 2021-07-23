using System;

namespace Blatternfly.Components
{
    public sealed class SliderChangedEventArgs : EventArgs
    {
        public decimal Value { get; set; }
        public decimal InputValue { get; set; }
    }
}
