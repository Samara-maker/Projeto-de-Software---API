using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WashApi.Models
{
    [Table("servico"), PrimaryKey(nameof(Id))]
    public class Servico
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("valor")]
        public decimal Valor { get; set; }

        [Column("categoria_id")]
        public int CategoriaId { get; set; }
        public CategoriaServico Categoria { get; set; }

        public ICollection<AgendamentoServico>? AgendamentoServicos { get; set; }
    }
}