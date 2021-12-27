using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public String Nome_membro { get; set; }

        

        [StringLength(20)]
        [Display(Name = "Telefone", Prompt = "Telefone")]
        public String Telefone { get; set; }

        [StringLength(10)]
        [Display(Name = "NIF", Prompt = "NIF")]
        public String NIF { get; set; }


        [Required(ErrorMessage = "Por favor, insira o seu Email")]
        [StringLength(50, MinimumLength = 12, ErrorMessage = "O seu Email deve ter entre 12 e 50 caracteres")]
        [EmailAddress(ErrorMessage = "Por favor, introduza o seu Email correto")]
        [Display(Name = "Email *", Prompt = "Email")]
        public String Email { get; set; }

        [Required(ErrorMessage = "A sua Password deve ter entre 8 e 20 caracteres")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "A sua Password deve ter entre 8 e 20 caracteres")]
        [Display(Name = "Password *", Prompt = "Password")]
        public String Password { get; set; }


        public ICollection <Tarefas> Tarefas { get; set; }




        [ForeignKey("FK_ID_funcao")]
        public int ID_funcao { get; set; }
        public Funcao Funcao { get; set; }

    }
}
