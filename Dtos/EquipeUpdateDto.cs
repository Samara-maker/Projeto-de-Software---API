using System.ComponentModel.DataAnnotations;

namespace WashApi.Dtos
{
    public class EquipeUpdateDto
    {
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public required string Nome { get; set; }
    }
}
