using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Estado_Projeto
    {

        [Key]
        public int IdEstado { get; set; }

        [Required]
        [Display(Name = "Estado Projeto")]
        public string Projeto_Estado { get; set; }
    }
}
