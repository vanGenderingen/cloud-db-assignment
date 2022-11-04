using System;
using Microsoft.Extensions.Logging;
using cloud_databases_cvgen.Models;
using cloud_databases_cvgen.Services.Interfaces;
using cloud_databases_cvgen.DAL.Repositories.Interfaces;

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

        public async Task CalculateMortgages()
        {
            foreach (User user in await _repository.GetAll())
            {
                if (user.Mortage is null)
                {
                    Mortage mortage = new Mortage()
                    {
                        Id = Guid.NewGuid(),
                        MaximumMortage = user.AnnualIncome * 5,
                        ExpireDate = DateTime.UtcNow.AddDays(1)
                    };
                    user.Mortage = mortage;

                    await _repository.Commit();
                }
                else
                {
                    _logger.LogInformation("Mortage already has been set for user" + user.Id);
                }

            }
        }
    }
}
