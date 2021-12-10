using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Tarefas
    {
        [Key]
        public int IdTarefas { get; set; }


        [ForeignKey("FK_ID_projeto")]
        public int ID_projeto { get; set; }
        public Projetos Projetos { get; set; }



        [Required]
        [Display(Name = "Nome Tarefa")]
        public string Nome_Tarefa { get; set; }

        [Required]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Data  prevista de inicio ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataPrevistaInicio { get; set; }


        [Required]
        [Display(Name = "Data Prevista Fim")]
       [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataPrevistaFim { get; set; }



        public int ID_membro { get; set; }
        public Membros Membros { get; set; }


      


    }
}
