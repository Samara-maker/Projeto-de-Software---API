using System.ComponentModel.DataAnnotations.Schema;

namespace WashApi.Models
{
    [Table("agendamento_servico")]
    public class AgendamentoServico
    {
        [Column("agendamento_id")]
        public int AgendamentoId { get; set; }
        public Agendamento Agendamento { get; set; }

        [Column("servico_id")]
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}