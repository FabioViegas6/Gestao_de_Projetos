using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class MembroTarefa
    {
        [ForeignKey("FK_IdTarefas")]
        public int IdTarefas { get; set; }
        public Tarefas Tarefas { get; set; }

        [ForeignKey("FK_ID_membro")]
        public int ID_membro { get; set; }
        public Membros Membros { get; set; }

        [Required]
        [Display(Name = "Data Prevista Inicio ")]
        [DataType(DataType.Date)]
        public DateTime DataPrevistaInicio { get; set; }

        [Required]
        [Display(Name = "Data Efetiva Inicio ")]
        [DataType(DataType.Date)]
        public DateTime DataEfetivaInicio { get; set; }

        [Required]
        [Display(Name = "Data  prevista Fim ")]
        [DataType(DataType.Date)]
        public DateTime DataPrevistaFim { get; set; }

        [Required]
        [Display(Name = "Data Efetiva Fim ")]
        [DataType(DataType.Date)]
        public DateTime DataEfetivaFim { get; set; }
    }
}
