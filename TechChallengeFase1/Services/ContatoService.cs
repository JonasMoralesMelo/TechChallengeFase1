using Microsoft.IdentityModel.Tokens;
using TechChallengeFase1.Data;
using TechChallengeFase1.Models.Entity;
using TechChallengeFase1.Services.Interfaces;

namespace TechChallengeFase1.Services
{
    public class ContatoService : IContatoService
    {
        private readonly ContatoContext _context;
        public ContatoService(ContatoContext contatoContext)
        {
           _context = contatoContext;
        }
        

        public void AdicionarContato(Contatos contato)
        {
            contato.Id = Guid.NewGuid();
            _context.Contatos.Add(contato);
            _context.SaveChanges();
        }

        public void AtualizarContato(Contatos contato)
        {
            _context.Contatos.Update(contato);
            _context.SaveChanges();
        }

        public Contatos ConsultarContato(int DDD, int Numero)
        {
            return _context.Contatos.FirstOrDefault(x => x.DDD == DDD && x.Telefone == Numero );
        }

        public List<Contatos> ConsultarContatoPorDDD(int ddd)
        {
            return _context.Contatos.Where(x => x.DDD == ddd ).ToList();
        }

        public void ExcluirContato(int DDD, int Numero)
        {
            Contatos contatos = ConsultarContato(DDD, Numero);
            _context.Contatos.Remove(contatos);
            _context.SaveChanges();
        }
    }
}
