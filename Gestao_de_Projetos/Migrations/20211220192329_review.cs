using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Projetos.Migrations
{
    public partial class review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClientesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Apelido = table.Column<string>(maxLength: 20, nullable: false),
                    Contacto = table.Column<string>(maxLength: 20, nullable: true),
                    NIF = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClientesId);
                });

            migrationBuilder.CreateTable(
                name: "Funcao",
                columns: table => new
                {
                    ID_funcao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Funcao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcao", x => x.ID_funcao);
                });

            migrationBuilder.CreateTable(
                name: "Membros",
                columns: table => new
                {
                    ID_membro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_funcao = table.Column<int>(nullable: false),
                    FuncaoID_funcao = table.Column<int>(nullable: true),
                    Nome_membro = table.Column<string>(nullable: false),
                    Sobrenome = table.Column<string>(nullable: false),
                    Telefone = table.Column<int>(nullable: false),
                    NIF = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membros", x => x.ID_membro);
                    table.ForeignKey(
                        name: "FK_Membros_Funcao_FuncaoID_funcao",
                        column: x => x.FuncaoID_funcao,
                        principalTable: "Funcao",
                        principalColumn: "ID_funcao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    IdTarefas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Tarefa = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    DataPrevistaInicio = table.Column<DateTime>(nullable: false),
                    DataPrevistaFim = table.Column<DateTime>(nullable: false),
                    ID_membro = table.Column<int>(nullable: false),
                    MembrosID_membro = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.IdTarefas);
                    table.ForeignKey(
                        name: "FK_Tarefas_Membros_MembrosID_membro",
                        column: x => x.MembrosID_membro,
                        principalTable: "Membros",
                        principalColumn: "ID_membro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Membros_FuncaoID_funcao",
                table: "Membros",
                column: "FuncaoID_funcao");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_MembrosID_membro",
                table: "Tarefas",
                column: "MembrosID_membro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Membros");

            migrationBuilder.DropTable(
                name: "Funcao");
        }
    }
}
