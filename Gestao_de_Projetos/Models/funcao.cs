using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
 
    public class Funcao
    {
        [Key]
        public int ID_funcao { get; set; }

        [Required]
        [Display(Name = "Nome Função")]
        public string Nome_Funcao { get; set; }

    }
}
