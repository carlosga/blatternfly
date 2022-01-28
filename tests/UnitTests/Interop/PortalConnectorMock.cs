using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Blatternfly.UnitTests.Interop;

public sealed class PortalConnectorMock : IPortalConnector
{
    private readonly Subject<Portal> _connectStream;
    private readonly Subject<Portal> _disconnectStream;

    public IObservable<Portal> OnConnect    { get => _connectStream.AsObservable(); }
    public IObservable<Portal> OnDisconnect { get => _disconnectStream.AsObservable(); }

    public PortalConnectorMock()
    {
        _connectStream    = new Subject<Portal>();
        _disconnectStream = new Subject<Portal>();
    }

    public void Attach(PortalHost host)
    {
    }

    public void Detach()
    {
    }

    public void Connect(Portal portal)
    {
    }

    public void Disconnect(Portal portal)
    {
    }
}
