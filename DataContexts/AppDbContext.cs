using Microsoft.EntityFrameworkCore;
using WashApi.Models;

namespace WashApi.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<FuncionarioEquipe> FuncionariosEquipe { get; set; }
        public DbSet<CategoriaServico> CategoriasServico { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<AgendamentoServico> AgendamentosServicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Chave composta para tabela de relacionamento FuncionarioEquipe
            modelBuilder.Entity<FuncionarioEquipe>()
                .HasKey(fe => new { fe.FuncionarioId, fe.EquipeId });

            // Chave composta para tabela de relacionamento AgendamentoServico
            modelBuilder.Entity<AgendamentoServico>()
                .HasKey(ags => new { ags.AgendamentoId, ags.ServicoId });
        }
    }
}