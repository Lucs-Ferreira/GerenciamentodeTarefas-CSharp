using Gerenciador_de_Tarefas;
using GerenciamentodeTarefas;
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
        string connectionString = "Data Source=C:\\Users\\lucas\\OneDrive\\Área de Trabalho\\Nova pasta\\GerenciamentodeTarefas-CSharp-master\\bd\\gerenciadorTarefas.db";

        AgendamentoApp agendamentoApp;

        DataTable dt = new DataTable();

        AgendamentoRepository repository;
        public loginForm(AgendamentoApp f)
        {
            InitializeComponent();
            agendamentoApp = f;
            repository = new AgendamentoRepository(connectionString);
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
            dt = repository.Consulta(sql);
            if (dt.Rows.Count == 1)
            {
                agendamentoApp.lb_nomeUsuario.Text = dt.Rows[0].Field<string>("C_USERNAME");
                agendamentoApp.nivelAcesso.Text = dt.Rows[0].ItemArray[3].ToString();
                Usuarios.acesso = int.Parse(dt.Rows[0].Field<Int64>("C_ACESSO").ToString());
                Usuarios.logado = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário não encontrado");
            }
        }
    }
}

