// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
using System.Diagnostics;

namespace Blatternfly.Components;

/// Partially based on Blazor source code.
/// https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/EditForm.cs
public class Form : ComponentBase
{
    private readonly Func<Task> _handleSubmitDelegate; // Cache to avoid per-render allocations

    private EditContext _editContext;
    private bool _hasSetEditContextExplicitly;

    public Form()
    {
        _handleSubmitDelegate = HandleSubmitAsync;
    }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment<EditContext> ChildContent { get; set; }

    /// <summary>
    /// Explicitly sets form edit context.
    /// </summary>
    [Parameter]
    public EditContext EditContext
    {
        get => _editContext;
        set
        {
            _editContext = value;
            _hasSetEditContextExplicitly = value is not null;
        }
    }

    /// <summary>
    /// The top-level model object for the form.
    /// </summary>
    [Parameter]
    public object Model { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted.
    /// </summary>
    [Parameter]
    public EventCallback<EditContext> OnSubmit { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted and the
    /// </summary>
    [Parameter]
    public EventCallback<EditContext> OnValidSubmit { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted and the
    /// </summary>
    [Parameter]
    public EventCallback<EditContext> OnInvalidSubmit { get; set; }

    /// <summary>
    /// Sets the Form to horizontal.
    /// </summary>
    [Parameter]
    public bool IsHorizontal { get; set; }

    /// <summary>
    /// Flag to limit the max-width to 500px.
    /// </summary>
    [Parameter]
    public bool IsWidthLimited { get; set; }

    /// <summary>
    /// Sets a custom max-width for the form.
    /// </summary>
    [Parameter]
    public string MaxWidth { get; set; }

    private string CssClass => new CssBuilder("pf-c-form")
        .AddClass("pf-m-horizontal" , IsHorizontal)
        .AddClass("pf-m-limit-width", IsWidthLimited && !string.IsNullOrEmpty(MaxWidth))
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-c-form--m-limit-width--MaxWidth", MaxWidth, !string.IsNullOrEmpty(MaxWidth))
        .AddStyleFromAttributes(AdditionalAttributes)
        .Build();

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

        builder.OpenRegion(_editContext.GetHashCode());

        builder.OpenElement(0, "form");
        builder.AddAttribute(1, "novalidate", "");
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddAttribute(4, "style", CssStyle);
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
