using TechChallengeFase1.Models.DTO;
using TechChallengeFase1.Models;

namespace TechChallengeFase1.Services.Interfaces
{
    public interface IBrasilApiService
    {
        Task<ResponseGenerico<DDDModel>> BuscarPorCodigoDDD(int ddd);
    }
}
