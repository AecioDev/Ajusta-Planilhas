using Gestao_Planilhas.Classes.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Gestao_Planilhas.Classes.Dados.Estrutura
{
    public class SYSConf : IEntityTypeConfiguration<SYS0000>
    {
        public void Configure(EntityTypeBuilder<SYS0000> builder)
        {
            builder.HasKey(v => v.SysId);
            builder.Property(v => v.SysId).ValueGeneratedOnAdd();
        }
    }
}
