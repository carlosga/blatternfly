using System;
using System.Threading.Tasks;

namespace Blatternfly.Components
{
    public sealed class PortalConnector : IPortalConnector
    {
        private PortalTarget _target;
        
        public void Attach(PortalTarget target)
        {
            if (_target is not null)
            {
                throw new InvalidOperationException("There is already a target container registered.");
            }
            _target = target;
        }
        
        public void Detach()
        {
            _target = null;
        }

        public async Task Connect(Portal portal)
        {
            if (_target is null)
            {
                throw new InvalidOperationException("There is no portal target registered.");
            }
            if (!_target.CanAttach)
            {
                throw new InvalidOperationException("There is already a portal attached to the current portal target.");
            }
            await _target.Connect(portal);
        }

        public async Task Disconnect()
        {
            if (_target is null)
            {
                throw new InvalidOperationException("There is no portal target registered.");
            }
            await _target.Disconnect();
        }
    }
}
