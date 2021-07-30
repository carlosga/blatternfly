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
