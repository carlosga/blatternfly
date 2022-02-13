import { toKeyboardEvent, toMouseEvent } from '../events/events.js'

export function onResize(dotNetObjRef) {
  function resizeHandler() {
    dotNetObjRef.invokeMethod("OnWindowResize", {
      InnerSize : { Width: window.innerWidth, Height: window.innerHeight }
    });
  }
  window.addEventListener('resize', resizeHandler);
}

export function onClick(dotNetObjRef) {
  function clickHandler(ev) {
    const composedPath = [];

    ev.composedPath().forEach((element) => {
      const elementId = element.id;
      if (elementId) {
        composedPath.push(element.id);
      }
    });

    dotNetObjRef.invokeMethod("OnWindowClick", toMouseEvent(ev, composedPath, 'Click'));
  }
  window.addEventListener("click", clickHandler);
}

export function onKeyDown(dotNetObjRef) {
  function keydownHandler(ev) {
    dotNetObjRef.invokeMethod("OnWindowKeydown", toKeyboardEvent(ev, 'Keydown'));
  }
  window.addEventListener("keydown", keydownHandler);
}