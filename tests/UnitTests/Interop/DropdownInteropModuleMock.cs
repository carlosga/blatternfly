using System.Threading.Tasks;
using Blatternfly.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blatternfly.UnitTests.Interop
{
    public sealed class DropdownToggleInteropMockModule : IDropdownToggleInteropModule
    {
        public ValueTask DisposeAsync()
        {
            return ValueTask.CompletedTask;
        }
        
        public ValueTask OnKeydown(DotNetObjectReference<Toggle> dotNetObjRef, ElementReference toggle)
        {
            return ValueTask.CompletedTask;
        }
    }
}
