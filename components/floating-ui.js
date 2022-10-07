import { computePosition, offset, shift, flip, autoPlacement } from '../third-party/floating-ui/floating-ui.dom.esm.min.js';

export async function computeFloatingPosition(referenceId, floatingId, placement, distance, enableFlip, fallbackPlacements) {
  const options = {
    placement: placement === 'auto' ? undefined : placement,
    distance: distance,
    middleware: [offset(distance), shift()]
  };

  // auto and flip middlewares cannot be used at the same time
  if (placement === 'auto') {
    options.middleware.push(autoPlacement({padding: distance}))
  } else if (enableFlip === true) {
    options.middleware.push(flip({fallbackPlacements: fallbackPlacements}));
  }

  const referenceEl = document.getElementById(referenceId);
  const floatingEl  = document.getElementById(floatingId);

  if (!referenceEl || !floatingEl) {
    // The call to this function is on Blazor AfterRenderAsync method,
    // looks like Blazor may emit several sequentia AfterRenderCalls,
    // for example when the floating element visibility is controlled by the mouse enter/leave events,
    // and reaching this point the elements may not be in the DOM
    return null;
  }

  const result = await computePosition(referenceEl, floatingEl, options);

  return {
    Placement: result.placement,
    X: Math.round(result.x),
    Y: Math.round(result.y)
  };
}