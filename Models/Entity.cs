using cloud_databases_cvgen.Models.Interfaces;
using Newtonsoft.Json;
using System;

namespace cloud_databases_cvgen.Models
{
    public class Entity : IEntity
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid Id { get; set; }
    }
}
