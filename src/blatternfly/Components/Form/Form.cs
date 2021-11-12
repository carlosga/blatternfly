// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components;

/// <summary>
/// Some parts has been copied from Blazor source code.
/// </summary>
public class Form : ComponentBase
{
    private readonly Func<Task> _handleSubmitDelegate; // Cache to avoid per-render allocations

    private EditContext _editContext;
    private bool _hasSetEditContextExplicitly;

    public Form()
    {
        _handleSubmitDelegate = HandleSubmitAsync;
    }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    [Parameter]
    public EditContext EditContext
    {
        get => _editContext;
        set
        {
            _editContext = value;
            _hasSetEditContextExplicitly = value != null;
        }
    }

    [Parameter] public object Model { get; set; }

    [Parameter] public RenderFragment<EditContext> ChildContent { get; set; }

    [Parameter] public EventCallback<EditContext> OnSubmit { get; set; }

    [Parameter] public EventCallback<EditContext> OnValidSubmit { get; set; }

    [Parameter] public EventCallback<EditContext> OnInvalidSubmit { get; set; }

    /// Sets the Form to horizontal.
    [Parameter] public bool IsHorizontal { get; set; }

    /// Flag to limit the max-width to 500px.
    [Parameter] public bool IsWidthLimited { get; set; }

    protected override void OnParametersSet()
    {
        if (_hasSetEditContextExplicitly && Model is not null)
        {
            throw new InvalidOperationException($"{nameof(Form)} requires a {nameof(Model)} parameter, or an {nameof(EditContext)} parameter, but not both.");
        }
        else if (!_hasSetEditContextExplicitly && Model is null)
        {
            throw new InvalidOperationException($"{nameof(Form)} requires either a {nameof(Model)} parameter, or an {nameof(EditContext)} parameter, please provide one of these.");
        }

        if (OnSubmit.HasDelegate && (OnValidSubmit.HasDelegate || OnInvalidSubmit.HasDelegate))
        {
            throw new InvalidOperationException($"When supplying an {nameof(OnSubmit)} parameter to {nameof(Form)}, do not also supply {nameof(OnValidSubmit)} or {nameof(OnInvalidSubmit)}.");
        }

        if (Model is not null && Model != _editContext?.Model)
        {
            _editContext = new EditContext(Model);
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        Debug.Assert(_editContext is not null);

        var orientationStyle = IsHorizontal ? "pf-m-horizontal" : null;
        var widthLimitClass  = IsWidthLimited ? "pf-m-limit-width" : null;

        builder.OpenRegion(_editContext.GetHashCode());

        builder.OpenElement(1, "form");
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "novalidate", "");
        builder.AddAttribute(4, "class", $"pf-c-form {orientationStyle} {widthLimitClass}");
        builder.AddAttribute(5, "onsubmit", _handleSubmitDelegate);
        builder.OpenComponent<CascadingValue<EditContext>>(6);
        builder.AddAttribute(7, "IsFixed", true);
        builder.AddAttribute(8, "Value", _editContext);
        builder.AddAttribute(9, "ChildContent", ChildContent?.Invoke(_editContext));
        builder.CloseComponent();
        builder.CloseElement();

        builder.CloseRegion();
    }

    private async Task HandleSubmitAsync()
    {
        Debug.Assert(_editContext is not null);

        if (OnSubmit.HasDelegate)
        {
            await OnSubmit.InvokeAsync(_editContext);
        }
        else
        {
            var isValid = _editContext.Validate();

            if (isValid && OnValidSubmit.HasDelegate)
            {
                await OnValidSubmit.InvokeAsync(_editContext);
            }

            if (!isValid && OnInvalidSubmit.HasDelegate)
            {
                await OnInvalidSubmit.InvokeAsync(_editContext);
            }
        }
    }
}
