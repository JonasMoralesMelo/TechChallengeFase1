using TechChallengeFase1.Models.DTO;

namespace TechChallengeFase1.Services.Interfaces
{
    public interface IDDDService
    {
        Task<ResponseGenerico<DDDResponse>> BuscarDDD(int ddd);
    }
}
