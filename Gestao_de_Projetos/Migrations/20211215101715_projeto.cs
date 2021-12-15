using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Projetos.Migrations
{
    public partial class projeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_fim",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Data_inicio",
                table: "Projetos");

            migrationBuilder.AddColumn<int>(
                name: "ClientesId",
                table: "Projetos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estado_ProjetosID_Estado",
                table: "Projetos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_Estado",
                table: "Projetos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_ClientesId",
                table: "Projetos",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_Estado_ProjetosID_Estado",
                table: "Projetos",
                column: "Estado_ProjetosID_Estado");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Clientes_ClientesId",
                table: "Projetos",
                column: "ClientesId",
                principalTable: "Clientes",
                principalColumn: "ClientesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Estado_Projeto_Estado_ProjetosID_Estado",
                table: "Projetos",
                column: "Estado_ProjetosID_Estado",
                principalTable: "Estado_Projeto",
                principalColumn: "ID_Estado",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Clientes_ClientesId",
                table: "Projetos");

            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Estado_Projeto_Estado_ProjetosID_Estado",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_ClientesId",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_Estado_ProjetosID_Estado",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "ClientesId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Estado_ProjetosID_Estado",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "ID_Estado",
                table: "Projetos");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_fim",
                table: "Projetos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_inicio",
                table: "Projetos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
