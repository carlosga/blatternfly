import {
  computePosition,
  offset,
  // shift,
  // flip
} from '../third-party/floating-ui/floating-ui.dom.esm.min.js';

export async function computeFloatingPosition(referenceId, floatingId, placement, distance, enableFlip, fallbackPlacements) {
  const referenceEl = document.querySelector(`#${referenceId}`);
  const floatingEl  = document.querySelector(`#${floatingId}`);

  const options = {
    placement: placement,
    distance: distance,
    enableFlip: enableFlip,
    fallbackPlacements: fallbackPlacements,
    middleware: [
      offset(distance),
      // shift(),
    ]
  };

  // if (options.enableFlip === true) {
  //   options.middleware.push(flip({
  //     fallbackPlacements: options.fallbackPlacements
  //   }));
  // }

  Object.assign(floatingEl.style, {
    position: 'absolute',
  });

  const { x, y, finalPlacement } = await computePosition(referenceEl, floatingEl, options);

  Object.assign(floatingEl.style, {
    top: '0',
    left: '0',
    transform: `translate3d(${Math.round(x)}px,${Math.round(y)}px,0)`
  });

  return finalPlacement;
}