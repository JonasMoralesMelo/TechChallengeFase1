using System.Dynamic;
using System.Text.Json;
using TechChallengeFase1.Models.DTO;
using TechChallengeFase1.Models;
using TechChallengeFase1.Services.Interfaces;

namespace TechChallengeFase1.Services
{
    public class BrasilApiService : IBrasilApiService
    {
        public async Task<ResponseGenerico<DDDModel>> BuscarPorCodigoDDD(int ddd)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/ddd/v1/{ddd}");

            var response = new ResponseGenerico<DDDModel>();
            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<DDDModel>(contentResp);

                if (responseBrasilApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;
        }
    }
}

