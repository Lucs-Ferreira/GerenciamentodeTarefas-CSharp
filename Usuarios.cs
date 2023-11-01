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
           
        public Int32 nivel { get; set; }

        public static int acesso = 0;
        public static Boolean logado = false;
    }

}
