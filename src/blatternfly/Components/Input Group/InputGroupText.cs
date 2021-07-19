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
            var index = 0;
            var variantClass = Variant == InputGroupTextVariant.Plain ? "pf-m-plain" : null;
            
            builder.OpenElement(index++, Component);
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-input-group__text {variantClass}");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
    }
}
