namespace Blatternfly.Components
{
    public interface IPortalConnector
    {
        void Register(PortalTarget target);
        void Attach(Portal portal);
        void Detach(Portal portal);
    }
}
