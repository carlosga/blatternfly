namespace Blatternfly.Interop;

public interface IDomUtils : IAsyncDisposable
{
    ValueTask SetBodyClass(string classlist);

    ValueTask RemoveBodyClass(string classlist);

    ValueTask<Size<int>> GetWindowSizeAsync();

    ValueTask<BoundingClientRect> GetBoundingClientRectAsync(ElementReference el);

    ValueTask<Size<int>> GetClientSizeAsync(ElementReference el);

    ValueTask<Size<double>> GetOffsetSizeAsync(ElementReference el);

    ValueTask<Size<double>> GetScrollSizeAsync(ElementReference el);

    ValueTask ScrollLeftAsync(ElementReference el, double scrollWidth);

    ValueTask ScrollIntoViewAsync(string elementId);

    ValueTask<bool> HasTruncatedHeight(ElementReference el);

    ValueTask<bool> HasTruncatedWidth(ElementReference el);
}
