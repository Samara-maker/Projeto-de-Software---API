using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WashApi.Models
{
    [Table("categoria_servico"), PrimaryKey(nameof(Id))]
    public class CategoriaServico
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        public ICollection<Servico>? Servicos { get; set; }
    }
}