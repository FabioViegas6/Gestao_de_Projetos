﻿// <auto-generated />
using System;
using Gestao_de_Projetos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gestao_de_Projetos.Migrations
{
    [DbContext(typeof(Gestao_de_ProjetosContext))]
    partial class Gestao_de_ProjetosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gestao_de_Projetos.Models.Clientes", b =>
                {
                    b.Property<int>("ClientesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Contacto")
                        .HasColumnType("int")
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NIF")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ClientesId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.Estado_Projeto", b =>
                {
                    b.Property<int>("ID_Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Estado");

                    b.ToTable("Estado_Projeto");
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.Funcao", b =>
                {
                    b.Property<int>("ID_funcao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome_Funcao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_funcao");

                    b.ToTable("Funcao");
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.MembroProjeto", b =>
                {
                    b.Property<int>("ID_MembroProjeto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaFim")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_membro")
                        .HasColumnType("int");

                    b.Property<int>("ID_projeto")
                        .HasColumnType("int");

                    b.Property<int?>("MembrosID_membro")
                        .HasColumnType("int");

                    b.Property<int?>("ProjetoID_projeto")
                        .HasColumnType("int");

                    b.HasKey("ID_MembroProjeto");

                    b.HasIndex("MembrosID_membro");

                    b.HasIndex("ProjetoID_projeto");

                    b.ToTable("MembroProjeto");
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.MembroTarefa", b =>
                {
                    b.Property<int>("ID_MembroTarefa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataEfetivaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEfetivaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_membro")
                        .HasColumnType("int");

                    b.Property<int>("IdTarefas")
                        .HasColumnType("int");

                    b.Property<int?>("MembrosID_membro")
                        .HasColumnType("int");

                    b.Property<int?>("TarefasIdTarefas")
                        .HasColumnType("int");

                    b.HasKey("ID_MembroTarefa");

                    b.HasIndex("MembrosID_membro");

                    b.HasIndex("TarefasIdTarefas");

                    b.ToTable("MembroTarefa");
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.Membros", b =>
                {
                    b.Property<int>("ID_membro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NIF")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Nome_membro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.HasKey("ID_membro");

                    b.ToTable("Membros");
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.Projetos", b =>
                {
                    b.Property<int>("ID_projeto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientesId")
                        .HasColumnType("int");

                    b.Property<int?>("Estado_ProjetosID_Estado")
                        .HasColumnType("int");

                    b.Property<int>("ID_Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nome_projeto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_projeto");

                    b.HasIndex("ClientesId");

                    b.HasIndex("Estado_ProjetosID_Estado");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.Tarefas", b =>
                {
                    b.Property<int>("IdTarefas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataPrevistaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_membro")
                        .HasColumnType("int");

                    b.Property<int>("ID_projeto")
                        .HasColumnType("int");

                    b.Property<int?>("MembrosID_membro")
                        .HasColumnType("int");

                    b.Property<string>("Nome_Tarefa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjetosID_projeto")
                        .HasColumnType("int");

                    b.HasKey("IdTarefas");

                    b.HasIndex("MembrosID_membro");

                    b.HasIndex("ProjetosID_projeto");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.MembroProjeto", b =>
                {
                    b.HasOne("Gestao_de_Projetos.Models.Membros", "Membros")
                        .WithMany()
                        .HasForeignKey("MembrosID_membro");

                    b.HasOne("Gestao_de_Projetos.Models.Projetos", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoID_projeto");
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.MembroTarefa", b =>
                {
                    b.HasOne("Gestao_de_Projetos.Models.Membros", "Membros")
                        .WithMany()
                        .HasForeignKey("MembrosID_membro");

                    b.HasOne("Gestao_de_Projetos.Models.Tarefas", "Tarefas")
                        .WithMany()
                        .HasForeignKey("TarefasIdTarefas");
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.Projetos", b =>
                {
                    b.HasOne("Gestao_de_Projetos.Models.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gestao_de_Projetos.Models.Estado_Projeto", "Estado_Projetos")
                        .WithMany()
                        .HasForeignKey("Estado_ProjetosID_Estado");
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.Tarefas", b =>
                {
                    b.HasOne("Gestao_de_Projetos.Models.Membros", "Membros")
                        .WithMany("Tarefas")
                        .HasForeignKey("MembrosID_membro");

                    b.HasOne("Gestao_de_Projetos.Models.Projetos", "Projetos")
                        .WithMany("Tarefas")
                        .HasForeignKey("ProjetosID_projeto");
                });
#pragma warning restore 612, 618
        }
    }
}
