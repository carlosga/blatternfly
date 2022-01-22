export function canUseDOM() {
    return !!(typeof window !== 'undefined' && window.document && window.document.createElement);
}

export function getBoundingClientRect(el) {
    return el.getBoundingClientRect();
}

export function offsetSize(el) {
    return {
        Width: el.offsetWidth,
        Height: el.offsetHeight,
    }
}

export function scrollSize(el) {
    return {
        Width: el.scrollWidth,
        Height: el.scrollHeight,
    }
}

export function scrollLeft(el, scrollWidth) {
    el.scrollLeft += scrollWidth;
}

export function setBodyClass(classlist) {
    document.body.classList.add(classlist);
}

export function removeBodyClass(classlist) {
    document.body.classList.remove(classlist);
}