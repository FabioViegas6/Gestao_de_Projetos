using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Clientes
    {

        [Key]
        public int ClientesId { get; set; }

        [Required(ErrorMessage = "Por favor, insira o seu Nome")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "O nome deve ter entre 4 e 20 caracteres")]
        [Display(Name = "Nome *", Prompt = "Nome")]
        public String Nome { get; set; }

   
        [StringLength(9)]
        [Display(Name = "Contacto", Prompt = "Contacto")]
        [Required(ErrorMessage = "Por favor insira o seu numero de telefone")]
        [RegularExpression(@"(9\d{8})", ErrorMessage = "Numero invalido.")]
        public String Contacto { get; set; }

      

        [Required(ErrorMessage = "Por favor, insira o seu Email")]
        [StringLength(50, MinimumLength = 12, ErrorMessage = "O seu Email deve ter entre 12 e 50 caracteres")]
        [EmailAddress(ErrorMessage = "Por favor, introduza o seu Email correto")]
        [Display(Name = "Email *", Prompt = "Email")]
        public String Email { get; set; }

        //[Required(ErrorMessage = "A sua Password deve ter entre 8 e 20 caracteres")]
        //[StringLength(20, MinimumLength = 8, ErrorMessage = "A sua Password deve ter entre 8 e 20 caracteres")]
        //[Display(Name = "Password *", Prompt = "Password")]
        //public String Password { get; set; }

    }
}
