using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloud_databases_cvgen.Models.Interfaces
{
    internal interface IEntity
    {
        Guid Id { get; set; }
    }
}
