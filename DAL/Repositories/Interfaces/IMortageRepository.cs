using cloud_databases_cvgen.Models;

namespace cloud_databases_cvgen.DAL.Repositories.Interfaces
{
    public interface IMortageRepository: IRepository<Mortage>
    {
        public Task<Mortage> GetMortageByUserId(Guid userId);
    }
}
