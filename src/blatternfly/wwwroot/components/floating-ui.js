import { computePosition, offset, shift, flip, autoPlacement } from '../third-party/floating-ui/floating-ui.dom.esm.js';

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
    options.middleware.push(flip({ fallbackPlacements: fallbackPlacements }));
  }

  const referenceEl = document.querySelector(`#${referenceId}`);
  const floatingEl  = document.querySelector(`#${floatingId}`);
  const result      = await computePosition(referenceEl, floatingEl, options);

  return {
    Placement: result.placement,
    X: Math.round(result.x),
    Y: Math.round(result.y)
  };
}