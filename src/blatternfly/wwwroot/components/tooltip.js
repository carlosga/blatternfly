class tooltip {
  constructor(dotNetObjRef, referenceId) {
    this.dotNetObjRef = dotNetObjRef;
    this.refElement   = document.getElementById(referenceId);
    this.refElement.addEventListener('mouseenter', this.onMouseEnter.bind(this));
    this.refElement.addEventListener('mouseleave', this.onMouseLeave.bind(this));
  }

  dispose() {
    this.refElement.removeEventListener('mouseenter', this.onMouseEnter.bind(this));
    this.refElement.removeEventListener('mouseleave', this.onMouseLeave.bind(this));
  }

  onMouseEnter(ev) {
    this.dotNetObjRef.invokeMethodAsync("OnMouseEnter");
  }

  onMouseLeave(ev) {
    this.dotNetObjRef.invokeMethodAsync("OnMouseLeave");
  }
}

export function create(dotNetObjRef, referenceId) {
  return new tooltip(dotNetObjRef, referenceId);
}