using System.ComponentModel.DataAnnotations;
using TechChallengeFase1.Models.Entity;

namespace TechChallengeFase1.Models.DTO
{
    public class ContatosDTO
    {
        public Guid Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Nome inválido, informe no mínimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Nome excedeu o tamanho permitido")]
        public string Nome { get; set; }
        [Required]
        public int DDD { get; set; }
        [Required]
        public int Telefone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Regiao { get; set; }

        public ContatosDTO(Contatos contatos, string regiao)
        {
            Id = contatos.Id;
            Nome = contatos.Nome;
            DDD = contatos.DDD;
            Telefone = contatos.Telefone;
            Email = contatos.Email;
            Regiao = regiao;
        }

    }
}

