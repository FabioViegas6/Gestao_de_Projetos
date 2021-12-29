using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Estado
    {

        [Key]
        public int EstadoID { get; set; }

        [Required]
        [Display(Name = "Nome estado")]
        public string NomeEstado { get; set; }



        public ICollection<Project> Projects { get; set; }
        public ICollection<Tarefas> Tarefas { get; set; }
    }
}
