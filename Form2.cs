using Gerenciador_de_Tarefas;
using GerenciamentodeTarefas;
using Microsoft.Data.Sqlite;
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
    public partial class cadastroForm : Form
    {
        private AgendamentoRepository repository;

        public cadastroForm(AgendamentoRepository repository)
        {
            InitializeComponent();
            this.repository = repository;
        }

        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.cadastroUsername = txtUsernameCadastro.Text;
            usuario.cadastroSenha = txtSenhaCadastro.Text;
            repository.NovoUsuario(usuario);
            clearForm();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            txtUsernameCadastro.Clear();
            txtSenhaCadastro.Clear();
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
