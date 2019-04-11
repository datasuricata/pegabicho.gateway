using System.Threading.Tasks; 

namespace pegabicho.infra.Transaction
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
