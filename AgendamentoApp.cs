using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Tarefas
{
    using GerenciamentodeTarefas;
    using GerenciamentodeTarefas_CSharp;
    using System;
    using System.Windows.Forms;

    public partial class AgendamentoApp : Form
    {
        private Panel panel1;
        private DataGridView dataGridViewAtividades;
        private CheckBox checkBoxExecucao;
        private CheckBox checkBoxConcluida;
        private MonthCalendar monthCalendarData;
        private TextBox txtDescricao;
        private TextBox txtNome;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnSalvar;
        private Button btnDeletar;
        private Button btnEditar;
        private BindingSource atividadeBindingSource;
        private System.ComponentModel.IContainer components;
        private Button btnCadastro;
        private Button btnLogin;
        private Button btnAtualizar;
        private Panel panel3;
        private Panel panel2;
        public Label nivelAcesso;
        private Label label7;
        public Label lb_nomeUsuario;
        private Label label6;
        private PictureBox pictureBox1;
        private TextBox txtId;
        private AgendamentoRepository repository;

        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AgendamentoApp());
        }
        public AgendamentoApp()
        {
            InitializeComponent();
            loginForm form = new loginForm(this);
            form.ShowDialog();
            string connectionString = "Data Source=C:\\bd\\gerenciadorTarefasAtt.db";
            try
            {
                repository = new AgendamentoRepository(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgendamentoApp_Load(object sender, EventArgs e)
        {
            monthCalendarData.SetDate(DateTime.Now);
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            dataGridViewAtividades.RowHeadersVisible = false;
            dataGridViewAtividades.AutoResizeColumns();
            dataGridViewAtividades.DataSource = repository.ObterTodasAtividades();
            dataGridViewAtividades.Columns["id"].Width = 30;
            dataGridViewAtividades.Columns["nome"].Width = 120;
            dataGridViewAtividades.Columns["descricao"].Width = 150;
            dataGridViewAtividades.Columns["prazo"].Width = 90;
            dataGridViewAtividades.Columns["situacao"].Width = 70;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Usuarios.logado)
            {
                if (Usuarios.acesso >= 1)
                {
                    try
                    {
                        Atividade atividade = new Atividade
                        {
                            nome = txtNome.Text,
                            descricao = txtDescricao.Text,
                            prazo = monthCalendarData.SelectionStart,
                            situacao = pegarCheckBoxValor()
                        };

                        repository.AdicionarAtividade(atividade);
                        RefreshDataGrid();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao salvar a tarefa! " + ex.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Necessário um nível maior de acesso!");
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado!");
            }
        }

        private string pegarCheckBoxValor()
        {
            if (checkBoxConcluida.Checked)
            {
                return (string)checkBoxConcluida.Tag;
            }
            else if (checkBoxExecucao.Checked)
            {
                return (string)checkBoxExecucao.Tag;
            }

            return "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Usuarios.logado)
            {
                if (Usuarios.acesso >= 1)
                {
                    try
                    {
                        if (dataGridViewAtividades.SelectedRows.Count > 0)
                        {
                            int id = (int)dataGridViewAtividades.SelectedRows[0].Cells["ID"].Value;
                            repository.ExcluirAtividade(id);
                            RefreshDataGrid();
                            ClearForm();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao deletar a tarefa! " + ex.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Necessário um nível maior de acesso!");
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado!");
            }
        }

        private void ClearForm()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            monthCalendarData.SetDate(DateTime.Now);
            checkBoxConcluida.Checked = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                loginForm form = new loginForm(this);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir formulário de login " + ex.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            if (Usuarios.logado)
            {
                if (Usuarios.acesso == 3)
                {
                    try
                    {
                        cadastroForm cadastroForm = new cadastroForm(repository);
                        cadastroForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao abrir formulário de cadastro " + ex.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Necessário um nível maior de acesso!");
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado!");
            }
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgendamentoApp));
            panel1 = new Panel();
            txtId = new TextBox();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            btnCadastro = new Button();
            btnLogin = new Button();
            btnAtualizar = new Button();
            panel2 = new Panel();
            nivelAcesso = new Label();
            label7 = new Label();
            lb_nomeUsuario = new Label();
            label6 = new Label();
            btnDeletar = new Button();
            btnEditar = new Button();
            btnSalvar = new Button();
            dataGridViewAtividades = new DataGridView();
            checkBoxExecucao = new CheckBox();
            checkBoxConcluida = new CheckBox();
            monthCalendarData = new MonthCalendar();
            txtDescricao = new TextBox();
            txtNome = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            atividadeBindingSource = new BindingSource(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAtividades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)atividadeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(txtId);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(btnAtualizar);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnDeletar);
            panel1.Controls.Add(btnEditar);
            panel1.Controls.Add(btnSalvar);
            panel1.Controls.Add(dataGridViewAtividades);
            panel1.Controls.Add(checkBoxExecucao);
            panel1.Controls.Add(checkBoxConcluida);
            panel1.Controls.Add(monthCalendarData);
            panel1.Controls.Add(txtDescricao);
            panel1.Controls.Add(txtNome);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(974, 574);
            panel1.TabIndex = 2;
            // 
            // txtId
            // 
            txtId.BackColor = SystemColors.ActiveBorder;
            txtId.Location = new Point(44, 67);
            txtId.Name = "txtId";
            txtId.Size = new Size(61, 27);
            txtId.TabIndex = 21;
            txtId.TabStop = false;
            txtId.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(245, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(484, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(btnCadastro);
            panel3.Controls.Add(btnLogin);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(974, 35);
            panel3.TabIndex = 19;
            // 
            // btnCadastro
            // 
            btnCadastro.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCadastro.Location = new Point(111, 3);
            btnCadastro.Name = "btnCadastro";
            btnCadastro.Size = new Size(93, 28);
            btnCadastro.TabIndex = 16;
            btnCadastro.Text = "Cadastro";
            btnCadastro.UseVisualStyleBackColor = true;
            btnCadastro.Click += btnCadastro_Click;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(12, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(93, 28);
            btnLogin.TabIndex = 15;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnAtualizar.Location = new Point(366, 443);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(98, 44);
            btnAtualizar.TabIndex = 7;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Controls.Add(nivelAcesso);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(lb_nomeUsuario);
            panel2.Controls.Add(label6);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 540);
            panel2.Name = "panel2";
            panel2.Size = new Size(974, 34);
            panel2.TabIndex = 17;
            // 
            // nivelAcesso
            // 
            nivelAcesso.AutoSize = true;
            nivelAcesso.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nivelAcesso.Location = new Point(254, 6);
            nivelAcesso.Name = "nivelAcesso";
            nivelAcesso.Size = new Size(20, 22);
            nivelAcesso.TabIndex = 4;
            nivelAcesso.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(176, 6);
            label7.Name = "label7";
            label7.Size = new Size(106, 22);
            label7.TabIndex = 3;
            label7.Text = "Acesso: ";
            // 
            // lb_nomeUsuario
            // 
            lb_nomeUsuario.AutoSize = true;
            lb_nomeUsuario.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb_nomeUsuario.Location = new Point(87, 6);
            lb_nomeUsuario.Name = "lb_nomeUsuario";
            lb_nomeUsuario.Size = new Size(38, 22);
            lb_nomeUsuario.TabIndex = 2;
            lb_nomeUsuario.Text = "----";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(3, 6);
            label6.Name = "label6";
            label6.Size = new Size(118, 22);
            label6.TabIndex = 1;
            label6.Text = "Usuário: ";
            // 
            // btnDeletar
            // 
            btnDeletar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeletar.Location = new Point(869, 490);
            btnDeletar.Name = "btnDeletar";
            btnDeletar.Size = new Size(98, 44);
            btnDeletar.TabIndex = 9;
            btnDeletar.Text = "Deletar";
            btnDeletar.UseVisualStyleBackColor = true;
            btnDeletar.Click += btnDeletar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditar.Location = new Point(765, 490);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(98, 44);
            btnEditar.TabIndex = 8;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click_1;
            // 
            // btnSalvar
            // 
            btnSalvar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalvar.Location = new Point(262, 443);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(98, 44);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // dataGridViewAtividades
            // 
            dataGridViewAtividades.AllowUserToAddRows = false;
            dataGridViewAtividades.AllowUserToDeleteRows = false;
            dataGridViewAtividades.BackgroundColor = SystemColors.ActiveBorder;
            dataGridViewAtividades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAtividades.Location = new Point(486, 126);
            dataGridViewAtividades.Name = "dataGridViewAtividades";
            dataGridViewAtividades.ReadOnly = true;
            dataGridViewAtividades.RowHeadersWidth = 51;
            dataGridViewAtividades.RowTemplate.Height = 24;
            dataGridViewAtividades.Size = new Size(481, 361);
            dataGridViewAtividades.TabIndex = 11;
            dataGridViewAtividades.TabStop = false;
            // 
            // checkBoxExecucao
            // 
            checkBoxExecucao.AutoSize = true;
            checkBoxExecucao.Location = new Point(292, 325);
            checkBoxExecucao.Name = "checkBoxExecucao";
            checkBoxExecucao.Size = new Size(130, 24);
            checkBoxExecucao.TabIndex = 4;
            checkBoxExecucao.Tag = "EM EXECUÇÃO";
            checkBoxExecucao.Text = "EM EXECUÇÃO";
            checkBoxExecucao.UseVisualStyleBackColor = true;
            // 
            // checkBoxConcluida
            // 
            checkBoxConcluida.AutoSize = true;
            checkBoxConcluida.Location = new Point(292, 351);
            checkBoxConcluida.Name = "checkBoxConcluida";
            checkBoxConcluida.Size = new Size(113, 24);
            checkBoxConcluida.TabIndex = 5;
            checkBoxConcluida.Tag = "CONCLUIDA";
            checkBoxConcluida.Text = "CONCLUIDA";
            checkBoxConcluida.UseVisualStyleBackColor = true;
            // 
            // monthCalendarData
            // 
            monthCalendarData.Location = new Point(12, 325);
            monthCalendarData.Name = "monthCalendarData";
            monthCalendarData.TabIndex = 3;
            // 
            // txtDescricao
            // 
            txtDescricao.BackColor = SystemColors.ActiveBorder;
            txtDescricao.Location = new Point(12, 216);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(408, 62);
            txtDescricao.TabIndex = 2;
            // 
            // txtNome
            // 
            txtNome.BackColor = SystemColors.ActiveBorder;
            txtNome.Location = new Point(12, 155);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(408, 27);
            txtNome.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Courier New", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(292, 290);
            label5.Name = "label5";
            label5.Size = new Size(138, 27);
            label5.TabIndex = 4;
            label5.Text = "SITUAÇÃO:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Courier New", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 290);
            label4.Name = "label4";
            label4.Size = new Size(96, 27);
            label4.TabIndex = 3;
            label4.Text = "PRAZO:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Courier New", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 187);
            label3.Name = "label3";
            label3.Size = new Size(152, 27);
            label3.TabIndex = 2;
            label3.Text = "DESCRIÇÃO:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 126);
            label2.Name = "label2";
            label2.Size = new Size(82, 27);
            label2.TabIndex = 1;
            label2.Text = "NOME:";
            // 
            // atividadeBindingSource
            // 
            atividadeBindingSource.DataSource = typeof(Atividade);
            // 
            // AgendamentoApp
            // 
            ClientSize = new Size(974, 574);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgendamentoApp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agendador de Tarefas";
            Load += AgendamentoApp_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAtividades).EndInit();
            ((System.ComponentModel.ISupportInitialize)atividadeBindingSource).EndInit();
            ResumeLayout(false);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (Usuarios.logado)
            {
                if (Usuarios.acesso >= 1)
                {
                    try
                    {
                        if (dataGridViewAtividades.SelectedCells.Count > 0)
                        {
                            Atividade atividade = new Atividade
                            {
                                id = int.Parse(txtId.Text),
                                nome = txtNome.Text,
                                descricao = txtDescricao.Text,
                                prazo = monthCalendarData.SelectionStart,
                                situacao = pegarCheckBoxValor()
                            };

                            repository.EditarAtividade(atividade);
                            RefreshDataGrid();
                            ClearForm();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao editar a tarefa! " + ex.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Necessário um nível maior de acesso!");
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado!");
            }

            RefreshDataGrid();
        }

        private void AgendamentoApp_Load_1(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewAtividades.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridViewAtividades.SelectedCells[0].RowIndex;
                DataGridViewRow row = dataGridViewAtividades.Rows[rowIndex];
                PreencherTextBox(row);
            }
            else
            {
                MessageBox.Show("Selecione uma linha para editar.");
            }
        }

        private void PreencherTextBox(DataGridViewRow row)
        {
            string id = row.Cells["id"].Value.ToString();
            string nome = row.Cells["nome"].Value.ToString();
            string descricao = row.Cells["descricao"].Value.ToString();
            string prazo = row.Cells["prazo"].Value.ToString();
            string situacao = row.Cells["situacao"].Value.ToString();

            // Preencher TextBox
            txtId.Text = id;
            txtNome.Text = nome;
            txtDescricao.Text = descricao;
            monthCalendarData.SetDate(DateTime.Parse(prazo));
            if (situacao == "EM EXECUÇÃO")
            {
                checkBoxConcluida.Checked = false;
                checkBoxExecucao.Checked = true;
            }
            else
            {
                checkBoxExecucao.Checked = false;
                checkBoxConcluida.Checked = true;
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAtividades.SelectedCells.Count > 0)
                {
                    int rowIndex = dataGridViewAtividades.SelectedCells[0].RowIndex;
                    DataGridViewRow row = dataGridViewAtividades.Rows[rowIndex];
                    int id = int.Parse(row.Cells["id"].Value.ToString());
                    repository.ExcluirAtividade(id);
                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show("Selecione uma linha para excluir.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir a tarefa! " + ex.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
