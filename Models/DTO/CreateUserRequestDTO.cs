using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;

namespace cloud_databases_cvgen.Models.DTO
{
    public class CreateUserRequestDTO
    {
        [JsonRequired]
        [OpenApiProperty(Default = "John Doe", Description = "This is the name of the user")]
        public string Name { get; set; }
        [JsonRequired]
        [OpenApiProperty(Default = "JohnDoe@mail.nl", Description = "This is the email of the user")]
        public string Email { get; set; }
        [JsonRequired]
        [OpenApiProperty(Default = "30000", Description = "This is the annual income of the user")]
        public double AnnualIncome { get; set; }
        [JsonRequired]
        [OpenApiProperty(Default = "12", Description = "This is the loan term of the user in months")]
        public int LoanTerm { get; set; }
    }
}
