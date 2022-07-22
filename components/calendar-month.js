import { toKeyboardEvent } from '../events/events.js'
import { KeyTypes } from '../events/key-types.js'

export function onKeyDown(dotNetObjRef, element) {
  function keydownHandler(ev) {
    if (ev.key === KeyTypes.ArrowUp || ev.key === KeyTypes.ArrowRight || ev.key === KeyTypes.ArrowDown || ev.key === KeyTypes.ArrowLeft) {
      ev.preventDefault();
      ev.stopPropagation();
      dotNetObjRef.invokeMethodAsync("OnKeyDown", toKeyboardEvent(ev, 'Keydown'));
    }
  }
  element.addEventListener("keydown", keydownHandler);
}
