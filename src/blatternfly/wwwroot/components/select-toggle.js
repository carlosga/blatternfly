import { KeyTypes } from '../events/key-types.js'

export function onKeyDown(dotNetObjRef, toggle) {
  function keydownHandler(ev) {
    const state = dotNetObjRef.invokeMethod("KeydownState");

    if ((args.Key === KeyTypes.Tab && !state.isOpen)
        || (ev.key !== KeyTypes.Enter && event.key !== KeyTypes.Space)) {
        return;
    }
    ev.preventDefault();
    if ((ev.key === KeyTypes.Tab || ev.key === KeyTypes.Enter || ev.key === KeyTypes.Space) && state.isOpen) {
        dotNetObjRef.invokeMethod("KeydownOnToggle");
    } else if ((ev.key === KeyTypes.Enter || event.key === KeyTypes.Space) && !state.isOpen) {
        dotNetObjRef.invokeMethod("KeyDownOnEnter");
    }
  }

  toggle.addEventListener("keydown", keydownHandler);
}
