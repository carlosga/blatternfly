import {
  computePosition,
  offset,
  shift,
  flip,
  // getScrollParents
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

  async function update() {
    const {x, y} = await computePosition(referenceEl, floatingEl, options);
    Object.assign(floatingEl.style, {
      top: '0',
      left: '0',
      transform: `translate3d(${Math.round(x)}px,${Math.round(y)}px,0)`
    });
  }

  await update(referenceEl, floatingEl, options);

  // Adds event listeners to `window`
  // addEventListener('scroll', update);
  // addEventListener('resize', update);

  // [
  //   ...getScrollParents(referenceEl),
  //   ...getScrollParents(floatingEl),
  // ].forEach((el) => {
  //   el.addEventListener('scroll', update);
  //   el.addEventListener('resize', update);
  // });
}