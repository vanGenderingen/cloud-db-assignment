using cloud_databases_cvgen.DAL.Repositories.Interfaces;
using cloud_databases_cvgen.Models.Interfaces;
using cloud_databases_cvgen.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cloud_databases_cvgen.Services
{
    public abstract class Service<T> : IService<T> where T : class, IEntity
    {
        protected readonly IRepository<T> _repository;

        protected Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T> GetById(Guid id) => await _repository.GetById(id);

        public virtual async Task<ICollection<T>> GetAll() => await _repository.GetAll();

        public virtual async Task<T> Create(T entity) => await _repository.Create(entity);
    }
}
