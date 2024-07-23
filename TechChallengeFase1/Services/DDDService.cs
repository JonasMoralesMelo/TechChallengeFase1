using TechChallengeFase1.Models.DTO;
using TechChallengeFase1.Services.Interfaces;
using AutoMapper;

namespace TechChallengeFase1.Services
{
    public class DDDService : IDDDService
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApiService _brasilApi;
        
        public DDDService(IMapper mapper, IBrasilApiService brasilApi)
        {
            _mapper = mapper;
            _brasilApi = brasilApi;
        }
        public async Task<ResponseGenerico<DDDResponse>> BuscarDDD(int ddd)
        {
            var endereco = await _brasilApi.BuscarPorCodigoDDD(ddd);

            return _mapper.Map<ResponseGenerico<DDDResponse>>(endereco);
        }
    }
 }
