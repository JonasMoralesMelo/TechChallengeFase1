using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TechChallengeFase1.Models.Entity;
using TechChallengeFase1.Services.Interfaces;

namespace TechChallengeFase1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        private readonly IBrasilApiService _brasilApiService;

        public ContatoController(IContatoService contatoService, IBrasilApiService brasilApiService)
        {
            _contatoService = contatoService;
            _brasilApiService = brasilApiService;
        }

        [HttpGet("{DDD}/{Numero}")]
        public IActionResult obterContato(int DDD, int Numero)
        {
            try
            {
                return Ok(_contatoService.ConsultarContato(DDD, Numero));
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro: {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult adicionarContato(Contatos contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoService.AdicionarContato(contato);
                    return Created($"/api/Contato/{contato}", contato);
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro: {ex.Message}");
            }
        }
        [HttpPut]
        public IActionResult atualizarContato(Contatos contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoService.AtualizarContato(contato);
                    return Ok(contato);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro: {ex.Message}");
            }
        }
        [HttpDelete]
        public IActionResult excluirContato(int DDD, int Numero)
        {
            try
            {
                _contatoService.ExcluirContato(DDD, Numero);
                return Ok($"Contato ({DDD}) {Numero} excluído com sucesso");
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro: {ex.Message}");
            }
        }
        [HttpGet("{DDD}")]
        public IActionResult obterContatoRegiao(int DDD)
        {
            try
            {
                List<Contatos> listacontatos = _contatoService.ConsultarContatoPorDDD(DDD);
                return Ok(_brasilApiService.buscarRegiaoPorContato(listacontatos));
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro: {ex.Message}");
            }
        }
    }
}
