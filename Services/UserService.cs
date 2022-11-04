using System;
using Microsoft.Extensions.Logging;
using cloud_databases_cvgen.Models;
using cloud_databases_cvgen.Services.Interfaces;
using cloud_databases_cvgen.DAL.Repositories.Interfaces;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace cloud_databases_cvgen.Services
{
    public class UserService : Service<User>, IUserService
    {
        public readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger, IRepository<User> repository) : base(repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public override async Task<User> Create(User user)
        {
            return await _repository.Create(user);
        }

    }
}
