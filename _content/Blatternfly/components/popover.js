class popover {
  constructor(dotNetObjRef, referenceId) {
    this.dotNetObjRef = dotNetObjRef;
    this.refElement   = document.getElementById(referenceId);
    this.refElement.addEventListener('click', this.onReferenceElementClick.bind(this));
  }

  dispose() {
    this.refElement.removeEventListener('click', this.onReferenceElementClick.bind(this));
  }

  onReferenceElementClick(ev) {
    this.dotNetObjRef.invokeMethodAsync("OnReferenceElementClicked");
  }
}

export function create(dotNetObjRef, referenceId) {
  return new popover(dotNetObjRef, referenceId);
}