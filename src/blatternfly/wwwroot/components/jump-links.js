let unobserveCallback = null;
let scrollLocked      = false;
let disconnected      = false;

export function unobserve(scrollableSelector) {
    unobserveCallback(scrollableSelector);
}

export function lockScroll() {
    scrollLocked = true;
}

export function unlockScroll() {
    scrollLocked = false;
}

export function observe(jumpLinksElement, scrollableSelector, offsetSelector, dotNetObjRef) {
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
        if (disconnected || scrollLocked) {
            return;
        }

        const offset = (offsetSelector && offsetSelector.length > 0)
            ? document.querySelector(offsetSelector).offsetHeight
                : 0;
        const scrollPosition = Math.ceil(scrollableElement.scrollTop + offset);

        window.requestAnimationFrame(() => {
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
                    console.log(`Index = ${index} / Item ${scrollItems[index].hash}`);
                    return setActiveIndex(index);
                }
            }
        });
    }

    const scrollableElement = document.querySelector(scrollableSelector);

    if (!scrollableElement) {
        return;
    }

    scrollableElement.addEventListener('scroll', scrollSpy);

    unobserveCallback = (scrollableSelector) => {
        disconnected = true;

        const scrollableElement = document.querySelector(scrollableSelector);

        if (!scrollableElement) {
            return;
        }

        scrollableElement.removeEventListener('scroll', scrollSpy);
    };
}
