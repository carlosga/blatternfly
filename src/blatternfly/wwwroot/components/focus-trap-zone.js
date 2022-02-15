import { createFocusTrap } from '../third-party/focus-trap/focus-trap.esm.js'

export function create(element, options) {
  return createFocusTrap(element, options);
}