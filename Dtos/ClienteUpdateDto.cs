using System.ComponentModel.DataAnnotations;

namespace WashApi.Dtos
{
    public class ClienteUpdateDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        public required string Telefone { get; set; }
    }
}
