﻿// <auto-generated />
using System;
using Gestao_de_Projetos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gestao_de_Projetos.Migrations
{
    [DbContext(typeof(Gestao_de_ProjetosContext))]
    [Migration("20211220192329_review")]
    partial class review
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.HasKey("ID_membro");

                    b.HasIndex("FuncaoID_funcao");

                    b.ToTable("Membros");
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
