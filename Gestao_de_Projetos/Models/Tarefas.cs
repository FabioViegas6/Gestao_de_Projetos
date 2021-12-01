﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Projetos.Models
{
    public class Tarefas
    {

        public int idTarefas { get; set; }

        public string Descricao { get; set; }

        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }

        public int ID_membro { get; set; }
        public Membros Membros { get; set; }
    }
}
