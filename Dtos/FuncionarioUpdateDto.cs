using System.ComponentModel.DataAnnotations;

namespace WashApi.Dtos
{
    public class FuncionarioUpdateDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O cargo é obrigatório")]
        public required string Cargo { get; set; }
    }
}
