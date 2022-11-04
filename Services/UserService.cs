using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using cloud_databases_cvgen.Models;
using cloud_databases_cvgen.Services.Interfaces

namespace cloud_databases_cvgen.Services
{
    internal class UserService(ILogger<UserService> logger) : base(repo)
    {
    }
}
