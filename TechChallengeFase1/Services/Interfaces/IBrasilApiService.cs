using TechChallengeFase1.Models.DTO;
using TechChallengeFase1.Models;
using TechChallengeFase1.Models.Entity;

namespace TechChallengeFase1.Services.Interfaces
{
    public interface IBrasilApiService
    {
        Task<ResponseGenerico<DDDModel>> BuscarPorCodigoDDD(int ddd);
        List<ContatosDTO> buscarRegiaoPorContato(List<Contatos> contatos);
    }

}
