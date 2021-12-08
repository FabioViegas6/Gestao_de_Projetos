﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Clientes
    {

        [Required(ErrorMessage = "Por favor, insira o seu Nome")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "O nome deve ter entre 4 e 20 caracteres")]
        [Display(Name = "Nome *", Prompt = "Nome")]
        public String Nome { get; set; }


        [Required(ErrorMessage = "Por favor, insira o seu Apelido")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "O apelido deve ter entre 4 e 20 caracteres")]
        [Display(Name = "Apelido *", Prompt = "Apelido")]
        public String Apelido { get; set; }


        [StringLength(20)]
        [Display(Name = "Contacto", Prompt = "Contacto")]
        public String Contacto { get; set; }

        [StringLength(10)]
        [Display(Name = "NIF", Prompt = "NIF")]
        public String NIF { get; set; }


        [Required(ErrorMessage = "Por favor, insira o seu Email")]
        [StringLength(50, MinimumLength = 12, ErrorMessage = "O seu Email deve ter entre 12 e 50 caracteres")]
        [EmailAddress(ErrorMessage = "Por favor, introduza o seu Email correto")]
        [Display(Name = "Email *", Prompt = "Email")]
        public String Email { get; set; }



    }
}
