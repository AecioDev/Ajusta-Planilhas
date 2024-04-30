using Gestao_Planilhas.Classes.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao_Planilhas.Classes.Dados.Estrutura
{
    public class UsuarioConf : IEntityTypeConfiguration<Usuario>
    {        
        public void Configure(EntityTypeBuilder<Usuario> builder) 
        {
            builder.HasKey(v => v.UserId);
            builder.Property(v => v.UserId).ValueGeneratedOnAdd();
            builder.Property(v => v.UserStatus).HasMaxLength(1);
            builder.Property(v => v.UserNome).HasMaxLength(150);
            builder.Property(v => v.UserEmail).HasMaxLength(150);
            builder.Property(v => v.UserSenha).HasMaxLength(64);
            builder.Property(v => v.UserPerfil).HasMaxLength(256);
            builder.Property(v => v.UserFlag).HasMaxLength(64);
        }
    }
}
