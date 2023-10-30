using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentodeTarefas
{
    public class Usuarios
    {
        public int idUsuarios { get; set; }
        public string cadastroUsername { get; set; }
        public string cadastroSenha { get; set; }

        public bool logado = false;
    }

}
