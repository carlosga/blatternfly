using System.Reactive.Linq;
using System.Reactive.Subjects;
namespace Blatternfly.Components;

public sealed class PortalConnector : IPortalConnector, IDisposable
{
    private PortalHost _host;
    private readonly Subject<Portal> _connectStream;
    private readonly Subject<Portal> _disconnectStream;

    public IObservable<Portal> OnConnect     { get => _connectStream.AsObservable(); }
    public IObservable<Portal> OnDisconnect  { get => _disconnectStream.AsObservable(); }

    public PortalConnector()
    {
        _connectStream    = new Subject<Portal>();
        _disconnectStream = new Subject<Portal>();
    }

    public void Dispose()
    {
        _connectStream?.Dispose();
        _disconnectStream?.Dispose();
    }

    public void Attach(PortalHost host)
    {
        if (_host is not null)
        {
            throw new InvalidOperationException("There is already a target container registered.");
        }
        _host = host;
    }

    public void Detach()
    {
        _host = null;
    }

    public void Connect(Portal portal)
    {
        if (_host is null)
        {
            throw new InvalidOperationException("There is no portal target registered.");
        }
        if (!_host.CanAttach)
        {
            throw new InvalidOperationException("There is already a portal attached to the current portal target.");
        }
        _host.Connect(portal);
        _connectStream.OnNext(portal);
    }

    public void Disconnect(Portal portal)
    {
        if (_host is null)
        {
            throw new InvalidOperationException("There is no portal target registered.");
        }
        _host.Disconnect();
        _disconnectStream.OnNext(portal);
    }
}
