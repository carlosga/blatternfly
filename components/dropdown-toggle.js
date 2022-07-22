import { KeyTypes } from '../events/key-types.js'

export function onKeyDown(dotNetObjRef, toggle) {
  function keydownHandler(ev) {
    const state = dotNetObjRef.invokeMethod("KeydownState");
    if (ev.key === KeyTypes.Tab && !state.isOpen) {
      return;
    }
    if ((ev.key === KeyTypes.Tab || ev.key === KeyTypes.Enter || ev.key === KeyTypes.Space) && state.isOpen) {
      if (!state.bubbleEvent) {
        ev.stopPropagation();
      }
      ev.preventDefault();

      dotNetObjRef.invokeMethod("KeydownOnToggle");
    } else if ((ev.key === KeyTypes.Enter || ev.key === KeyTypes.ArrowDown || ev.key === KeyTypes.Space) && !state.isOpen) {
      if (!state.bubbleEvent) {
        ev.stopPropagation();
      }
      ev.preventDefault();

      dotNetObjRef.invokeMethod("KeyDownOnEnter");
    }
  }

  toggle.addEventListener("keydown", keydownHandler);
}
