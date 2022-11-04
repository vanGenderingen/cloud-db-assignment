using cloud_databases_cvgen.CustomExceptioins;
using cloud_databases_cvgen.DAL;
using cloud_databases_cvgen.DAL.Repositories.Interfaces;
using cloud_databases_cvgen.Models;
using cloud_databases_cvgen.Services.Interfaces;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace cloud_databases_cvgen.Services
{
    public class MailService: IMailService
    {
        private readonly ILogger<MailService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly FunctionConfiguration _config;

        public MailService(ILogger<MailService> logger, IUserRepository userRepository, FunctionConfiguration config)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        private async Task SendEmail(User user)
        {
            // Set the email details
            SendGridClient client = new(_config.SendgridAPIKey);
            EmailAddress sender = new("luuk@lkenselaar.dev");
            string subject = "BuyMyHouse - calculated mortgage";
            EmailAddress receiver = new(user.Email);

            string contentPlaintext = $"http://localhost:7022/api/mortgage/{user.Id}";

            string contentHTML = $"<a href='http://localhost:7022/api/mortgage/{user.Id}'>Klik hier</a>";

            SendGridMessage message = MailHelper.CreateSingleEmail(sender, receiver, subject, contentPlaintext, contentHTML);

            Response response = await client.SendEmailAsync(message);

            if (response.IsSuccessStatusCode)
            {
                user.Mortage.MailSent = true;
                await _userRepository.Commit();
            }
            else
            {
                _logger.LogError($"Mail couldn't be send");
                throw new CustomException(ErrorCodes.MailNotSend.Key, string.Format(ErrorCodes.MailNotSend.Value));
            }
        }

        public async Task MailAllUsers()
        {
            foreach (User user in await _userRepository.GetAll())
            {
                if (user.Mortage != null && user.Mortage.MailSent == false)
                {
                    await SendEmail(user);
                }
                else
                {
                    _logger.LogInformation($"UserId: {user.Id} - mortgage not set, or has already been set");
                }
            }
        }
    }
}
