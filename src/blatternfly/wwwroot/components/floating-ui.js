import { computePosition, offset, shift, flip } from '../third-party/floating-ui/floating-ui.dom.esm.min.js';

export async function computeFloatingPosition(referenceId, floatingId, placement, distance, enableFlip, fallbackPlacements) {
  const referenceEl = document.querySelector(`#${referenceId}`);
  const floatingEl  = document.querySelector(`#${floatingId}`);

  if (!referenceEl)
  {
    console.log(`Invalid reference element reference ${referenceId}`);
    return;
  }
  if (!floatingEl)
  {
    console.log(`Invalid floating element reference ${floatingId}`);
    return;
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