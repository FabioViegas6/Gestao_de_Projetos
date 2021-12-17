using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestao_de_Projetos.Models;

namespace Gestao_de_Projetos.Data
{
    public class Gestao_de_ProjetosContext : DbContext
    {
        public Gestao_de_ProjetosContext(DbContextOptions<Gestao_de_ProjetosContext> options)
           : base(options)
        {
        }
        public DbSet<Gestao_de_Projetos.Models.Projetos> Projetos { get; set; }
        public DbSet<Gestao_de_Projetos.Models.Membros> Membros { get; set; }
        public DbSet<Gestao_de_Projetos.Models.Tarefas> Tarefas { get; set; }
        public DbSet<Gestao_de_Projetos.Models.Funcao> Funcao { get; set; }
        public DbSet<Gestao_de_Projetos.Models.Clientes> Clientes { get; set; }
        public DbSet<Gestao_de_Projetos.Models.EstadoProjeto> Estado_Projeto { get; set; }
        public DbSet<Gestao_de_Projetos.Models.MembroProjeto> MembroProjeto { get; set; }
        public DbSet<Gestao_de_Projetos.Models.MembroTarefa> MembroTarefa { get; set; }
    }
}
