export function getWindowSize() { return { Width: window.innerWidth, Height: window.innerHeight } }

export function getBoundingClientRect(el) {
    return el.getBoundingClientRect();
}

export function clientSize(el) {
    return { Width: el.clientWidth, Height: el.clientHeight }
}

export function offsetSize(el) {
    return { Width: el.offsetWidth, Height: el.offsetHeight }
}

export function scrollSize(el) {
    return { Width: el.scrollWidth, Height: el.scrollHeight }
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