using cloud_databases_cvgen.Models;

namespace cloud_databases_cvgen.Services.Interfaces
{
    public interface IMortageService: IService<Mortage>
    {
        public Task<Mortage> GetMortageByUserId(Guid userId);
    }
}
