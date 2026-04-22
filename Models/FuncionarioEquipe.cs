using System.ComponentModel.DataAnnotations.Schema;

namespace WashApi.Models
{
    [Table("funcionario_equipe")]
    public class FuncionarioEquipe
    {
        [Column("funcionario_id")]
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        [Column("equipe_id")]
        public int EquipeId { get; set; }
        public Equipe Equipe { get; set; }
    }
}