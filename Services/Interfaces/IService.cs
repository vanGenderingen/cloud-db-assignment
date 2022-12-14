using cloud_databases_cvgen.Models;
using cloud_databases_cvgen.Models.Interfaces;

namespace cloud_databases_cvgen.Services.Interfaces
{
    public interface IService<T> where T : class, IEntity
    {
        public Task<T> GetById(Guid id);
        public Task<ICollection<T>> GetAll();
        public Task<T> Create(T entity);
    }
}
