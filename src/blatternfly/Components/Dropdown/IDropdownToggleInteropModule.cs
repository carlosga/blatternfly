using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blatternfly.Components
{
    public interface IDropdownToggleInteropModule : IAsyncDisposable
    {
        ValueTask ImportAsync();

        ValueTask OnKeydown(DotNetObjectReference<Toggle> dotNetObjRef, ElementReference toggle);
    }
}
