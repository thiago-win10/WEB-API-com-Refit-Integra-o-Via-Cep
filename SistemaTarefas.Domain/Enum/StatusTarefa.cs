using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTarefas.Domain.Enum
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        AFazer = 1,

        [Description("Em andamento")]
        EmAndamento = 2,

        [Description("Concluido")]
        Concluido = 3
    }
}
