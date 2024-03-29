﻿using Microsoft.JSInterop;

namespace Blatternfly.Components;

internal interface IFocusTrapInteropModule : IAsyncDisposable
{
    Task<IJSObjectReference> CreateAsync(ElementReference reference, FocusTrapOptions options);
    Task ActivateAsync(IJSObjectReference focusTrap);
    Task DeactivateAsync(IJSObjectReference focusTrap);
    Task PauseAsync(IJSObjectReference focusTrap);
    Task UnpauseAsync(IJSObjectReference focusTrap);
}
