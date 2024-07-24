using TechChallengeFase1.Models.Entity;

namespace TechChallengeFase1.Services.Interfaces
{
    public interface IContatoService
    {
        public void AdicionarContato(Contatos contato);
        public void AtualizarContato(Contatos contato);
        public void ExcluirContato(int DDD, int Numero);
        public Contatos ConsultarContato(int DDD, int Numero);
        public List<Contatos> ConsultarContatoPorDDD(int ddd);
    }
}
