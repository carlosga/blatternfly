using Microsoft.JSInterop;

namespace Blatternfly.Components;

public interface IMenuContentInteropModule : IAsyncDisposable
{
    ValueTask<double?> RefCallback(DotNetObjectReference<MenuContent> dotNetObjRef, ElementReference reference);
}
