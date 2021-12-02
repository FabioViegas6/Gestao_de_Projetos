using Gestao_de_Projetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.ViewModels
{
    public class MembroListViewModel
    {
        public IEnumerable<Membros> ListaMembros { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
