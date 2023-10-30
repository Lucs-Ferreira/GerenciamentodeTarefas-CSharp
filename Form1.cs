using Gerenciador_de_Tarefas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentodeTarefas_CSharp
{
    public partial class loginForm : Form
    {
        AgendamentoApp agendamentoApp;
        DataTable dt = new DataTable();
        public loginForm(AgendamentoApp f)
        {
            InitializeComponent();
            agendamentoApp = f;
        }

        private void btnCancelarLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvarLogin_Click(object sender, EventArgs e)
        {
            string username = usernameLoginText.Text;
            string senha = senhaLoginText.Text;
            
            if (username == "" || senha == "")
            {
                MessageBox.Show("Usuario e/ou senha inválidas!");
                usernameLoginText.Focus();
                return;
            }

            string sql = "SELECT * FROM tb_usuarios WHERE C_USERNAME='" + username + "' AND C_SENHA='" + senha + "'";
            
        }
    }
}
