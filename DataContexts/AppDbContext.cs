using Microsoft.EntityFrameworkCore;
using WashApi.Models;

namespace WashApi.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }

        // Adicionar os demais DbSets conforme os módulos forem criados:
        // public DbSet<Funcionario> Funcionarios { get; set; }
        // public DbSet<Equipe> Equipes { get; set; }
        // public DbSet<CategoriaServico> CategoriasServico { get; set; }
        // public DbSet<Servico> Servicos { get; set; }
        // public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
