using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Contacto
    {

        private const string sms = "Introduza um email valido !";

        public int contactoID { get; set; }


        [Required(ErrorMessage = "Insira seu Nome!")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "insira um nome entre 4 a 20 caracteres!")]
        [Display(Name = " Nome", Prompt = " ")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Insira seu Sobrenome!")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "insira um sobrenome entre 4 a 20 caracteres!")]
        [Display(Name = " Sobrenome", Prompt = " ")]
        public string sobrenome { get; set; }

        public string email { get; set; }

        public string mensagem { get; set; }
        public string assunto { get; set; }

        public bool verificado { get; set; }

        public string resposta { get; set; }

    }
}
