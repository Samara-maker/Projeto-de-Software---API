using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WashApi.Models
{
    [Table("equipe"), PrimaryKey(nameof(Id))]
    public class Equipe
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        public ICollection<FuncionarioEquipe>? FuncionarioEquipes { get; set; }
    }
}
