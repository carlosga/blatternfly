using Microsoft.JSInterop;

namespace Blatternfly.Components;

internal interface ICalendarMonthInteropModule : IAsyncDisposable
{
    ValueTask OnKeydown(DotNetObjectReference<CalendarMonth> dotNetObjRef, ElementReference reference);
}
