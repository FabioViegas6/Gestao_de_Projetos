using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Projetos
    {
        [Key]
        public int ID_projeto { get; set; }

        [Required]
        [Display(Name ="Nome do Projeto")]
        public string Nome_projeto { get; set; }

        [Required]
        [Display(Name = "Data Inicio")]
        public DateTime Data_inicio { get; set; }

        [Required]
        [Display(Name = "Data Fim")]
        public DateTime Data_fim { get; set; }


        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////// Para mexer 
        /// </summary>
       // public ICollection<Tarefas> Tarefas { get; set; }
    }
}
