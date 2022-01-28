using System;
using System.Threading.Tasks;

namespace Blatternfly.Components;

public interface IPortalConnector
{
    IObservable<Portal> OnConnect    { get; }
    IObservable<Portal> OnDisconnect { get; }

    void Attach(PortalHost host);
    void Detach();
    void Connect(Portal portal);
    void Disconnect(Portal portal);
}
