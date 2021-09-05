export function toKeyboardEvent(ev, type) {
    return {
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
        Type        : type
    }    
}

export function toMouseEvent(ev, composedPath, type) {
    return {
        AltKey      : ev.altKey,
        Button      : ev.button,
        Buttons     : ev.buttons,
        ClientX     : ev.clientX,
        ClientY     : ev.clientY,
        CtrlKey     : ev.ctrlKey,
        MetaKey     : ev.metaKey,
        MovementX   : ev.movementX,
        MovementY   : ev.movementY,
        OffsetX     : ev.OffsetX,
        OffsetY     : ev.OffsetY,
        PageX       : ev.pageX,
        PageY       : ev.pageY,
        ShiftKey    : ev.shiftKey,
        ComposedPath: composedPath,
        Type        : type
    }    
}