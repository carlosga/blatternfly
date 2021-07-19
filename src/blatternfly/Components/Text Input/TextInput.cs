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
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;
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
            var customIconStyle = string.Empty;
            if (!string.IsNullOrEmpty(CustomIconUrl)) {
                customIconStyle += $"background-image: url('{CustomIconUrl}');";
            }
            if (!string.IsNullOrEmpty(CustomIconDimensions)) {
                customIconStyle += $"background-size: '{CustomIconDimensions}';";
            }
            if (iconVariantClass == null && !string.IsNullOrEmpty(customIconStyle))
            {
                iconVariantClass = "pf-m-icon";
            }

            builder.OpenElement(index++, "input");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-form-control {iconVariantClass} {ValidationClass}");
            builder.AddAttribute(index++, "type", inputType);
            builder.AddAttribute(index++, "aria-label", AriaLabel);
            builder.AddAttribute(index++, "aria-invalid", AriaInvalid);
            builder.AddAttribute(index++, "required", IsRequired);
            builder.AddAttribute(index++, "disabled", IsDisabled);
            builder.AddAttribute(index++, "readOnly", IsReadOnly);
            builder.AddAttribute(index++, "value", BindConverter.FormatValue(CurrentValueAsString));
            builder.AddAttribute(index++, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
            builder.AddAttribute(index++, "onfocus", EventCallback.Factory.Create(this, OnFocus));
            builder.AddAttribute(index++, "onblur", EventCallback.Factory.Create(this, OnBlur));
            builder.AddAttribute(index++, "style", customIconStyle);
            builder.AddElementReferenceCapture(index++, __inputReference => Element = __inputReference);
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
