using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class TextInput : InputComponentBase<string>
    {
        [DisallowNull] public ElementReference Element { get; protected set; }

        /// Type that the input accepts.
        [Parameter] public TextInputTypes Type { get; set; } = TextInputTypes.Text;

        /// Flag to show if the input is read only.
        [Parameter] public bool IsReadOnly { get; set; }

        /// Callback function when input is focused.
        [Parameter] public EventCallback OnFocus { get; set; }

        /// Callback function when input is blurred (focus leaves).
        [Parameter] public EventCallback OnBlur { get; set; }

        /// Icon variant
        [Parameter] public TextInputIconVariants? IconVariant { get; set; }

        /// Custom icon url to set as the input's background-image.
        [Parameter] public string CustomIconUrl { get; set; }

        /// Dimensions for the custom icon set as the input's background-size.
        [Parameter] public string CustomIconDimensions { get; set; }
        
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            var ariaLabelledBy = GetPropertyValue("aria-labelledby");
            
            if (string.IsNullOrEmpty(InternalId) 
             && string.IsNullOrEmpty(AriaLabel) 
             && string.IsNullOrEmpty(ariaLabelledBy))
            {
                throw new InvalidOperationException("TextInput: Text input requires either an id or aria-label to be specified");
            }
        }
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var iconVariantClass = IconVariant switch
            {
                TextInputIconVariants.Calendar => "pf-m-icon pf-m-calendar",
                TextInputIconVariants.Clock    => "pf-m-icon pf-m-clock",
                TextInputIconVariants.Search   => "pf-m-icon pf-m-search",
                _                              => null
            };
            var inputType = Type switch
            {
                TextInputTypes.Text          => "text",
                TextInputTypes.Date          => "date",
                TextInputTypes.DatetimeLocal => "datetime-local",
                TextInputTypes.Email         => "email",
                TextInputTypes.Month         => "month",
                TextInputTypes.Number        => "number",
                TextInputTypes.Password      => "password",
                TextInputTypes.Search        => "search",
                TextInputTypes.Tel           => "tel",
                TextInputTypes.Time          => "time",
                TextInputTypes.Url           => "url",
                _                            => "text"
            };
            string customIconStyle = null;
            if (!string.IsNullOrEmpty(CustomIconUrl) || !string.IsNullOrEmpty(CustomIconDimensions))
            {
                customIconStyle = string.Empty;
                if (!string.IsNullOrEmpty(CustomIconUrl)) 
                {
                    customIconStyle += $"background-image: url('{CustomIconUrl}');";
                }
                if (!string.IsNullOrEmpty(CustomIconDimensions)) 
                {
                    customIconStyle += $"background-size: '{CustomIconDimensions}';";
                }
            }
            if (iconVariantClass == null && !string.IsNullOrEmpty(customIconStyle))
            {
                iconVariantClass = "pf-m-icon";
            }

            builder.OpenElement(1, "input");
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-c-form-control {iconVariantClass} {ValidationClass}");
            builder.AddAttribute(4, "type", inputType);
            builder.AddAttribute(5, "aria-label", AriaLabel);
            builder.AddAttribute(6, "aria-invalid", AriaInvalid);
            builder.AddAttribute(7, "required", IsRequired);
            builder.AddAttribute(8, "disabled", IsDisabled);
            builder.AddAttribute(9, "readOnly", IsReadOnly);
            builder.AddAttribute(10, "value", BindConverter.FormatValue(CurrentValueAsString));
            builder.AddAttribute(11, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
            builder.AddAttribute(12, "onfocus", EventCallback.Factory.Create(this, OnFocus));
            builder.AddAttribute(13, "onblur", EventCallback.Factory.Create(this, OnBlur));
            builder.AddAttribute(14, "style", customIconStyle);
            builder.AddElementReferenceCapture(15, __inputReference => Element = __inputReference);
            builder.CloseElement();
        }
        
        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
