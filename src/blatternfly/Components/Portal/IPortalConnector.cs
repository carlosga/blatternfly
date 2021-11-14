using System.Threading.Tasks;

namespace Blatternfly.Components;

public interface IPortalConnector 
{
    void Attach(PortalHost host);
    void Detach();
    Task Connect(Portal portal);
    Task Disconnect();
}
