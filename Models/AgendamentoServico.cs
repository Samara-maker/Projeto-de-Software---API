using System.ComponentModel.DataAnnotations.Schema;

namespace WashApi.Models
{
    public class AgendamentoServico
    {
        public int AgendamentoId { get; set; }
        public Agendamento Agendamento { get; set; }

        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}