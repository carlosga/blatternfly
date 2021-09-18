using System.Threading.Tasks;
using Blatternfly.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blatternfly.UnitTests.Interop
{
    public sealed class CalendarMonthInteropMockModule : ICalendarMonthInteropModule
    {
        public ValueTask DisposeAsync()
        {
            return ValueTask.CompletedTask;
        }
        
        public ValueTask OnKeydown(DotNetObjectReference<CalendarMonth> dotNetObjRef, ElementReference reference)
        {
            return ValueTask.CompletedTask;
        }
    }
}
