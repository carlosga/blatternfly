window.Blatternfly = {
    getBoundingClientRect: function (el) {
        return el.getBoundingClientRect();
    },
    offsetWidth: function (el) {
        return el.offsetWidth;
    },
    canUseDOM: function() { 
        return !!(typeof window !== 'undefined' && window.document && window.document.createElement); 
    },
    windowInnerWidth: function () {
        return window.innerWidth;
    }
}