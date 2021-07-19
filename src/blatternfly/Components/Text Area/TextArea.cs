using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class TextArea : InputComponentBase<string>
    {
        [DisallowNull] public ElementReference Element { get; protected set; }

        /// Sets the orientation to limit the resize to.
        [Parameter] public ResizeOrientation ResizeOrientation { get; set; } = ResizeOrientation.None;

        /// Flag to show if the TextArea is read only.
        [Parameter] public bool IsReadOnly { get; set; }

        /// Placeholder of the TextArea.
        [Parameter] public string Placeholder { get; set; }

        [Parameter] public int? ColumnCount { get; set; }

        [Parameter] public int? RowCount { get; set; }

        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;
            var resizeOrientationClass = ResizeOrientation switch
            {
                ResizeOrientation.Both       => "pf-m-resize-both",
                ResizeOrientation.Horizontal => "pf-m-resize-horizontal",
                ResizeOrientation.Vertical   => "pf-m-resize-vertical",
                ResizeOrientation.None       => "pf-m-no-resize",
                _                            => null
            };

            builder.OpenElement(index++, "textarea");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-form-control {resizeOrientationClass} {ValidationClass}");
            builder.AddAttribute(index++, "cols", ColumnCount);
            builder.AddAttribute(index++, "rows", RowCount);
            builder.AddAttribute(index++, "placeholder", Placeholder);
            builder.AddAttribute(index++, "aria-label", AriaLabel);
            builder.AddAttribute(index++, "aria-invalid", AriaInvalid);
            builder.AddAttribute(index++, "required", IsRequired);
            builder.AddAttribute(index++, "disabled", IsDisabled);
            builder.AddAttribute(index++, "readOnly", IsReadOnly);
            builder.AddAttribute(index++, "value", BindConverter.FormatValue(Value));
            builder.AddAttribute(index++, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
            builder.AddElementReferenceCapture(5, __inputReference => Element = __inputReference);
            builder.CloseElement();
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, [MaybeNullWhen(false)] out string result, [NotNullWhen(false)] out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
