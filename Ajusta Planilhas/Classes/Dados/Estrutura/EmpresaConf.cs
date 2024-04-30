using Gestao_Planilhas.Classes.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Gestao_Planilhas.Classes.Dados.Estrutura
{
    public class EmpresaConf : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(v => v.EmpresaId);
            builder.Property(v => v.EmpresaId).ValueGeneratedOnAdd();
            builder.Property(e => e.EmpresaLogo).HasColumnType("BLOB");
        }
    }
}
