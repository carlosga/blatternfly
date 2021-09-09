using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace Blatternfly.Components
{
    public class Button : BaseComponent
    {
        /// Sets the base component to render. defaults to button.
        [Parameter] public string Component { get; set;  } = "button";

        /// Adds active styling to button.
        [Parameter] public bool IsActive { get; set; }

        /// Adds block styling to button.
        [Parameter] public bool IsBlock { get; set; }

        /// Disables the button and adds disabled styling.
        [Parameter] public bool IsDisabled { get; set; }

        /// Adds disabled styling and communicates that the button is disabled using the aria-disabled html attribute.
        [Parameter] public bool IsAriaDisabled { get; set; }

        /// Adds progress styling to button.
        [Parameter] public bool? IsLoading { get; set; }

        /// Aria-valuetext for the loading spinner.
        [Parameter] public string SpinnerAriaValueText { get; set; }

        /// @beta Events to prevent when the button is in an aria-disabled state.
        [Parameter] public string[] InoperableEvents { get; set; }

        /// Adds inline styling to a link button.
        [Parameter] public bool IsInline { get; set; }

        /// Sets button type.
        [Parameter] public ButtonType Type { get; set; } = ButtonType.Button;

        /** Adds button variant styles */
        [Parameter] public ButtonVariant Variant { get; set; } = ButtonVariant.Primary;

        /// Sets position of the link icon
        [Parameter] public Alignments IconPosition { get; set; } = Alignments.Left;

        /// Adds accessible text to the button.
        [Parameter] public string AriaLabel { get; set; }

        /// Icon for the button. Usable by all variants except for plain.
        [Parameter] public RenderFragment Icon { get; set; }

        /// Set button tab index unless component is not a button and is disabled.
        [Parameter] public int? TabIndex { get; set; }

        /// Adds small styling to the button.
        [Parameter] public bool IsSmall { get; set; }

        /// Adds large styling to the button
        [Parameter] public bool IsLarge { get; set; }

        /// Adds danger styling to secondary or link button variants.
        [Parameter] public bool IsDanger { get; set; }

        /// Button Click
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

        private bool IsButtonElement { get => Component == "button"; }
        private bool IsInlineSpan    { get => IsInline && Component == "span"; }
        private int? DefaultTabIndex
        {
            get
            {
                if (IsDisabled)
                {
                    return IsButtonElement ? null : -1;
                }
                else if (IsAriaDisabled)
                {
                    return null;
                }
                else if (IsInlineSpan)
                {
                    return 0;
                }

                return null;
            }
        }

        private string ButtonTypeChoice
        {
            get => Type switch
            {
                ButtonType.Button => "button",
                ButtonType.Submit => "submit",
                ButtonType.Reset  => "reset",
                _                 => null
            };
        }

        private string VariantClass
        {
            get => Variant switch
            {
                ButtonVariant.Primary   => "pf-m-primary",
                ButtonVariant.Secondary => "pf-m-secondary",
                ButtonVariant.Tertiary  => "pf-m-tertiary",
                ButtonVariant.Danger    => "pf-m-danger",
                ButtonVariant.Warning   => "pf-m-warning",
                ButtonVariant.Link      => "pf-m-link",
                ButtonVariant.Plain     => "pf-m-plain",
                ButtonVariant.Inline    => "pf-m-inline",
                ButtonVariant.Control   => "pf-m-control",
                _                       => null
            };
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index             = 0;
            var blockClass        = IsBlock ? "pf-m-block" : null;
            var disabledClass     = IsDisabled ? "pf-m-disabled" : null;
            var ariaDisabledClass = IsAriaDisabled ? "pf-m-aria-disabled" : null;
            var activeClass       = IsActive ? "pf-m-active" : null;
            var progressClass     = IsLoading.HasValue ? "pf-m-progress" : null;
            var loadingClass      = IsLoading.GetValueOrDefault() ? "pf-m-in-progress" : null;
            var inlineClass       = (Variant == ButtonVariant.Link && IsInline) ? "pf-m-inline" : null;
            var smallClass        = IsSmall ? "pf-m-small" : null;
            var largeClass        = IsLarge ? "pf-m-large" : null;
            var isDisabled        = IsDisabled || IsAriaDisabled ? "" : null;
            var ariaDisabled      = IsDisabled || IsAriaDisabled ? "true" : "false";
            var dangerClass       =
                IsDanger && (Variant is ButtonVariant.Secondary or ButtonVariant.Link)
                    ? "pf-m-danger"
                        : null;

            builder.OpenElement(index++, Component);
            builder.AddAttribute(index++, "onclick", EventCallback.Factory.Create(this, OnClick));
            builder.AddEventStopPropagationAttribute(index++, "onclick", true);
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "aria-disabled", ariaDisabled);
            builder.AddAttribute(index++, "aria-label", AriaLabel);
            builder.AddAttribute(index++, "class", $"pf-c-button {VariantClass} {blockClass} {disabledClass} {ariaDisabledClass} {activeClass} {inlineClass} {dangerClass} {progressClass} {loadingClass} {smallClass} {largeClass} {InternalCssClass}");
            if (IsButtonElement && IsDisabled)
            {
                builder.AddAttribute(index++, "disabled", IsButtonElement ? isDisabled : null);
            }
            builder.AddAttribute(index++, "tabIndex", TabIndex ?? DefaultTabIndex);
            builder.AddAttribute(index++, "type", IsButtonElement ? ButtonTypeChoice : null);
            builder.AddAttribute(index++, "role", IsInlineSpan ? "button" : null);
            if (IsLoading.GetValueOrDefault())
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-button__progress");
                builder.OpenComponent<Spinner>(index++);
                builder.AddAttribute(index++, "size", SpinnerSize.Medium);
                builder.AddAttribute(index++, "AriaValueText", SpinnerAriaValueText);
                builder.CloseComponent();
                builder.CloseElement();
            }
            if (Variant != ButtonVariant.Plain && Icon != null && IconPosition == Alignments.Left)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-button__icon pf-m-start");
                builder.AddContent(index++, Icon);
                builder.CloseElement();
            }
            builder.AddContent(index++, ChildContent);
            if (Variant != ButtonVariant.Plain && Icon != null && IconPosition == Alignments.Right)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-button__icon pf-m-end");
                builder.AddContent(index++, Icon);
                builder.CloseElement();
            }
            builder.CloseElement();
        }
    }
}
