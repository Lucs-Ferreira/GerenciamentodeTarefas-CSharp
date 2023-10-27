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
        public cadastroForm()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }

        private void ClearForm()
        {
            txtUsernameCadastro.Clear();
            txtSenhaCadastro.Clear();
        }

        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
           
        }
    }
}
