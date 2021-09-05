 export function onKeyDown(dotNetObjRef, toggleId) {
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
