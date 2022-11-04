using cloud_databases_cvgen.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloud_databases_cvgen.DAL.Repositories.Interfaces
{
    internal interface IRepository<T> where T : class, IEntity
    {
        public Task<T> GetById(Guid id);
        public Task<ICollection<T>> GetAll();
        public Task<T> Ceate(T entity);
        public Task<T> Commit();
    }
}
