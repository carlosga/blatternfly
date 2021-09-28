using System.Threading.Tasks;

namespace Blatternfly.Components
{
    public interface IPortalConnector 
    {
        void Attach(PortalTarget target);
        void Detach();
        Task Connect(Portal portal);
        Task Disconnect();
    }
}
