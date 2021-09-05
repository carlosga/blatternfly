export function onKeyDown(dotNetObjRef, element) {
    function keydownHandler(ev) {
        if (ev.key === 'ArrowUp' || ev.key === 'ArrowRight' || ev.key === 'ArrowDown' || ev.key === 'ArrowLeft') {
            ev.preventDefault();
            ev.stopPropagation();
            dotNetObjRef.invokeMethodAsync("OnKeyDown", {
                AltKey      : ev.altKey,
                Code        : ev.code,
                CtrlKey     : ev.ctrlKey,
                IsComposing : ev.isComposing,
                Key         : ev.key,
                Locale      : ev.locale,
                Location    : ev.location,
                MetaKey     : ev.metaKey,
                Repeat      : ev.repeat,
                ShiftKey    : ev.shiftKey,
                Type        : 'Keydown'
            });
        }
    }
    element.addEventListener("keydown", keydownHandler);
}
