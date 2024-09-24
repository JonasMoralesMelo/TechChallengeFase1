using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechChallengeFase1.Models;

namespace TechChallengeFase1.Teste
{
    public class BrasilAPITest 
    {
        [Fact]
        public async Task AcessarBrasilAPI()
        {
            using(var client = new HttpClient())
            {
                string url = $"https://brasilapi.com.br/api/ddd/v1/21";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                var objResponse = JsonSerializer.Deserialize<DDDModel>(responseBody);

                Assert.Contains("RJ", objResponse.Estado);
                Assert.Contains("RIO DE JANEIRO", objResponse.Cidades);

            }
        }
    }
}
