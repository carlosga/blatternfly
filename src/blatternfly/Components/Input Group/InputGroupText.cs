using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class InputGroupText : BaseComponent
    {
        /// Component that wraps the input group text.
        [Parameter] public string Component { get; set; } = "span";

        /// Input group text variant.
        [Parameter]
        public InputGroupTextVariant Variant { get; set; } = InputGroupTextVariant.Default;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var variantClass = Variant == InputGroupTextVariant.Plain ? "pf-m-plain" : null;

            builder.OpenElement(1, Component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-c-input-group__text {variantClass} {InternalCssClass}");
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
