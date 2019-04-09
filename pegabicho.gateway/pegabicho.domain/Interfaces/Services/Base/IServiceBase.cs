using pegabicho.domain.Interfaces.Services.Events;
using System.Threading.Tasks;

namespace pegabicho.domain.Interfaces.Services.Base
{
    public interface IServiceBase : IEventNotifier
    {
        Task Commit();
        Task CommitForce();
    }
}
