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
        public int TarefasID { get; set; }




        [Required]
        [Display(Name = "Nome Tarefa")]
        public string Nome_Tarefa { get; set; }

        [Required]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Data  prevista de inicio ")]
        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataPrevistaInicio { get; set; }

        [Required]
        [Display(Name = "Data  Efetiva inicio ")]
        [DataType(DataType.Date)]
        public DateTime DataEfetivaInicio { get; set; }


        [Required]
        [Display(Name = "Data Prevista Fim")]
        [DataType(DataType.Date)]
      //  [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataPrevistaFim { get; set; }


        
        [Display(Name = "Data  Efetiva Fim ")]
        [DataType(DataType.Date)]
        public DateTime? DataEfetivaFim { get; set; }


        [Display(Name = "Comentarios")]
        public String comentarios {get;set;}


     //[ForeignKey("FK_ProjectID")]
         public int? ProjectID { get; set; }
        public Project Project { get; set; }

        //[ForeignKey("FK_MembrosID")]
        public int MembrosID { get; set; }
        public Membros Membros { get; set; }

        //[ForeignKey("FK_estadoID")]
        public int EstadoID { get; set; }
        public Estado Estado { get; set; }






    }
}
