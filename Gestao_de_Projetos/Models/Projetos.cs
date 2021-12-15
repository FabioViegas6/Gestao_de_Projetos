using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Projetos
    {
        [Key]
        public int ID_projeto { get; set; }

        [ForeignKey("FK_ClientesId")]
        public int ClientesId { get; set; }
        public Clientes Clientes { get; set; }

        [Required]
        [Display(Name ="Nome do Projeto")]
        public string Nome_projeto { get; set; }

        [ForeignKey("FK_ID_Estado")]
        public int ID_Estado { get; set; }
        public Estado_Projeto Estado_Projetos { get; set; }



        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////// Para mexer 
        /// </summary>
        public ICollection<Tarefas> Tarefas { get; set; }
    }
}
