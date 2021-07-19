using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace Blatternfly.Components
{
    public class Label : BaseComponent
    {
        /// Color of the label.
        [Parameter] public LabelColor Color { get; set; } = LabelColor.Grey;

        /// Variant of the label.
        [Parameter] public LabelVariant Variant { get; set; } = LabelVariant.Filled;

        /// Flag indicating the label text should be truncated.
        [Parameter] public bool IsTruncated { get; set; }

        /// Icon added to the left of the label text.
        [Parameter] public RenderFragment Icon { get; set; }

        /// Href for a label that is a link. If present, the label will change to an anchor element.
        [Parameter] public string Href { get; set; }

        /// Close click callback for removable labels. If present, label will have a close button.
        [Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }

        /// Node for custom close button.
        [Parameter] public RenderFragment CloseBtn { get; set; }

        /// Flag indicating if the label is an overflow label.
        [Parameter] public bool IsOverflowLabel { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;
            var labelComponent = IsOverflowLabel ? "button" : "span";
            var component      = !string.IsNullOrEmpty(Href) ? "a" : "span";
            var overflowClass  = IsOverflowLabel ? "pf-m-overflow" : null;
            var variantClass   = Variant switch
            {
                LabelVariant.Filled  => "pf-m-filled",
                LabelVariant.Outline => "pf-m-outline",
                _                    => null
            };
            var  colorClass = Color switch
            {
                LabelColor.Blue   => "pf-m-blue",
                LabelColor.Cyan   => "pf-m-cyan",
                LabelColor.Green  => "pf-m-green",
                LabelColor.Orange => "pf-m-oramge",
                LabelColor.Purple => "pf-m-purple",
                LabelColor.Red    => "pf-m-red",
                _                 => null
            };

            builder.OpenElement(index++, labelComponent);
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-label {colorClass} {variantClass} {overflowClass}");

            builder.OpenElement(index++, component);
            builder.AddAttribute(index++, "class", "pf-c-label__content");
            builder.AddAttribute(index++, "href", Href);
            if (Icon is not null)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-label__icon");
                builder.AddContent(index++, Icon);
                builder.CloseElement();
            }
            if (IsTruncated)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-label__text");
                builder.AddContent(index++, ChildContent);
                builder.CloseElement();
            }
            else
            {
                builder.AddContent(index++, ChildContent);
            }
            builder.CloseElement();

            if (OnClose.HasDelegate)
            {
                if (CloseBtn is not null)
                {
                    builder.AddContent(index++, CloseBtn);
                }
                else
                {
                    builder.OpenComponent<Button>(index++);
                    builder.AddAttribute(index++, "Type", ButtonType.Button);
                    builder.AddAttribute(index++, "Variant", ButtonVariant.Plain);
                    builder.AddAttribute(index++, "aria-label", "label-close-button");
                    builder.AddAttribute(index++, "OnClick", EventCallback.Factory.Create(this, OnClose));
                    builder.AddAttribute(index++, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder rfbuilder)
                    {
                        rfbuilder.OpenComponent<TimesIcon>(index++);
                        rfbuilder.CloseComponent();
                    });
                    builder.CloseComponent();
                }
            }

            builder.CloseElement();
        }
    }
}
