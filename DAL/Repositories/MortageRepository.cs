using cloud_databases_cvgen.DAL.Context;
using cloud_databases_cvgen.DAL.Repositories.Interfaces;
using cloud_databases_cvgen.Models;
using Microsoft.EntityFrameworkCore;

namespace cloud_databases_cvgen.DAL.Repositories
{
    public class MortgageRepository : Repository<Mortage>, IMortageRepository
    {
        public MortgageRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<Mortage> GetMortageByUserId(Guid userId)
        {
            User user = await _databaseContext.Users
                .SingleOrDefaultAsync(u => u.Id == userId);

            return user.Mortage;
        }
    }
}
