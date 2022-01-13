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
        public int membroProjeto { get; set; }

        [ForeignKey("FK_MembrosID")]
        public int MembrosID { get; set; }
        public Membros Membros { get; set; }

        [ForeignKey("FK_ProjectID")]
        public int ProjectID { get; set; }
        public Project Project { get; set; }


        [Required]
        [Display(Name = "Data Inicio ")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }


        [Display(Name = "Data Fim ")]
        [DataType(DataType.Date)]
        public DateTime? DataEfetivaFim { get; set; }


    }
}
