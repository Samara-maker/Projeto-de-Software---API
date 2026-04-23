using System.ComponentModel.DataAnnotations;

namespace WashApi.Dtos
{
    public class EquipeDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public required string Nome { get; set; }
    }
}
