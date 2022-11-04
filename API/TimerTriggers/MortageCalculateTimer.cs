using cloud_databases_cvgen.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Timer = cloud_databases_cvgen.Models.Timer;

namespace cloud_databases_cvgen.API.TimerTriggers
{
    public class MortageCalculateTimer
    {
        private readonly ILogger<MortageCalculateTimer> _logger;
        private readonly IUserService _userService;

        public MortageCalculateTimer(ILogger<MortageCalculateTimer> logger, IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [Function("CalculateMortage")]
        public async Task Run([TimerTrigger("0 0 23 * * *")] Timer timer)
        {
            //Run the update everynight at 23:00
            await _userService.CalculateMortgages();
        }
    }
}
