using cloud_databases_cvgen.DAL.Context;
using cloud_databases_cvgen.DAL.Repositories.Interfaces;
using cloud_databases_cvgen.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cloud_databases_cvgen.DAL.Repositories
{
    internal class Repository<T>: IRepository<T> where T : class, IEntity
    {
        protected readonly DatabaseContext _databaseContext;

        protected Repository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public virtual async Task<T> Ceate(T entity)
        {
            await _databaseContext.Set<T>().AddAsync(entity);
            await _databaseContext.SaveChangesAsync();

            return await GetById(entity.Id);
        }

        public Task<T> Commit()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _databaseContext.Set<T>()
                .SingleOrDefaultAsync(entity => entity.Id == id);
        }
    }
}
