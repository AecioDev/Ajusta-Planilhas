using Gestao_Planilhas.Classes.Dados.Estrutura;
using Gestao_Planilhas.Classes.Entidades;
using Gestao_Planilhas.Classes.Processamento;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Gestao_Planilhas.Classes.Dados
{
    public class GPContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Inicialize o SQLitePCL
            Batteries.Init();

            optionsBuilder.UseSqlite(Utilitarios.Busca_Conexao());


        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<SYS0000> SYS0000 { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaConf());
            modelBuilder.ApplyConfiguration(new UsuarioConf());
            modelBuilder.ApplyConfiguration(new SYSConf());
        }
    }
}
