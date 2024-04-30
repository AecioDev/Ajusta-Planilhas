using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao_Planilhas.Migrations
{
    /// <inheritdoc />
    public partial class TabelaEmpresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpresaNome = table.Column<string>(type: "TEXT", nullable: false),
                    PastaPadrao = table.Column<string>(type: "TEXT", nullable: false),
                    EmpresaLogo = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "SYS0000",
                columns: table => new
                {
                    SysId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VersaoSistema = table.Column<int>(type: "INTEGER", nullable: false),
                    ScriptBD = table.Column<int>(type: "INTEGER", nullable: false),
                    CodRepPass = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS0000", x => x.SysId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserStatus = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false),
                    UserNome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    UserEmail = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    UserSenha = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    UserPerfil = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    UserFlag = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "SYS0000");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
