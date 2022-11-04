using AutoMapper;
using cloud_databases_cvgen.CustomExceptioins;
using cloud_databases_cvgen.Models.DTO;
using cloud_databases_cvgen.Models;
using cloud_databases_cvgen.Services.Interfaces;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Net;

namespace cloud_databases_cvgen.API.Controllers
{
    public class MortageController
    {
        private readonly ILogger<MortageController> _logger;
        private readonly IMortageService _mortgageService;
        private readonly IMapper _mapper;

        public MortageController(ILogger<MortageController> log, IMortageService mortgageService, IMapper mapper)
        {
            _logger = log ?? throw new ArgumentNullException(nameof(log));
            _mortgageService = mortgageService ?? throw new ArgumentNullException(nameof(mortgageService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Function("GetMortgage")]
        [OpenApiOperation(operationId: "GetMortgage", tags: new[] { "GetMortgage" }, Summary = "Get a mortgage by id", Description = "This endpoint returns the mortgage by id")]
        [OpenApiParameter(name: "mortgageId", In = ParameterLocation.Path, Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(MortageResponseDTO), Description = "The OK response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(string), Description = "The BAD REQUEST response")]
        public async Task<HttpResponseData> GetMortgageById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "mortgage/{UserId}")] HttpRequestData req, Guid userId)
        {
            HttpResponseData response = req.CreateResponse();

            try
            {
                Mortage mortgage = await _mortgageService.GetMortageByUserId(userId);

                MortageResponseDTO mappedMortgage = _mapper.Map<MortageResponseDTO>(mortgage);

                await response.WriteAsJsonAsync(mappedMortgage);
            }
            catch (CustomException ex)
            {
                _logger.LogError(ex.Message);
                await response.WriteAsJsonAsync(ex.Message, ex.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await response.WriteAsJsonAsync(ex.Message, HttpStatusCode.BadRequest);
            }

            return response;
        }
    }
}
