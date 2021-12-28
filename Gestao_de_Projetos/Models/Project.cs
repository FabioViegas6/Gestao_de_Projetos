using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Project
    { 
        [Key]
        public int ID_projeto { get; set; }


        [Required]
        [Display(Name = "Nome do Projetos")]
        public string Nome_projeto { get; set; }


       
        [Display(Name = "Estado Projeto")]
        public string EstadoProjeto { get; set; }


        [Required]
        [Display(Name = "Data Prevista Inicio ")]
        [DataType(DataType.Date)]
        public DateTime DataPrevistaInicio { get; set; }

        [Required]
        [Display(Name = "Data Inicio ")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Required]
        [Display(Name = "Data  prevista Fim ")]
        [DataType(DataType.Date)]
        public DateTime DataPrevistaFim { get; set; }

        
        [Display(Name = "Data Efetiva Fim ")]
        [DataType(DataType.Date)]
        public DateTime? DataEfetivaFim { get; set; }




        [ForeignKey("FK_ClientesId")]
        public int ClientesId { get; set; }
        public Clientes Clientes { get; set; }
    }
}
