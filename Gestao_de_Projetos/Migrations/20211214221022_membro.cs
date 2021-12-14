using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Projetos.Migrations
{
    public partial class membro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Membros");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Membros",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NIF",
                table: "Membros",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Membros",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Membros",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Estado_Projeto",
                columns: table => new
                {
                    ID_Estado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado_Projeto", x => x.ID_Estado);
                });

            migrationBuilder.CreateTable(
                name: "MembroProjeto",
                columns: table => new
                {
                    ID_MembroProjeto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_projeto = table.Column<int>(nullable: false),
                    ProjetoID_projeto = table.Column<int>(nullable: true),
                    ID_membro = table.Column<int>(nullable: false),
                    MembrosID_membro = table.Column<int>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataPrevistaFim = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembroProjeto", x => x.ID_MembroProjeto);
                    table.ForeignKey(
                        name: "FK_MembroProjeto_Membros_MembrosID_membro",
                        column: x => x.MembrosID_membro,
                        principalTable: "Membros",
                        principalColumn: "ID_membro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembroProjeto_Projetos_ProjetoID_projeto",
                        column: x => x.ProjetoID_projeto,
                        principalTable: "Projetos",
                        principalColumn: "ID_projeto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MembroTarefa",
                columns: table => new
                {
                    ID_MembroTarefa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTarefas = table.Column<int>(nullable: false),
                    TarefasIdTarefas = table.Column<int>(nullable: true),
                    ID_membro = table.Column<int>(nullable: false),
                    MembrosID_membro = table.Column<int>(nullable: true),
                    DataPrevistaInicio = table.Column<DateTime>(nullable: false),
                    DataEfetivaInicio = table.Column<DateTime>(nullable: false),
                    DataPrevistaFim = table.Column<DateTime>(nullable: false),
                    DataEfetivaFim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembroTarefa", x => x.ID_MembroTarefa);
                    table.ForeignKey(
                        name: "FK_MembroTarefa_Membros_MembrosID_membro",
                        column: x => x.MembrosID_membro,
                        principalTable: "Membros",
                        principalColumn: "ID_membro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembroTarefa_Tarefas_TarefasIdTarefas",
                        column: x => x.TarefasIdTarefas,
                        principalTable: "Tarefas",
                        principalColumn: "IdTarefas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MembroProjeto_MembrosID_membro",
                table: "MembroProjeto",
                column: "MembrosID_membro");

            migrationBuilder.CreateIndex(
                name: "IX_MembroProjeto_ProjetoID_projeto",
                table: "MembroProjeto",
                column: "ProjetoID_projeto");

            migrationBuilder.CreateIndex(
                name: "IX_MembroTarefa_MembrosID_membro",
                table: "MembroTarefa",
                column: "MembrosID_membro");

            migrationBuilder.CreateIndex(
                name: "IX_MembroTarefa_TarefasIdTarefas",
                table: "MembroTarefa",
                column: "TarefasIdTarefas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estado_Projeto");

            migrationBuilder.DropTable(
                name: "MembroProjeto");

            migrationBuilder.DropTable(
                name: "MembroTarefa");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Membros");

            migrationBuilder.DropColumn(
                name: "NIF",
                table: "Membros");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Membros");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Membros");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Membros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
