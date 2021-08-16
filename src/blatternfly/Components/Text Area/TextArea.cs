using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class TextArea : InputComponentBase<string>
    {
        [DisallowNull] public ElementReference Element { get; protected set; }

        /// Sets the orientation to limit the resize to.
        [Parameter] public ResizeOrientation? ResizeOrientation { get; set; }

        /// Flag to show if the TextArea is read only.
        [Parameter] public bool IsReadOnly { get; set; }

        /// Placeholder of the TextArea.
        [Parameter] public string Placeholder { get; set; }

        [Parameter] public int? ColumnCount { get; set; }

        [Parameter] public int? RowCount { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (string.IsNullOrEmpty(InternalId) && string.IsNullOrEmpty(AriaLabel))
            {
                throw new InvalidOperationException("TextArea: TextArea requires either an id or aria-label to be specified");
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var resizeOrientationClass = ResizeOrientation switch
            {
                Blatternfly.ResizeOrientation.Both       => "pf-m-resize-both",
                Blatternfly.ResizeOrientation.Horizontal => "pf-m-resize-horizontal",
                Blatternfly.ResizeOrientation.Vertical   => "pf-m-resize-vertical",
                _                                        => null
            };

            builder.OpenElement(1, "textarea");
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-c-form-control {resizeOrientationClass} {ValidationClass}");
            builder.AddAttribute(4, "cols", ColumnCount);
            builder.AddAttribute(5, "rows", RowCount);
            builder.AddAttribute(6, "placeholder", Placeholder);
            builder.AddAttribute(7, "aria-label", AriaLabel);
            builder.AddAttribute(8, "aria-invalid", AriaInvalid);
            builder.AddAttribute(9, "required", IsRequired);
            builder.AddAttribute(10, "disabled", IsDisabled);
            builder.AddAttribute(11, "readOnly", IsReadOnly);
            builder.AddAttribute(12, "value", BindConverter.FormatValue(Value));
            builder.AddAttribute(13, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
            builder.AddElementReferenceCapture(14, __inputReference => Element = __inputReference);
            builder.CloseElement();
        }

        protected override bool TryParseValueFromString(string value, [MaybeNullWhen(false)] out string result, [NotNullWhen(false)] out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
