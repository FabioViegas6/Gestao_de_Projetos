using Gestao_de_Projetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.ViewModels
{
    public class ClientesListViewModel
    {
        public IEnumerable<Clientes> ListaClientes { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string ClienteSearched { get; set; }
       // public List<Clientes> ListaMembros { get; internal set; }
    }
}
