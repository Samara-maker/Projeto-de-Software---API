using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WashApi.Models
{
    [Table("funcionario"), PrimaryKey(nameof(Id))]
    public class Funcionario
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("cargo")]
        public string Cargo { get; set; }

        public ICollection<FuncionarioEquipe>? FuncionarioEquipes { get; set; }
    }
}