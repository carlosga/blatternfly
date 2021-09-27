using System.Threading.Tasks;

namespace Blatternfly.Components
{
    public interface IPortalConnector
    {
        void Register(PortalTarget target);
        Task Attach(Portal portal);
        Task Detach(Portal portal);
    }
}
