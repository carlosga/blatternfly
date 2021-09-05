﻿using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blatternfly.Components
{
    public interface IDropdownInteropService : IAsyncDisposable
    {
        ValueTask ImportAsync();

        ValueTask OnKeydown(DotNetObjectReference<Toggle> dotNetObjRef, string toggleId);
    }
}
