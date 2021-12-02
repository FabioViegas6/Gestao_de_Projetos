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
        [Display(Name = "Data inicio ")]
        public DateTime dataInicio { get; set; }

        [Required]
        [Display(Name = "Data fim")]
        public DateTime dataFim { get; set; }

        public int ID_membro { get; set; }
        public Membros Membros { get; set; }
    }
}
