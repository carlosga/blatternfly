import { createFocusTrap } from '../third-party/focus-trap/focus-trap.esm.js'

export function create(element, options) {
    return createFocusTrap(element, options);
}

export function activate(focusTrap) {
    focusTrap.activate();
}

export function deactivate(focusTrap) {
    focusTrap.deactivate();
}

export function pause(focusTrap) {
    focusTrap.pause();
}

export function unpause(focusTrap) {
    focusTrap.unpause();
}
