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

                    b.Property<string>("Contacto")
                        .HasColumnType("nvarchar(20)")
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

                    b.Property<int?>("FuncaoID_funcao")
                        .HasColumnType("int");

                    b.Property<int>("ID_funcao")
                        .HasColumnType("int");

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

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ID_membro");

                    b.HasIndex("FuncaoID_funcao");

                    b.ToTable("Membros");
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.Project", b =>
                {
                    b.Property<int>("ID_projeto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEfetivaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("EstadoProjeto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome_projeto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_projeto");

                    b.HasIndex("ClientesId");

                    b.ToTable("Project");
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

                    b.Property<int?>("MembrosID_membro")
                        .HasColumnType("int");

                    b.Property<string>("Nome_Tarefa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTarefas");

                    b.HasIndex("MembrosID_membro");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.Membros", b =>
                {
                    b.HasOne("Gestao_de_Projetos.Models.Funcao", "Funcao")
                        .WithMany()
                        .HasForeignKey("FuncaoID_funcao");
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.Project", b =>
                {
                    b.HasOne("Gestao_de_Projetos.Models.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gestao_de_Projetos.Models.Tarefas", b =>
                {
                    b.HasOne("Gestao_de_Projetos.Models.Membros", "Membros")
                        .WithMany("Tarefas")
                        .HasForeignKey("MembrosID_membro");
                });
#pragma warning restore 612, 618
        }
    }
}
