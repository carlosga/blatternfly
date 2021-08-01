window.Blatternfly = {
    getBoundingClientRect: (el) => {
        return el.getBoundingClientRect();
    },
    offsetWidth: (el) => {
        return el.offsetWidth;
    },
    canUseDOM: () => { 
        return !!(typeof window !== 'undefined' && window.document && window.document.createElement); 
    },
    windowInnerWidth: () => {
        return window.innerWidth;
    },
}

window.Blatternfly.Window = {
    onResize: (dotNetObjRef) => {
        function resizeHandler() {
            const w = window.innerWidth;
            const h = window.innerHeight;            
            dotNetObjRef.invokeMethod("OnWindowResize", w, h);
        }
        window.addEventListener('resize', resizeHandler);
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
        function keydownHandler(event) {
            const state = dotNetObjRef.invokeMethod("KeydownState");
            if (event.key === 'Tab' && !state.isOpen) {
                return;
            }
            if ((event.key === 'Tab' || event.key === 'Enter' || event.key === ' ') && state.isOpen) {
                if (!state.bubbleEvent) {
                    event.stopPropagation();
                }
                event.preventDefault();

                dotNetObjRef.invokeMethod("KeydownOnToggle");   
            } else if ((event.key === 'Enter' || event.key === 'ArrowDown' || event.key === ' ') && !state.isOpen) {
                if (!state.bubbleEvent) {
                    event.stopPropagation();
                }
                event.preventDefault();

                dotNetObjRef.invokeMethod("KeyDownOnEnter");
            }
        }
        document.getElementById(toggleId).addEventListener("keydown", keydownHandler);
    }
}
