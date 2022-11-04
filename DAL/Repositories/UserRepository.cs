using cloud_databases_cvgen.DAL.Context;
using cloud_databases_cvgen.DAL.Repositories.Interfaces;
using cloud_databases_cvgen.Models;

namespace cloud_databases_cvgen.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
