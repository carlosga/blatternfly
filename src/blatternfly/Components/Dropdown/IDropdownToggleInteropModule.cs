﻿using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blatternfly.Components;

public interface IDropdownToggleInteropModule : IAsyncDisposable
{
    ValueTask OnKeydown(DotNetObjectReference<Toggle> dotNetObjRef, ElementReference toggle);
}
