using Microsoft.JSInterop;

namespace Blatternfly.Components;

public interface ICalendarMonthInteropModule : IAsyncDisposable
{
    ValueTask OnKeydown(DotNetObjectReference<CalendarMonth> dotNetObjRef, ElementReference reference);
}
