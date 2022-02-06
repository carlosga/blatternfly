let unobserveCallback = null;
let disconnected      = false;

export function unobserve(scrollableSelector) {
    unobserveCallback(scrollableSelector);
}

export function observe(jumpLinksElement, scrollableSelector, dotNetObjRef) {
    function handleScrolling(activeIndex) {
        dotNetObjRef.invokeMethod("OnScroll", activeIndex);
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
    };

    function scrollSpy() {
        // if (isLinkClicked.current) {
        //     isLinkClicked.current = false;
        //     return;
        // }

        const offset         = 0;   // TODO: offset should be passed to the observe call
        const scrollPosition = Math.ceil(scrollableElement.scrollTop + offset);

        window.requestAnimationFrame(() => {
            if (disconnected) {
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
                    return handleScrolling(index);
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
