using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Blatternfly.Interop;

[EventHandler("onmouseenter", typeof(MouseEventArgs), true, true)]
[EventHandler("onmouseleave", typeof(MouseEventArgs), true, true)]
public static class EventHandlers
{
}
