using TechChallengeFase1.Models.DTO;
using TechChallengeFase1.Models;
using AutoMapper;

namespace TechChallengeFase1.Data.Mapping
{
    public class DDDMapping : Profile
    {
        public DDDMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<DDDResponse, DDDModel>();
            CreateMap<DDDModel, DDDResponse>();
        }
    }
}
