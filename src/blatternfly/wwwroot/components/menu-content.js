import { toKeyboardEvent } from '../events/events.js'
import { KeyTypes } from '../events/key-types.js'

export function refCallback(dotNetObjRef, element) {
  if (!element) {
    return null;
  }
  let clientHeight = el.clientHeight;

  // if this menu is a submenu, we need to account for the root menu list's padding and root menu content's border.
  let rootMenuList = null;
  let parentEl     = element.closest(`.${styles.menuList}`);
  while (parentEl !== null && parentEl.nodeType === 1) {
    if (parentEl.classList.contains(styles.menuList)) {
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
