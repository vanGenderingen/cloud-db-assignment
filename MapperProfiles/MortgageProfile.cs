using AutoMapper;
using cloud_databases_cvgen.Models;
using cloud_databases_cvgen.Models.DTO;

namespace cloud_databases_cvgen.MapperProfiles
{
    public class MortgageProfile: Profile
    {
        public MortgageProfile()
        {
            CreateMap<Mortage, MortageResponseDTO>();
        }
    }
}
