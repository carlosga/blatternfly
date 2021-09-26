using System;

namespace Blatternfly.Components
{
    public sealed class PortalConnector : IPortalConnector
    {
        private PortalTarget _target;
        
        public void Register(PortalTarget target)
        {
            if (_target is not null)
            {
                throw new InvalidOperationException("There is already a target container registered.");
            }
            _target = target;
        }

        public void Attach(Portal portal)
        {
            if (_target is null)
            {
                throw new InvalidOperationException("There is no portal target registered.");
            }
            if (!_target.CanAttach)
            {
                throw new InvalidOperationException("There is already a portal attached to the current portal target.");
            }
            _target.Attach(portal);
        }

        public void Detach(Portal portal)
        {
            if (_target is null)
            {
                throw new InvalidOperationException("There is no portal target registered.");
            }
            _target.Detach(portal);
        }
    }
}
