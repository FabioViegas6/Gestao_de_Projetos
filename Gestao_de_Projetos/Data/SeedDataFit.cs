using Gestao_de_Projetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Data
{
    public class SeedDataDadosFIT
    {
        internal static void Populate(Gestao_de_ProjetosContext bd)
        {
            PopulateClientes(bd);
            PopulateProject(bd);
            PopulateMembro(bd);
            PopulateFuncao(bd);

        }

        private static void PopulateProject(Gestao_de_ProjetosContext bd)
        {
            if (bd.Project.Any()) return;
            bd.Project.AddRange(
                new Project
                {
                    Nome_projeto = "Remodelação exterior",
                    DataInicio = DateTime.Parse("12/12/2021"),
                    ClientesId = 2,
                    DataPrevistaFim = DateTime.Parse("26/12/2021")
                },

                 new Project
                 {
                     Nome_projeto = "Remodelação Interior",
                     DataInicio = DateTime.Parse("12/12/2021"),
                     ClientesId = 3,
                     DataPrevistaFim = DateTime.Parse("27/12/2021")
                 },
                  new Project
                  {
                      Nome_projeto = "Contrução do Jardim",
                      DataInicio = DateTime.Parse("12/12/2021"),
                      ClientesId = 2,
                      DataPrevistaFim = DateTime.Parse("30/12/2021")
                  },

                   new Project
                   {
                       Nome_projeto = "Remodelação exterior",
                       DataInicio = DateTime.Parse("12/12/2021"),
                       ClientesId = 3,
                       DataPrevistaFim = DateTime.Parse("30/12/2021")
                   }
                  );
            bd.SaveChanges();

        }

        private static void PopulateClientes(Gestao_de_ProjetosContext bd)
        {
            if (bd.Clientes.Any()) return;
            bd.Clientes.AddRange(
                new Clientes
                {
                    Nome = "José",
                    Email = "joseraf@gmail.com",
                    Contacto = "931184481",
                    NIF = "289761182",
                    Password = ""

                },

                   new Clientes
                   {
                       Nome = "José",
                       Email = "joseraf@gmail.com",
                       Contacto = "931184481",
                       NIF = "289761182",
                       Password = ""

                   },

                     new Clientes
                     {
                         Nome = "José",
                         Email = "joseraf@gmail.com",
                         Contacto = "931184481",
                         NIF = "289761182",
                         Password =""

                     },


                     new Clientes
                     {
                         Nome = "José",
                         Email = "joseraf@gmail.com",
                         Contacto = "931184481",
                         NIF = "289761182",
                         Password = ""

                     }
                     );
            bd.SaveChanges();


        }

        private static void PopulateMembro(Gestao_de_ProjetosContext bd)
        {
            if (bd.Membros.Any()) return;
            bd.Membros.AddRange(
                new Membros
                {
                   Nome_membro = "Selmira",
                   Email = "self@gmail.com",
                   Telefone = "931184481",
                   NIF = "289761182",
                   Password = "",
                   ID_funcao = 1

                },

                new Membros
                {
                     Nome_membro = "mira ",
                     Email = "mira@gmail.com",
                     Telefone = "931184481",
                     NIF = "289761182",
                     Password = "",
                     //
                     ID_funcao = 2
                 },
                  new Membros
                  {
                      Nome_membro = "Sel ",
                      Email = "miraf@gmail.com",
                      Telefone = "931184481",
                      NIF = "289761182",
                      Password = "",
                      ID_funcao = 3
                  },

                   new Membros
                   {
                       Nome_membro = "Selmira ",
                       Email = "self@gmail.com",
                       Telefone = "931184481",
                       NIF = "289761182",
                       Password = "",
                       ID_funcao = 2
                   }
                 );

            bd.SaveChanges();
        }

        private static void PopulateFuncao(Gestao_de_ProjetosContext bd)
        {
            if (bd.Funcao.Any()) return;
            bd.Funcao.AddRange(
                new Funcao
                 {
                    Nome_Funcao = "Gestor"
                 },
                 new Funcao
                 {
                     Nome_Funcao = "Decorador"
                 },
                 new Funcao
                 {
                     Nome_Funcao = "Pedreiro"
                 },
                 new Funcao
                 {
                     Nome_Funcao = "canalizador"
                 },
                 new Funcao
                 {
                     Nome_Funcao = "Electricista"
                 },
                  new Funcao
                 {
                     Nome_Funcao = "Engenheiro Civil"
                 },
                   new Funcao
                 {
                     Nome_Funcao = "Carpinteiro"
                 },
                    new Funcao
                 {
                     Nome_Funcao = "Pintor"
                 },
                    new Funcao
                 {
                     Nome_Funcao = "Arquitecto"
                 }
            
                 );

            bd.SaveChanges();
        }
    }
}