using System.ComponentModel.DataAnnotations;

namespace TechChallengeFase1.Models.Entity
{
    public class Contatos
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

    }
}
