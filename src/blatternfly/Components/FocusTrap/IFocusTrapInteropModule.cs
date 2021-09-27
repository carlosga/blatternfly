using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blatternfly.Components
{
    public interface IFocusTrapInteropModule
    {
        Task Create(DotNetObjectReference<FocusTrap> dotNetObjRef, ElementReference reference, FocusTrapOptions options);
        Task Activate();
        Task Deactivate();
        Task Pause();
        Task Unpause();
    }
}
