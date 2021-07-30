window.Blatternfly = {
    getBoundingClientRect: function (el) {
        return el.getBoundingClientRect();
    },
    offsetWidth: function (el) {
        return el.offsetWidth;
    },
    canUseDOM: function() { 
        return !!(typeof window !== 'undefined' && window.document && window.document.createElement); 
    },
    windowInnerWidth: function () {
        return window.innerWidth;
    },
}

window.Blatternfly.Dropdown = {
    onKeyDown: function (dotNetObjRef, toggleId) {
        function keydownHandler(event) {
            const state = dotNetObjRef.invokeMethod("KeydownState");
            if (event.key === 'Tab' && !state.isOpen) {
                return;
            }
            if ((event.key === 'Tab' || event.key === 'Enter') && state.isOpen) {
                if (!state.bubbleEvent) {
                    event.stopPropagation();
                }
                event.preventDefault();

                if (event.key !== ' ') {
                    dotNetObjRef.invokeMethod("KeydownOnToggle");   
                }
            } else if ((event.key === 'Enter' || event.key === 'ArrowDown') && !state.isOpen) {
                if (!state.bubbleEvent) {
                    event.stopPropagation();
                }
                event.preventDefault();

                dotNetObjRef.invokeMethod("KeyDownOnEnter"); // onToggle + onEnter   
            }
        }
        document.getElementById(toggleId).addEventListener("keydown", keydownHandler);
    }
}
