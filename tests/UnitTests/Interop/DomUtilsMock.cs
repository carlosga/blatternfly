namespace Blatternfly.UnitTests.Interop;

public sealed class DomUtilsMock : IDomUtils
{
    ValueTask IAsyncDisposable.DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }

    ValueTask IDomUtils.SetBodyClass(string classlist)
    {
        return ValueTask.CompletedTask;
    }

    ValueTask IDomUtils.RemoveBodyClass(string classlist)
    {
        return ValueTask.CompletedTask;
    }

    ValueTask<Size<int>> IDomUtils.GetWindowSizeAsync()
    {
        return ValueTask.FromResult(new Size<int> { Width = 3840, Height = 2160 });
    }

    ValueTask<BoundingClientRect> IDomUtils.GetBoundingClientRectAsync(ElementReference el)
    {
        return ValueTask.FromResult<BoundingClientRect>(new BoundingClientRect { Left = 0, Right = 0 });
    }

    ValueTask<Size<int>> IDomUtils.GetClientSizeAsync(ElementReference el)
    {
        return ValueTask.FromResult<Size<int>>(new Size<int>());
    }

    ValueTask<Size<double>> IDomUtils.GetOffsetSizeAsync(ElementReference el)
    {
        return ValueTask.FromResult<Size<double>>(new Size<double>());
    }

    ValueTask<Size<double>> IDomUtils.GetScrollSizeAsync(ElementReference el)
    {
        return ValueTask.FromResult<Size<double>>(new Size<double>());
    }

    ValueTask IDomUtils.ScrollLeftAsync(ElementReference el, double scrollWidth)
    {
        return ValueTask.CompletedTask;
    }

    ValueTask IDomUtils.ScrollIntoViewAsync(string elementId)
    {
        return ValueTask.CompletedTask;
    }

    ValueTask<bool> IDomUtils.HasTruncatedHeightAsync(ElementReference el)
    {
        return ValueTask.FromResult<bool>(false);
    }

    ValueTask<bool> IDomUtils.HasTruncatedWidthAsync(ElementReference el)
    {
        return ValueTask.FromResult<bool>(false);
    }

    ValueTask<double?> IDomUtils.CalculateMenuContentHeightAsync(ElementReference el)
    {
        return ValueTask.FromResult<double?>(1.0);
    }
}
