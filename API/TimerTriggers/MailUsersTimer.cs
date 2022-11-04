using cloud_databases_cvgen.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Timer = cloud_databases_cvgen.Models.Timer;

namespace cloud_databases_cvgen.API.TimerTriggers
{
    public class MailUsersTimer
    {
        private readonly ILogger<MailUsersTimer> _logger;
        private readonly IMailService _mailService;

        public MailUsersTimer(ILogger<MailUsersTimer> log, IMailService mailService)
        {
            _logger = log ?? throw new ArgumentNullException(nameof(log));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }

        [Function("MailUsersTimer")]
        public void Run([TimerTrigger("0 0 23 * * *")] Timer timer)
        {
            _logger.LogInformation("Sending mail to the users");
            _mailService.MailAllUsers();
        }
    }
}
