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

export function calculateMenuHeight(element) {
  if (!element) {
    return null;
  }

  let clientHeight = element.clientHeight;

  // if this menu is a submenu, we need to account for the root menu list's padding and root menu content's border.
  let rootMenuList = null;
  let parentEl     = element.closest('.pf-c-menu__list');
  while (parentEl !== null && parentEl.nodeType === 1) {
    if (parentEl.classList.contains('pf-c-menu__list')) {
      rootMenuList = parentEl;
    }
    parentEl = parentEl.parentElement;
  }

  if (rootMenuList) {
    const rootMenuListStyles = getComputedStyle(rootMenuList);
    const rootMenuListPaddingOffset =
      parseFloat(rootMenuListStyles.getPropertyValue('padding-top').replace(/px/g, '')) +
      parseFloat(rootMenuListStyles.getPropertyValue('padding-bottom').replace(/px/g, '')) +
      parseFloat(
        getComputedStyle(rootMenuList.parentElement)
          .getPropertyValue('border-bottom-width')
          .replace(/px/g, '')
      );
    clientHeight = clientHeight + rootMenuListPaddingOffset;
  }

  return clientHeight;
}
