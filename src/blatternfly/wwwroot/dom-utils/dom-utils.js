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

export function scrollIntoView(elementId) {
  var element = document.getElementById(elementId);
  if (element) {
    element.scrollIntoView();
  }
}

export function hasTruncatedHeight(element) {
  return element.offsetHeight < element.scrollHeight;
}

export function hasTruncatedWidth(element) {
  return element.offsetWidth < element.scrollWidth;
}

export function isRendered(elementId) {
  const element = document.getElementById(elementId);

  // console.log(`isRendered(${elementId})` + element + ' ' + (new Date()).toISOString());

  return typeof element !== 'undefined' && element !== null ;
}