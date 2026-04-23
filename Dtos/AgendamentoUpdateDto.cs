using System.ComponentModel.DataAnnotations;

namespace WashApi.Dtos
{
    public class AgendamentoUpdateDto
    {
        [Required(ErrorMessage = "O cliente é obrigatório")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "A data é obrigatória")]
        public DateOnly Data { get; set; }

        [Required(ErrorMessage = "O horário de início é obrigatório")]
        public TimeOnly HorarioInicio { get; set; }

        [Required(ErrorMessage = "O horário de fim é obrigatório")]
        public TimeOnly HorarioFim { get; set; }

        public string? Observacao { get; set; }

        [Required(ErrorMessage = "O status é obrigatório")]
        public required string Status { get; set; }

        public int? FuncionarioId { get; set; }

        public int? EquipeId { get; set; }

        [Required(ErrorMessage = "Informe ao menos um serviço")]
        public List<int> ServicosIds { get; set; } = new();
    }
}
