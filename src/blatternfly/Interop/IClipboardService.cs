using System.Threading.Tasks;

namespace Blatternfly.Interop;

public interface IClipboardService
{
    ValueTask WriteTextAsync(string text);
}
