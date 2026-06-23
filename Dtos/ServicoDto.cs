using System.ComponentModel.DataAnnotations;

namespace WashApi.Dtos
{
    public class ServicoDto
    {
        [Required(ErrorMessage = "A descrição é obrigatória!")]
        public required string Descricao { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero!")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória!")]
        public int CategoriaId { get; set; }
    }
}
