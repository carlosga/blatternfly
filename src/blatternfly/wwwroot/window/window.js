export function canUseDOM() {
    return !!(typeof window !== 'undefined' && window.document && window.document.createElement);
}

export function innerSize() { return { Width: window.innerWidth, Height: window.innerHeight } }

export function onResize(dotNetObjRef) {
    function resizeHandler() {
        const iw = window.innerWidth;
        const ih = window.innerHeight;
        dotNetObjRef.invokeMethod("OnWindowResize", {
            InnerSize : { Width: iw, Height: ih }
        });
    }
    window.addEventListener('resize', resizeHandler);
}

export function onClick(dotNetObjRef) {
    function clickHandler(event) {
        const composedPath = [];

        event.composedPath().forEach((element) => {
            const elementId = element.id;
            if (elementId) {
                composedPath.push(element.id);
            }
        });

        dotNetObjRef.invokeMethod("OnWindowClick", {
            AltKey      : event.altKey,
            Button      : event.button,
            Buttons     : event.buttons,
            ClientX     : event.clientX,
            ClientY     : event.clientY,
            CtrlKey     : event.ctrlKey,
            MetaKey     : event.metaKey,
            MovementX   : event.movementX,
            MovementY   : event.movementY,
            OffsetX     : event.OffsetX,
            OffsetY     : event.OffsetY,
            PageX       : event.pageX,
            PageY       : event.pageY,
            ShiftKey    : event.shiftKey,
            ComposedPath: composedPath,
            Type        : 'Click'
        });
    }
    window.addEventListener("click", clickHandler);
}
 
export function onKeyDown(dotNetObjRef) {
    function keydownHandler(event) {
        dotNetObjRef.invokeMethod("OnWindowKeydown", {
            AltKey      : event.altKey,
            Code        : event.code,
            CtrlKey     : event.ctrlKey,
            IsComposing : event.isComposing,
            Key         : event.key,
            Locale      : event.locale,
            Location    : event.location,
            MetaKey     : event.metaKey,
            Repeat      : event.repeat,
            ShiftKey    : event.shiftKey,
            Type        : 'Keydown'
        });
    }
    window.addEventListener("keydown", keydownHandler);
}