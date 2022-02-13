export function observe(containerRefElement, dotNetObjRef) {
  function handleResize() {
    dotNetObjRef.invokeMethod("OnContainerResize", {
      InnerSize : { Width: containerRefElement.clientWidth, Height: containerRefElement.clientHeight }
    });
  }

  const resizeObserver = new ResizeObserver((entries) => {
    // Wrap resize function in requestAnimationFrame to avoid "ResizeObserver loop limit exceeded" errors
    window.requestAnimationFrame(() => {
      if (Array.isArray(entries) && entries.length > 0) {
        handleResize();
      }
    });
  });

  resizeObserver.observe(containerRefElement);

  return resizeObserver;
}
