using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WashApi.Models
{
    [Table("cliente"), PrimaryKey(nameof(Id))]
    public class Cliente
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("telefone")]
        public required string Telefone { get; set; }

        [JsonIgnore]
        public ICollection<Agendamento>? Agendamentos { get; set; }
    }
}
