import { computePosition, offset, shift, flip } from '../third-party/floating-ui/floating-ui.dom.esm.min.js';

export async function computeFloatingPosition(referenceId, floatingId, placement, distance, enableFlip, fallbackPlacements) {
  const referenceEl = document.querySelector(`#${referenceId}`);
  const floatingEl  = document.querySelector(`#${floatingId}`);

  if (!referenceEl)
  {
    console.log(`Invalid element reference ${referenceId}`);
    return {
      Placement: 'top',
      X: 0,
      Y: 0
    };
  }
  if (!floatingEl)
  {
    console.log(`Invalid floating element ${floatingId}`);
    return {
      Placement: 'top',
      X: 0,
      Y: 0
    };
  }

  const options = {
    placement: placement,
    distance: distance,
    enableFlip: enableFlip,
    fallbackPlacements: fallbackPlacements,
    middleware: [offset(distance), shift()]
  };

  if (options.enableFlip === true) {
    options.middleware.push(flip({
      fallbackPlacements: options.fallbackPlacements
    }));
  }

  const result = await computePosition(referenceEl, floatingEl, options);

  return {
    Placement: result.placement,
    X: Math.round(result.x),
    Y: Math.round(result.y)
  };
}