using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Tarefas
    {
        [Key]
        public int idTarefas { get; set; }

        [Required]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Data  de inicio ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dataInicio { get; set; }


        [Required]
        [Display(Name = "Data Prevista Fim")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dataPrevistaFim { get; set; }


        [Display(Name = "Data de entrega")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dataFim { get; set; }





        //public int ID_membro { get; set; }
       // public Membros Membros { get; set; }



        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////
        /// </summary>
      //  public int ID_projeto { get; set; }
       // public Projetos Projetos{ get; set; }


    }
}
