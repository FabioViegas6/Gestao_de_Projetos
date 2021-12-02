using Gestao_de_Projetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.ViewModels
{
    public class TarefasListViewModel
    {

        public IEnumerable<Tarefas> ListaTarefas { get; set; }
        public PagingInfo PagingInfo { get; set; }


    }
}
