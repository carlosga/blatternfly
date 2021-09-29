using System;
using System.Threading.Tasks;
using Blatternfly.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blatternfly.UnitTests.Interop
{
    public class FocusTrapInteropMockModule : IFocusTrapInteropModule
    {
        public ValueTask DisposeAsync()
        {
            return ValueTask.CompletedTask;
        }

        public Task<IJSObjectReference> CreateAsync(ElementReference reference, FocusTrapOptions options)
        {
            throw new NotImplementedException();
        }

        public Task ActivateAsync(IJSObjectReference focusTrap)
        {
            return Task.CompletedTask;
        }

        public Task DeactivateAsync(IJSObjectReference focusTrap)
        {
            return Task.CompletedTask;
        }

        public Task PauseAsync(IJSObjectReference focusTrap)
        {
            return Task.CompletedTask;
        }

        public Task UnpauseAsync(IJSObjectReference focusTrap)
        {
            return Task.CompletedTask;
        }
    }
}
