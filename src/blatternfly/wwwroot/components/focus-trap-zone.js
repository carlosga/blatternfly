import { createFocusTrap } from '../focus-trap/focus-trap.esm.js'

let focusTrap;

export function create(dotNetObjRef, element, options) {
    focusTrap = createFocusTrap(element, options);
}

export function activate() {
    focusTrap.activate();
}

export function deactivate() {
    focusTrap.deactivate();
}

export function pause() {
    focusTrap.pause();
}

export function unpause() {
    focusTrap.unpause();
}
