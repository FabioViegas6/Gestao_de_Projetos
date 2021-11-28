using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Data
{
    public class Gestao_de_ProjetosContext : DbContext
    {
        public Gestao_de_ProjetosContext(DbContextOptions<Gestao_de_ProjetosContext> options)
           : base(options)
        {
        }
    }
}
