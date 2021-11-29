using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Projetos.Migrations
{
    public partial class Membros_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membros",
                columns: table => new
                {
                    ID_membro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_membro = table.Column<string>(nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membros", x => x.ID_membro);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Membros");
        }
    }
}
