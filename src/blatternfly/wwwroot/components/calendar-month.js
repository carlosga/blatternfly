import { toKeyboardEvent } from '../events/events.js'
 
export function onKeyDown(dotNetObjRef, element) {
    function keydownHandler(ev) {
        if (ev.key === 'ArrowUp' || ev.key === 'ArrowRight' || ev.key === 'ArrowDown' || ev.key === 'ArrowLeft') {
            ev.preventDefault();
            ev.stopPropagation();
            dotNetObjRef.invokeMethodAsync("OnKeyDown", toKeyboardEvent(ev, 'Keydown'));
        }
    }
    element.addEventListener("keydown", keydownHandler);
}
