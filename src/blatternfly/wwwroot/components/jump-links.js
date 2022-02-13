let unobserveCallback    = null;
let scrollLockCallback   = null;
let scrollUnlockCallback = null;

export function unobserve(scrollableSelector) {
    unobserveCallback(scrollableSelector);
}

export function lockScroll(scrollableSelector) {
    scrollLockCallback(scrollableSelector);
}

export function unlockScroll(scrollableSelector) {
    scrollUnlockCallback(scrollableSelector);
}

export function observe(jumpLinksElement, scrollableSelector, offsetSelector, dotNetObjRef) {
    let scrollLocked = false;
    let disconnected = false;

    function setActiveIndex(activeIndex) {
        dotNetObjRef.invokeMethod("SetActiveIndex", activeIndex);
    }

    // Recursively find JumpLinkItems and return an array of all their scrollNodes
    function getScrollItems() {
        let res = [];

        const children = jumpLinksElement.querySelectorAll(".pf-c-jump-links__link");

        children.forEach((child) => {
            const scrollNode = child.hash || child.href;

            if (scrollNode !== '') {
                if (scrollNode.startsWith('#')) {
                    // Allow spaces and other special characters as `id`s to be nicer to consumers
                    // https://stackoverflow.com/questions/70579/what-are-valid-values-for-the-id-attribute-in-html
                    res.push(document.getElementById(scrollNode.substr(1)));
                } else {
                    res.push(document.querySelector(scrollNode));
                }
            }
        });

        return res;
    }

    function scrollSpy() {
        const offset = (offsetSelector && offsetSelector.length > 0)
            ? document.querySelector(offsetSelector).offsetHeight
                : 0;

        const scrollableElement = document.querySelector(scrollableSelector);
        const scrollPosition    = Math.ceil(scrollableElement.scrollTop + offset);

        window.requestAnimationFrame(() => {
            if (disconnected || scrollLocked) {
                return;
            }

            let scrollItems = getScrollItems();

            const scrollElements = scrollItems
                .map((e, index) => ({
                    y: e ? e.offsetTop : null,
                    index
                }))
                .filter(({ y }) => y !== null)
                .sort((e1, e2) => e2.y - e1.y);

            for (const { y, index } of scrollElements) {
                if (scrollPosition >= y) {
                    return setActiveIndex(index);
                }
            }
        });
    }

    const element = document.querySelector(scrollableSelector);

    if (!element) {
        return;
    }

    scrollSpy();

    element.addEventListener('scroll', scrollSpy);

    scrollLockCallback = (scrollableSelector) => {
        const scrollableElement = document.querySelector(scrollableSelector);

        if (!scrollableElement) {
            return;
        }

        scrollableElement.removeEventListener('scroll', scrollSpy);
    };

    scrollUnlockCallback = (scrollableSelector) => {
        const scrollableElement = document.querySelector(scrollableSelector);

        if (!scrollableElement) {
            return;
        }

        setTimeout(() => scrollableElement.addEventListener('scroll', scrollSpy), 100);
    };

    unobserveCallback = (scrollableSelector) => {
        disconnected = true;

        const scrollableElement = document.querySelector(scrollableSelector);

        if (!scrollableElement) {
            return;
        }

        scrollableElement.removeEventListener('scroll', scrollSpy);
    };
}
