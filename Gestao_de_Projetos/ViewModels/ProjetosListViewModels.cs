using Gestao_de_Projetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.ViewModels
{
    public class ProjetosListViewModels
    {
        public IEnumerable<Project> ListaProjetos { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string ProjetoSearched { get; set; }
        public List<Project> ListaMembros { get; internal set; }
    }
}
