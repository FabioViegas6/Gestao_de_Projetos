using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Projetos.Migrations
{
    public partial class membro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuncaoID_funcao",
                table: "Membros",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_funcao",
                table: "Membros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Membros_FuncaoID_funcao",
                table: "Membros",
                column: "FuncaoID_funcao");

            migrationBuilder.AddForeignKey(
                name: "FK_Membros_Funcao_FuncaoID_funcao",
                table: "Membros",
                column: "FuncaoID_funcao",
                principalTable: "Funcao",
                principalColumn: "ID_funcao",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membros_Funcao_FuncaoID_funcao",
                table: "Membros");

            migrationBuilder.DropIndex(
                name: "IX_Membros_FuncaoID_funcao",
                table: "Membros");

            migrationBuilder.DropColumn(
                name: "FuncaoID_funcao",
                table: "Membros");

            migrationBuilder.DropColumn(
                name: "ID_funcao",
                table: "Membros");
        }
    }
}
