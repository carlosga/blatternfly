using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blatternfly.Components;

public interface IFocusTrapInteropModule : IAsyncDisposable
{
    Task<IJSObjectReference> CreateAsync(ElementReference reference, FocusTrapOptions options);
    Task ActivateAsync(IJSObjectReference focusTrap);
    Task DeactivateAsync(IJSObjectReference focusTrap);
    Task PauseAsync(IJSObjectReference focusTrap);
    Task UnpauseAsync(IJSObjectReference focusTrap);
}
