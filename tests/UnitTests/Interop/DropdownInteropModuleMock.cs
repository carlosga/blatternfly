using System.Threading.Tasks;
using Blatternfly.Components;
using Microsoft.JSInterop;

namespace Blatternfly.UnitTests.Interop
{
    public sealed class DropdownInteropMockModule : IDropdownInteropModule
    {
        public ValueTask DisposeAsync()
        {
            return ValueTask.CompletedTask;
        }
        
        public ValueTask ImportAsync()
        {
            return ValueTask.CompletedTask;
        }

        public ValueTask OnKeydown(DotNetObjectReference<Toggle> dotNetObjRef, string toggleId)
        {
            return ValueTask.CompletedTask;
        }
    }
}
