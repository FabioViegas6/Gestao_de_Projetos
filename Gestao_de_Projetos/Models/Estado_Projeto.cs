﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Estado_Projeto
    {
        [Key]
        public int ID_Estado { get; set; }

        [Required]
        [Display(Name = "Nome Estado")]
        public string Nome { get; set; }
    }
}