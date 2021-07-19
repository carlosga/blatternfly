using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class HelperTextItem : BaseComponent
    {
        /// Sets the component type of the helper text item.
        [Parameter] public HelperTextItemComponent Component { get; set; } = HelperTextItemComponent.div;

        /// Variant styling of the helper text item. */
        [Parameter] public HelperTextItemVariant Variant { get; set; } = HelperTextItemVariant.Default;

        /// Custom icon prefixing the helper text. This property will override the default icon paired with each helper text variant.
        [Parameter] public RenderFragment Icon { get; set; }

        /// Flag indicating the helper text item is dynamic.
        [Parameter] public bool IsDynamic { get; set; }

        /// Flag indicating the helper text should have an icon. Dynamic helper texts include icons by default while static helper texts do not.
        [Parameter] public bool HasIcon { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;
            var component = Component switch
            {
                HelperTextItemComponent.div => "div",
                HelperTextItemComponent.li  => "li",
                _                           => "div"
            };
            var dynamicClass = IsDynamic ? "pf-m-dynamic" : null;
            var variantClass = Variant switch
            {
                HelperTextItemVariant.Indeterminate => "pf-m-indeterminate",
                HelperTextItemVariant.Warning       => "pf-m-warning",
                HelperTextItemVariant.Success       => "pf-m-success",
                HelperTextItemVariant.Error         => "pf-m-error",
                _                                   => null
            };

            builder.OpenElement(index++, component);
            builder.AddAttribute(index++, "class", $"pf-c-helper-text__item {variantClass} {dynamicClass}");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);

            if (Icon is not null)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-helper-text__item-icon");
                builder.AddAttribute(index++, "aria-hidden", "true");
                builder.AddContent(index++, Icon);
                builder.CloseElement();
            }
            if (HasIcon && Icon is null)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-helper-text__item-icon");
                builder.AddAttribute(index++, "aria-hidden", "true");
                if (Variant == HelperTextItemVariant.Default
                 || Variant == HelperTextItemVariant.Indeterminate)
                {
                    builder.OpenComponent<MinusIcon>(index++);
                }
                else if (Variant == HelperTextItemVariant.Warning)
                {
                    builder.OpenComponent<ExclamationTriangleIcon>(index++);
                }
                else if (Variant == HelperTextItemVariant.Success)
                {
                    builder.OpenComponent<CheckIcon>(index++);
                }
                else if (Variant == HelperTextItemVariant.Error)
                {
                    builder.OpenComponent<TimesIcon>(index++);
                }
                builder.CloseComponent();
                builder.CloseElement();
            }

            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-helper-text__item-text");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();

            builder.CloseElement();
        }
    }
}
