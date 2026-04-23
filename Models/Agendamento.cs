using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WashApi.Models
{
    [Table("agendamento"), PrimaryKey(nameof(Id))]
    public class Agendamento
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("cliente_id")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        [Column("data")]
        public DateTime Data { get; set; }

        [Column("horario_inicio")]
        public TimeSpan HorarioInicio { get; set; }

        [Column("horario_fim")]
        public TimeSpan HorarioFim { get; set; }

        [Column("observacao")]
        public string? Observacao { get; set; }

        [Column("status")]
        public string Status { get; set; } = null!;

        [Column("funcionario_id")]
        public int? FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }

        [Column("equipe_id")]
        public int? EquipeId { get; set; }
        public Equipe? Equipe { get; set; }

        public ICollection<AgendamentoServico>? AgendamentoServicos { get; set; }
    }
}