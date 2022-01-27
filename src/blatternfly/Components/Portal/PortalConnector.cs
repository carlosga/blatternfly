using System;
using System.Threading.Tasks;

namespace Blatternfly.Components;

public sealed class PortalConnector : IPortalConnector
{
    private PortalHost _host;

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

    public async ValueTask ConnectAsync(Portal portal)
    {
        if (_host is null)
        {
            throw new InvalidOperationException("There is no portal target registered.");
        }
        if (!_host.CanAttach)
        {
            throw new InvalidOperationException("There is already a portal attached to the current portal target.");
        }
        await _host.ConnectAsync(portal);
    }

    public async ValueTask DisconnectAsync()
    {
        if (_host is null)
        {
            throw new InvalidOperationException("There is no portal target registered.");
        }
        await _host.DisconnectAsync();
    }
}
