using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Membros
    {
        [Key]
        public int MembrosID { get; set; }


        [Required]
        [Display(Name = "Nome do Membro")]
        [RegularExpression(@"^[A-Z]+[a-záéíóúõãçàâêôA-ZÁÉÍÓÚÕÃÇÀÂÊÔ]{1,40}$",
        ErrorMessage = "O nome deve comer pela maiuscula e não deve conter numeros")]

        public String Nome_membro { get; set; }

        

        [StringLength(9)]
        [Display(Name = "Telefone", Prompt = "Telefone")]
        [Required(ErrorMessage = "Por favor insira o seu numero de telefone")]
        [RegularExpression(@"(9\d{8})", ErrorMessage = "Numero invalido.")]
        public String Telefone { get; set; }

       

        [Required(ErrorMessage = "Por favor, insira o seu Email")]
        [StringLength(50, MinimumLength = 12, ErrorMessage = "O seu Email deve ter entre 12 e 50 caracteres")]
        [EmailAddress(ErrorMessage = "Por favor, introduza o seu Email correto")]
        [Display(Name = "Email *", Prompt = "Email")]
        public String Email { get; set; }

        //[Required(ErrorMessage = "A sua Password deve ter entre 8 e 20 caracteres")]
        //[StringLength(20, MinimumLength = 8, ErrorMessage = "A sua Password deve ter entre 8 e 20 caracteres")]
        //[Display(Name = "Password *", Prompt = "Password")]
        //public String Password { get; set; }


        public ICollection <Tarefas> Tarefas { get; set; }




        [ForeignKey("FK_ID_funcao")]
        public int FuncaoID { get; set; }
        public Funcao Funcao { get; set; }

    }
}
