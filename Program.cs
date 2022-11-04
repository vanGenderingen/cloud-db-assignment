using System;
using System.Reflection;
using System.Threading.Tasks;
using cloud_databases_cvgen.DAL;
using cloud_databases_cvgen.DAL.Context;
using cloud_databases_cvgen.DAL.Repositories;
using cloud_databases_cvgen.DAL.Repositories.Interfaces;
using cloud_databases_cvgen.Services;
using cloud_databases_cvgen.Services.Interfaces;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using User = cloud_databases_cvgen.Models.User;

namespace Casper.CloudDatabase
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("local.settings.json", true, true)
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
            .AddEnvironmentVariables()
            .Build();

            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureOpenApi()
                .ConfigureServices(services =>
                {
                    services.AddAutoMapper(typeof(Program));

                    services.AddSingleton(new FunctionConfiguration(config));
                    services.AddDbContext<DatabaseContext>();

                    services.AddScoped<IRepository<User>, UserRepository>();
                    services.AddScoped<IUserRepository, UserRepository>();
                    services.AddScoped<IUserService, UserService>();

                    services.AddAutoMapper(typeof(Program));
                })
                .Build();

            await host.RunAsync();
        }
    }
}
