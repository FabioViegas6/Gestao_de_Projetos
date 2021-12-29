using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Projetos.Migrations
{
    public partial class testev2 : Migration
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
                name: "Estado",
                columns: table => new
                {
                    EstadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEstado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoID);
                });

            migrationBuilder.CreateTable(
                name: "Funcao",
                columns: table => new
                {
                    FuncaoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Funcao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcao", x => x.FuncaoID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_projeto = table.Column<string>(nullable: false),
                    DataPrevistaInicio = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataPrevistaFim = table.Column<DateTime>(nullable: false),
                    DataEfetivaFim = table.Column<DateTime>(nullable: true),
                    ClientesId = table.Column<int>(nullable: false),
                    EstadoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Project_Clientes_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "Clientes",
                        principalColumn: "ClientesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Estado_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "Estado",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membros",
                columns: table => new
                {
                    MembrosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_membro = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(maxLength: 20, nullable: true),
                    NIF = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    FuncaoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membros", x => x.MembrosID);
                    table.ForeignKey(
                        name: "FK_Membros_Funcao_FuncaoID",
                        column: x => x.FuncaoID,
                        principalTable: "Funcao",
                        principalColumn: "FuncaoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    TarefasID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Tarefa = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    DataPrevistaInicio = table.Column<DateTime>(nullable: false),
                    DataEfetivaInicio = table.Column<DateTime>(nullable: false),
                    DataPrevistaFim = table.Column<DateTime>(nullable: false),
                    DataEfetivaFim = table.Column<DateTime>(nullable: true),
                    ProjectID = table.Column<int>(nullable: true),
                    MembrosID = table.Column<int>(nullable: false),
                    EstadoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.TarefasID);
                    table.ForeignKey(
                        name: "FK_Tarefas_Estado_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "Estado",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefas_Membros_MembrosID",
                        column: x => x.MembrosID,
                        principalTable: "Membros",
                        principalColumn: "MembrosID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefas_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Membros_FuncaoID",
                table: "Membros",
                column: "FuncaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientesId",
                table: "Project",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_EstadoID",
                table: "Project",
                column: "EstadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_EstadoID",
                table: "Tarefas",
                column: "EstadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_MembrosID",
                table: "Tarefas",
                column: "MembrosID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjectID",
                table: "Tarefas",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Membros");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Funcao");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
