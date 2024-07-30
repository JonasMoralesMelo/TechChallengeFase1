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
        [RegularExpression(@"^\d{2}$", ErrorMessage = "O DDD deve ter exatamente 2 dígitos.")]
        public int DDD { get; set; }
        [Required]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "O telefone deve ter exatamente 9 dígitos.")]
        public int Telefone { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "E-mail ínválido, favor informar um e-mail válido")]
        public string Email { get; set; }

    }
}
