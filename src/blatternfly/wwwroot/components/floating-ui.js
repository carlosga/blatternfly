import {
  computePosition,
  offset,
  shift,
  flip
} from 'https://cdn.skypack.dev/@floating-ui/dom@0.2.0';

export async function computeFloatingPosition(referenceId, floatingId, options) {
  options = options || {};

  const referenceEl = document.querySelector(`#${referenceId}`);
  const floatingEl  = document.querySelector(`#${floatingId}`);

  options.middleware = [
    offset(options.distance),
    shift(),
  ];

  if (options.enableFlip === true) {
    options.middleware.push(flip({
      fallbackPlacements: options.fallbackPlacements
    }));
  }

  Object.assign(floatingEl.style, {
    position: 'absolute',
  });

  computePosition(referenceEl, floatingEl, options).then(({x, y}) => {
    Object.assign(floatingEl.style, {
      top: '0',
      left: '0',
      transform: `translate3d(${Math.round(x)}px,${Math.round(y)}px,0)`
    });
  });
}