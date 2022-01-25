import {
  computePosition,
  offset
} from 'https://cdn.skypack.dev/@floating-ui/dom@0.2.0';

export function computeFloatingPosition(referenceId, floatingId, options) {
    options = options || {};

    const reference = document.querySelector(`#${referenceId}`);
    const floating  = document.querySelector(`#${floatingId}`);

    options.middleware = [
      offset(options.distance),
    ];

    Object.assign(floating.style, {
      position: 'absolute',
    });

    computePosition(reference, floating, options).then(({x, y}) => {
        Object.assign(floating.style, {
          top: '0',
          left: '0',
          transform: `translate3d(${Math.round(x)}px,${Math.round(y)}px,0)`,
        });
      });
}