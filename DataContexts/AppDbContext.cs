using Microsoft.EntityFrameworkCore;
using WashApi.Models;

namespace WashApi.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        // 🔥 CORREÇÃO DOS ERROS
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<CategoriaServico> CategoriasServico { get; set; }

        // (se seu projeto tiver esses também)
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<AgendamentoServico> AgendamentosServicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendamentoServico>()
                .HasKey(x => new { x.AgendamentoId, x.ServicoId });
        }
    }
}
