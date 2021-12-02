using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Membros
    {
        [Key]
        public int ID_membro { get; set; }

        [Required]
        [Display(Name = "Nome do Membro")]
        public string Nome_membro { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Required]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }


        public ICollection <Tarefas> Tarefas { get; set; }
    }
}
