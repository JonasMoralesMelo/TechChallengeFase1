using TechChallengeFase1.Models.Entity;

namespace TechChallengeFase1.Services.Interfaces
{
    public interface IContatoService
    {
        public void AdicionarContato();
        public void AtualizarContato();
        public void ExcluirContato();
        public Contatos ConsultarContato();
        public List<Contatos> ConsultarContatoPorDDD(int ddd);


    }
}
