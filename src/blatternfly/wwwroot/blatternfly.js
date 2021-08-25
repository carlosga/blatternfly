window.Blatternfly = {
    getBoundingClientRect: (el) => {
        return el.getBoundingClientRect();
    },
    offsetSize: (el) => {
        return {
            Width: el.offsetWidth,
            Height: el.offsetHeight,
        }
    },
    scrollSize: (el) => {
        return {
            Width: el.scrollWidth,
            Height: el.scrollHeight,
        }
    },
    scrollLeft: (el, scrollWidth) => {
        el.scrollLeft += scrollWidth;
    }
}

window.Blatternfly.Window = {
    canUseDOM: () => {
        return !!(typeof window !== 'undefined' && window.document && window.document.createElement);
    },    
    innerSize: () => {
        return {
            Width: window.innerWidth,
            Height: window.innerHeight,
        }
    },    
    onResize: (dotNetObjRef) => {
        function resizeHandler() {
            const iw = window.innerWidth;
            const ih = window.innerHeight;
            dotNetObjRef.invokeMethod("OnWindowResize", {
                InnerSize : { Width: iw, Height: ih }
            });
        }
        window.addEventListener('resize', resizeHandler);
    },
    onClick: (dotNetObjRef) => {
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
    },    
    onKeyDown: (dotNetObjRef) => {
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
};

window.Blatternfly.Dropdown = {
    onKeyDown: (dotNetObjRef, toggleId) => {
        function keydownHandler(ev) {
            const state = dotNetObjRef.invokeMethod("KeydownState");
            if (ev.key === 'Tab' && !state.isOpen) {
                return;
            }
            if ((ev.key === 'Tab' || ev.key === 'Enter' || ev.key === ' ') && state.isOpen) {
                if (!state.bubbleEvent) {
                    ev.stopPropagation();
                }
                ev.preventDefault();

                dotNetObjRef.invokeMethod("KeydownOnToggle");   
            } else if ((ev.key === 'Enter' || ev.key === 'ArrowDown' || ev.key === ' ') && !state.isOpen) {
                if (!state.bubbleEvent) {
                    ev.stopPropagation();
                }
                ev.preventDefault();

                dotNetObjRef.invokeMethod("KeyDownOnEnter");
            }
        }
        document.getElementById(toggleId).addEventListener("keydown", keydownHandler);
    }
}

window.Blatternfly.CalendarMonth = {
    onKeyDown: (dotNetObjRef, element) => {
        function keydownHandler(ev) {
            if (ev.key === 'ArrowUp' || ev.key === 'ArrowRight' || ev.key === 'ArrowDown' || ev.key === 'ArrowLeft') {
                ev.preventDefault();
                ev.stopPropagation();
                dotNetObjRef.invokeMethodAsync("OnKeyDown", {
                    AltKey      : ev.altKey,
                    Code        : ev.code,
                    CtrlKey     : ev.ctrlKey,
                    IsComposing : ev.isComposing,
                    Key         : ev.key,
                    Locale      : ev.locale,
                    Location    : ev.location,
                    MetaKey     : ev.metaKey,
                    Repeat      : ev.repeat,
                    ShiftKey    : ev.shiftKey,
                    Type        : 'Keydown'
                });
            }
        }
        element.addEventListener("keydown", keydownHandler);
    }
}
