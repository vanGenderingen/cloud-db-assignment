using cloud_databases_cvgen.DAL.Repositories.Interfaces;
using cloud_databases_cvgen.Models;
using cloud_databases_cvgen.Services.Interfaces;
using cloud_databases_cvgen.CustomExceptioins;


namespace cloud_databases_cvgen.Services
{
    public class MortageService : Service<Mortage>, IMortageService
    {
        private readonly IMortageRepository _mortgageRepository;

        public MortageService(IRepository<Mortage> repository, IMortageRepository mortageRepository) : base(repository)
        {
            _mortgageRepository = mortageRepository;
        }

        public async Task<Mortage> GetMortageByUserId(Guid userId)
        {
            Mortage mortage = await _mortgageRepository.GetMortageByUserId(userId);
            if (mortage == null)
            {
                throw new CustomException(ErrorCodes.NoMortageForUser.Key, string.Format(ErrorCodes.NoMortageForUser.Value));
            }
            if(mortage.ExpireDate < DateTime.UtcNow)
            {
                throw new CustomException(ErrorCodes.MortgageExpired.Key, string.Format(ErrorCodes.MortgageExpired.Value));
            }

            return mortage;
        }
    }
}
