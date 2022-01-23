﻿using System;
using System.Threading.Tasks;

namespace Blatternfly.Interop;

public interface IResizeObserver : IAsyncDisposable
{
    IObservable<ResizeEvent> OnResize { get; }
    ValueTask ObserveAsync(ElementReference containerRefElement);
    ValueTask UnobserveAsync(ElementReference containerRefElement);
}
