using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class MembroProjeto
    {
        [Key]
        public int ID_MembroProjeto { get; set; }

        [ForeignKey("FK_ID_projeto")]
        public int ID_projeto { get; set; }
        public Projetos Projeto { get; set; }

        [ForeignKey("FK_ID_membro")]
        public int ID_membro { get; set; }
        public Membros Membros { get; set; }

        [Required]
        [Display(Name = "Data Inicio ")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Required]
        [Display(Name = "Data  prevista Fim ")]
        [DataType(DataType.Date)]
        public DateTime DataPrevistaFim { get; set; }

        [Required]
        [Display(Name = "Data Fim ")]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }




    }
}
