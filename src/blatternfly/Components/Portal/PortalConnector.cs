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

    public async Task Connect(Portal portal)
    {
        if (_host is null)
        {
            throw new InvalidOperationException("There is no portal target registered.");
        }
        if (!_host.CanAttach)
        {
            throw new InvalidOperationException("There is already a portal attached to the current portal target.");
        }
        await _host.Connect(portal);
    }

    public async Task Disconnect()
    {
        if (_host is null)
        {
            throw new InvalidOperationException("There is no portal target registered.");
        }
        await _host.Disconnect();
    }
}
