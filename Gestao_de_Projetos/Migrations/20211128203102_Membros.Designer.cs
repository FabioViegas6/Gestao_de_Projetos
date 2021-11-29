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
    [Migration("20211128203102_Membros")]
    partial class Membros
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gestao_de_Projetos.Models.Projetos", b =>
                {
                    b.Property<int>("ID_projeto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_fim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_inicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome_projeto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_projeto");

                    b.ToTable("Projetos");
                });
#pragma warning restore 612, 618
        }
    }
}
