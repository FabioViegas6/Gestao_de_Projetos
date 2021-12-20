using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Projetos.Migrations
{
    public partial class review1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ID_projeto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_projeto = table.Column<string>(nullable: false),
                    EstadoProjeto = table.Column<string>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataPrevistaFim = table.Column<DateTime>(nullable: false),
                    DataEfetivaFim = table.Column<DateTime>(nullable: false),
                    ClientesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID_projeto);
                    table.ForeignKey(
                        name: "FK_Project_Clientes_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "Clientes",
                        principalColumn: "ClientesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientesId",
                table: "Project",
                column: "ClientesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
