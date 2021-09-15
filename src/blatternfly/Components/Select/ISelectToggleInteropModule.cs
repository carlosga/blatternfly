using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blatternfly.Components
{
    public interface ISelectToggleInteropModule
    {
        ValueTask ImportAsync();

        ValueTask OnKeydown(DotNetObjectReference<SelectToggle> dotNetObjRef, ElementReference toggle);        
    }
}
