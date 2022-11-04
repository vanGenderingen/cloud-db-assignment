using AutoMapper;
using cloud_databases_cvgen.Models;
using cloud_databases_cvgen.Models.DTO;
using cloud_databases_cvgen.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace cloud_databases_cvgen.API.Controllers
{
    internal class UserController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Function("CreateUser")]
        [OpenApiOperation(operationId: "CreateUser", tags: new[] { "CreateUser" }, Summary = "Create a new user", Description = "This endpoint allows the creation of a new user.")]
        [OpenApiRequestBody("application/json", typeof(CreateUserRequestDTO), Description = "The user data.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(CreatedUserResponseDTO), Description = "The CREATED response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(string), Description = "The BAD REQUEST response")]
        public async Task<HttpResponseData> CreateUser([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Users")] HttpRequestData req)
        {
            HttpResponseData response = req.CreateResponse(HttpStatusCode.Created);
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            try
            {
                CreateUserRequestDTO requestBodyData = JsonConvert.DeserializeObject<CreateUserRequestDTO>(requestBody);

                User user = _mapper.Map<User>(requestBodyData);

                User createdUser = await _userService.Create(user);

                CreateUserRequestDTO mappedCreatedUser = _mapper.Map<CreateUserRequestDTO>(createdUser);

                await response.WriteAsJsonAsync(mappedCreatedUser);
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

