export function observe(containerRef, dotNetObjRef) {
  function handleResize(width, height) {
    dotNetObjRef.invokeMethod("OnContainerResize", {
      InnerSize : { Width: Math.round(width), Height: Math.round(height) }
    });
  }

  const resizeObserver = new ResizeObserver((entries) => {
    if (Array.isArray(entries) && entries.length == 1) {
      window.requestAnimationFrame(() => {
        const rect = entries[0].contentRect;
        handleResize(rect.width, rect.height);
      });
    }
  });

  resizeObserver.observe(containerRef);

  return resizeObserver;
}
