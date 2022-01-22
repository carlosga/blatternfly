export function observe(containerRefElement, dotNetObjRef) {
    function handleResize() {
        dotNetObjRef.invokeMethod("OnContainerResize", {
            InnerSize : { Width: window.innerWidth, Height: window.innerHeight }
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
    // unobserve = () => resizeObserver.unobserve(containerRefElement);
}
