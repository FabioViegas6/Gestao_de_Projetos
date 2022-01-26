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
            PopulateEstado(bd);
            PopulateClientes(bd);
            PopulateProject(bd);
            PopulateFuncao(bd);
            PopulateMembro(bd);
            PopulateTarefas(bd);


        }

        private static void PopulateProject(Gestao_de_ProjetosContext bd)
        {
            if (bd.Project.Any()) return;
            bd.Project.AddRange(
                new Project
                {
                    Nome_projeto = "Remodelação exterior",
                    DataInicio = DateTime.Parse("12/12/2021"),
                    DataPrevistaInicio = DateTime.Parse("13/12/2021"),
                    ClientesId = 2,
                    EstadoID = 2,
                    DataPrevistaFim = DateTime.Parse("26/12/2021")
                },

                new Project
                {
                    Nome_projeto = "Contrução de apartementos",
                    DataInicio = DateTime.Parse("12/12/2021"),
                    DataPrevistaInicio = DateTime.Parse("13/12/2021"),
                    ClientesId = 2,
                    EstadoID = 2,
                    DataPrevistaFim = DateTime.Parse("26/12/2022")
                },



                new Project
                {
                    Nome_projeto = "Troca Azuliejos sala",
                    DataInicio = DateTime.Parse("14/01/2022"),
                    DataPrevistaInicio = DateTime.Parse("13/12/2021"),
                    ClientesId = 5,
                    EstadoID = 1,
                    DataPrevistaFim = DateTime.Parse("16/12/2022")
                },

                new Project
                {
                    Nome_projeto = "Pintar paredes",
                    DataInicio = DateTime.Parse("12/12/2021"),
                    DataPrevistaInicio = DateTime.Parse("07/12/2021"),
                    ClientesId = 7,
                    EstadoID = 2,
                    DataPrevistaFim = DateTime.Parse("03/12/2022")
                },

                 new Project
                 {
                     Nome_projeto = "Remodelação Interior",
                     DataInicio = DateTime.Parse("12/12/2021"),
                     DataPrevistaInicio = DateTime.Parse("13/12/2021"),
                     ClientesId = 3,
                     EstadoID = 3,
                     DataPrevistaFim = DateTime.Parse("27/12/2021")
                 },
                  new Project
                  {
                      Nome_projeto = "Construção do Jardim",
                      DataInicio = DateTime.Parse("12/12/2021"),
                      DataPrevistaInicio = DateTime.Parse("13/12/2021"),
                      ClientesId = 2,
                      EstadoID = 2,
                      DataPrevistaFim = DateTime.Parse("30/12/2021")
                  },

                  new Project
                  {
                      Nome_projeto = "Remodelar a sala",
                      DataInicio = DateTime.Parse("15/12/2020"),
                      DataPrevistaInicio = DateTime.Parse("13/12/2021"),
                      ClientesId = 3,
                      EstadoID = 1,
                      DataPrevistaFim = DateTime.Parse("30/12/2021")
                  },

                   new Project
                   {
                       Nome_projeto = "Remodelação exterior",
                       DataInicio = DateTime.Parse("12/12/2021"),
                       DataPrevistaInicio = DateTime.Parse("13/12/2021"),
                       ClientesId = 3,
                       EstadoID = 1,
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
                    Email = "jose@gmail.com",
                    Contacto = "931156455"
                    

                },
                new Clientes
                {
                    Nome = "Augusto",
                    Email = "jose@gmail.com",
                    Contacto = "931156455"


                },
                   new Clientes
                   {
                       Nome = "Maria",
                       Email = "ma@gmail.com",
                       Contacto = "931196481"

                   },

                     new Clientes
                     {
                         Nome = "Fernando",
                         Email = "nando@gmail.com",
                         Contacto = "921184481"

                     },

                     new Clientes
                     {
                         Nome = "Selmyh",
                         Email = "selmy@gmail.com",
                         Contacto = "996184481"

                     },
                     new Clientes
                     {
                         Nome = "Pedro",
                         Email = "jose@gmail.com",
                         Contacto = "931156455"


                     },
                     new Clientes
                     {
                         Nome = "Joaquim",
                         Email = "jose@gmail.com",
                         Contacto = "931156455"


                     },


                     new Clientes
                     {
                         Nome = "Antonio",
                         Email = "antonio@gmail.com",
                         Contacto = "963184481"

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
                   Nome_membro = "Yara",
                   Email = "Yara@gmail.com",
                   Telefone = "931184412",
                    FuncaoID = 6

                },

                 new Membros
                 {
                     Nome_membro = "Lua",
                     Email = "Yara@gmail.com",
                     Telefone = "931184412",
                     FuncaoID = 6

                 },
                  new Membros
                  {
                      Nome_membro = "Marcela",
                      Email = "Yara@gmail.com",
                      Telefone = "931184412",
                      FuncaoID = 6

                  },

                new Membros
                {
                    Nome_membro = "Suraya",
                    Email = "Yara@gmail.com",
                    Telefone = "931184412",
                    FuncaoID = 6

                },

                new Membros
                {
                     Nome_membro = "mira ",
                     Email = "mira@gmail.com",
                     Telefone = "931184434",
                    //
                    FuncaoID = 4
                 },
                  new Membros
                  {
                      Nome_membro = "Kaio ",
                      Email = "Selff@gmail.com",
                      Telefone = "931184456",
                      FuncaoID = 5
                  },
                   new Membros
                   {
                       Nome_membro = "Yahia",
                       Email = "Yara@gmail.com",
                       Telefone = "931184412",
                       FuncaoID = 6

                   },
                    new Membros
                    {
                        Nome_membro = "Muhammad",
                        Email = "Yara@gmail.com",
                        Telefone = "931184412",
                        FuncaoID = 6

                    },


                    new Membros
                    {
                        Nome_membro = "Ibrahim",
                        Email = "Yara@gmail.com",
                        Telefone = "931184412",
                        FuncaoID = 6

                    },
                   new Membros
                   {
                       Nome_membro = "Selmira ",
                       Email = "selmira@gmail.com",
                       Telefone = "931184478",
                       FuncaoID = 5
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
                    NomeFuncao = "Gestor"
                 },
                 new Funcao
                 {
                     NomeFuncao = "Decorador"
                 },
                 new Funcao
                 {
                     NomeFuncao = "Pedreiro"
                 },
                 new Funcao
                 {
                     NomeFuncao = "canalizador"
                 },
                 new Funcao
                 {
                     NomeFuncao = "Electricista"
                 },
                  new Funcao
                 {
                     NomeFuncao = "Engenheiro Civil"
                 },
                   new Funcao
                 {
                     NomeFuncao = "Carpinteiro"
                 },
                    new Funcao
                 {
                     NomeFuncao = "Pintor"
                 },
                    new Funcao
                 {
                     NomeFuncao = "Arquitecto"
                 }
            
                 );

            bd.SaveChanges();
        }

        private static void PopulateEstado(Gestao_de_ProjetosContext bd)
        {
            if (bd.Estado.Any()) return;
            bd.Estado.AddRange(
                new Estado
                {
                    NomeEstado = "Atrasado"
                },
                 new Estado
                 {
                     NomeEstado = "Em progresso"
                 },
                 new Estado
                 {
                     NomeEstado = "Concluido"
                 }
   
                 );

            bd.SaveChanges();
        }

        private static void PopulateTarefas(Gestao_de_ProjetosContext bd)

        {
            if (bd.Tarefas.Any()) return;
            bd.Tarefas.AddRange(
            new Tarefas

            {
                Nome_Tarefa = "Contrucao do chão",
                Descricao = "O chao da sala",
                DataPrevistaInicio = DateTime.Parse("12/12/2021"),
                DataEfetivaInicio = DateTime.Parse("12/12/2021"),
                DataPrevistaFim = DateTime.Parse("30/12/2021"),
                DataEfetivaFim = DateTime.Parse("31/12/2021"),
                MembrosID = 3,
                ProjectID = 2,
                EstadoID = 1
            },

             new Tarefas

             {
                 Nome_Tarefa = "Contrucao do chão",
                 Descricao = "O chao da cozinha",
                 DataPrevistaInicio = DateTime.Parse("01/01/2022"),
                 DataEfetivaInicio = DateTime.Parse("02/01/2022"),
                 DataPrevistaFim = DateTime.Parse("15/01/2022"),
                 DataEfetivaFim = DateTime.Parse("14/01/2022"),
                 MembrosID = 4,
                 ProjectID = 2,
                 EstadoID = 2
             },

              new Tarefas

              {
                  Nome_Tarefa = "Troca de banheira",
                  Descricao = "Trocar por uma banheira redonda",
                  DataPrevistaInicio = DateTime.Parse("01/01/2022"),
                  DataEfetivaInicio = DateTime.Parse("02/01/2022"),
                  DataPrevistaFim = DateTime.Parse("15/01/2022"),
                  DataEfetivaFim = DateTime.Parse("14/01/2022"),
                  MembrosID = 4,
                  ProjectID = 5,
                  EstadoID = 2
              },

               new Tarefas

               {
                   Nome_Tarefa = "Pintar parede da sala",
                   Descricao = "Mudar a cor atual para cor branca",
                   DataPrevistaInicio = DateTime.Parse("01/01/2022"),
                   DataEfetivaInicio = DateTime.Parse("02/01/2022"),
                   DataPrevistaFim = DateTime.Parse("15/01/2022"),
                   DataEfetivaFim = DateTime.Parse("23/01/2022"),
                   MembrosID = 4,
                   ProjectID = 2,
                   EstadoID = 3
               },

                new Tarefas

                {
                    Nome_Tarefa = "Partir o chão do corredor",
                    Descricao = "Chão feito de madeira",
                    DataPrevistaInicio = DateTime.Parse("01/01/2022"),
                    DataEfetivaInicio = DateTime.Parse("02/01/2022"),
                    DataPrevistaFim = DateTime.Parse("15/01/2022"),
                    DataEfetivaFim = DateTime.Parse("23/01/2022"),
                    MembrosID = 4,
                    ProjectID = 2,
                    EstadoID = 3
                },

              new Tarefas

              {
                  Nome_Tarefa = "Contrucao do chão",
                  Descricao = "O chao do quarto",
                  DataPrevistaInicio = DateTime.Parse("01/01/2022"),
                  DataEfetivaInicio = DateTime.Parse("02/01/2022"),
                  DataPrevistaFim = DateTime.Parse("15/01/2022"),
                  DataEfetivaFim = DateTime.Parse("14/01/2022"),
                  MembrosID = 1,
                  ProjectID = 3,
                  EstadoID = 1
              },

               new Tarefas

               {
                   Nome_Tarefa = "Contrucao do chão",
                   Descricao = "O chao da sala",
                   DataPrevistaInicio = DateTime.Parse("01/01/2022"),
                   DataEfetivaInicio = DateTime.Parse("02/01/2022"),
                   DataPrevistaFim = DateTime.Parse("15/01/2022"),
                   DataEfetivaFim = DateTime.Parse("14/01/2022"),
                   MembrosID = 1,
                   ProjectID = 2,
                   EstadoID = 2
               }


            );
            bd.SaveChanges();


        }

    }
}