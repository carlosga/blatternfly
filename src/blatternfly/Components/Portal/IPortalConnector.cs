using System.Threading.Tasks;

namespace Blatternfly.Components;

public interface IPortalConnector
{
    void Attach(PortalHost host);
    void Detach();
    ValueTask ConnectAsync(Portal portal);
    ValueTask DisconnectAsync();
}
