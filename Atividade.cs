using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Tarefas
{
    public class Atividade
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public DateTime prazo { get; set; }
        public string situacao { get; set; }

    }
}
