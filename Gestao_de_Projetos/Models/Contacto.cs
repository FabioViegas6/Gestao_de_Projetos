using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Contacto
    {

       // private const string sms = "Introduza um email valido !";

        public int contactoID { get; set; }


        [Required(ErrorMessage = "Insira seu Nome!")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "insira um nome entre 4 a 20 caracteres!")]
        [Display(Name = " Nome", Prompt = " ")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Por favor, insira o seu Sobrenome")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "O Sobrenome deve ter entre 4 e 20 caracteres")]
        [Display(Name = "Sobrenome *", Prompt = "Apelido")]
        public String Sobrenome { get; set; }




        [Required(ErrorMessage = "Introduza um email valido ! ")]
         [EmailAddress(ErrorMessage = "Introduza um email valido !")]
        [Display(Name = "Email", Prompt = " ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por Favor, insira a sua mensagem!")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "insira uma mensagem entre 10 a 1000 caracteres!")]
        [Display(Name = " Mensagem", Prompt = " ")]
        public string Mensagem { get; set; }



        [Required(ErrorMessage = "Por Favor, insira o seu assunto!")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "insira um assunto entre 10 a 1000 caracteres!")]
        [Display(Name = " Assunto", Prompt = " ")]
        public string Assunto { get; set; }

        

        public bool Verificado { get; set; }

        [Display(Name = " Resposta ", Prompt = " ")]
        public string Resposta { get; set; }

    }
}
