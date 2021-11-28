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

        [Display(Name ="Nome do projeto é obrigatorio")]
        public string Nome_projeto { get; set; }

        [Display(Name = "Campo obrigatorio")]
        public DateTime Data_inicio { get; set; }

        [Display(Name = "Campo obrigatorio")]
        public DateTime Data_fim { get; set; }
    }
}
