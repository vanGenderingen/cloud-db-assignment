using cloud_databases_cvgen.DAL.Context;
using cloud_databases_cvgen.DAL.Repositories.Interfaces;
using cloud_databases_cvgen.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cloud_databases_cvgen.DAL.Repositories
{
    public class Repository<T>: IRepository<T> where T : class, IEntity
    {
        protected readonly DatabaseContext _databaseContext;

        protected Repository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task Commit()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public virtual async Task<T> Create(T entity)
        {
            await _databaseContext.Set<T>().AddAsync(entity);
            await _databaseContext.SaveChangesAsync();

            return await GetById(entity.Id);
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await _databaseContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _databaseContext.Set<T>()
                .SingleOrDefaultAsync(entity => entity.Id == id);
        }
    }
}
