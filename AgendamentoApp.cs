using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Tarefas
{
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
        private Label label1;
        private Button btnSalvar;
        private Button btnDeletar;
        private Button btnEditar;
        private BindingSource atividadeBindingSource;
        private System.ComponentModel.IContainer components;
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
            string connectionString = "Data Source=LUCAS\\SQLSERVER2022;Initial Catalog=master;Integrated Security=True";
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
            dataGridViewAtividades.DataSource = repository.ObterTodasAtividades();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
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

        private int pegarCheckBoxValor()
        {
            if (checkBoxConcluida.Checked)
            {
                if (int.TryParse(checkBoxConcluida.Tag.ToString(), out int result))
                {
                    return result;
                }
            }
            else if (checkBoxExecucao.Checked)
            {
                if (int.TryParse(checkBoxExecucao.Tag.ToString(), out int result))
                {
                    return result;
                }
            }

            return 0;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAtividades.SelectedRows.Count > 0)
                {
                    Atividade atividade = new Atividade
                    {
                        id = (int)dataGridViewAtividades.SelectedRows[0].Cells["ID"].Value,
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

        private void btnExcluir_Click(object sender, EventArgs e)
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

        private void dataGridViewAtividades_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewAtividades.SelectedRows.Count > 0)
            {
                int id = (int)dataGridViewAtividades.SelectedRows[0].Cells["ID"].Value;
                string nome = dataGridViewAtividades.SelectedRows[0].Cells["Nome"].Value.ToString();
                string descricao = dataGridViewAtividades.SelectedRows[0].Cells["Descricao"].Value.ToString();
                DateTime data = (DateTime)dataGridViewAtividades.SelectedRows[0].Cells["Data"].Value;
                bool concluida = (bool)dataGridViewAtividades.SelectedRows[0].Cells["Concluida"].Value;

                txtNome.Text = nome;
                txtDescricao.Text = descricao;
                monthCalendarData.SetDate(data);
                checkBoxConcluida.Checked = concluida;
            }
        }

        private void ClearForm()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            monthCalendarData.SetDate(DateTime.Now);
            checkBoxConcluida.Checked = false;
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
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
            label1 = new Label();
            atividadeBindingSource = new BindingSource(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAtividades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)atividadeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
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
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1075, 493);
            panel1.TabIndex = 2;
            // 
            // btnDeletar
            // 
            btnDeletar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeletar.Location = new Point(965, 425);
            btnDeletar.Name = "btnDeletar";
            btnDeletar.Size = new Size(98, 44);
            btnDeletar.TabIndex = 14;
            btnDeletar.Text = "Deletar";
            btnDeletar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditar.Location = new Point(861, 425);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(98, 44);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalvar.Location = new Point(357, 366);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(98, 44);
            btnSalvar.TabIndex = 12;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // dataGridViewAtividades
            // 
            dataGridViewAtividades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAtividades.Location = new Point(517, 63);
            dataGridViewAtividades.Name = "dataGridViewAtividades";
            dataGridViewAtividades.RowHeadersWidth = 51;
            dataGridViewAtividades.RowTemplate.Height = 24;
            dataGridViewAtividades.Size = new Size(548, 353);
            dataGridViewAtividades.TabIndex = 11;
            // 
            // checkBoxExecucao
            // 
            checkBoxExecucao.AutoSize = true;
            checkBoxExecucao.Location = new Point(342, 262);
            checkBoxExecucao.Name = "checkBoxExecucao";
            checkBoxExecucao.Size = new Size(130, 24);
            checkBoxExecucao.TabIndex = 10;
            checkBoxExecucao.Tag = "2";
            checkBoxExecucao.Text = "EM EXECUÇÃO";
            checkBoxExecucao.UseVisualStyleBackColor = true;
            // 
            // checkBoxConcluida
            // 
            checkBoxConcluida.AutoSize = true;
            checkBoxConcluida.Location = new Point(342, 288);
            checkBoxConcluida.Name = "checkBoxConcluida";
            checkBoxConcluida.Size = new Size(113, 24);
            checkBoxConcluida.TabIndex = 9;
            checkBoxConcluida.Tag = "1";
            checkBoxConcluida.Text = "CONCLUIDA";
            checkBoxConcluida.UseVisualStyleBackColor = true;
            // 
            // monthCalendarData
            // 
            monthCalendarData.Location = new Point(17, 262);
            monthCalendarData.Name = "monthCalendarData";
            monthCalendarData.TabIndex = 8;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(17, 153);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(462, 62);
            txtDescricao.TabIndex = 6;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(17, 92);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(462, 27);
            txtNome.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(342, 227);
            label5.Name = "label5";
            label5.Size = new Size(133, 26);
            label5.TabIndex = 4;
            label5.Text = "SITUAÇÃO:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(17, 227);
            label4.Name = "label4";
            label4.Size = new Size(92, 26);
            label4.TabIndex = 3;
            label4.Text = "PRAZO:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(17, 124);
            label3.Name = "label3";
            label3.Size = new Size(147, 26);
            label3.TabIndex = 2;
            label3.Text = "DESCRIÇÃO:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(17, 63);
            label2.Name = "label2";
            label2.Size = new Size(83, 26);
            label2.TabIndex = 1;
            label2.Text = "NOME:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 25.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(243, 9);
            label1.Name = "label1";
            label1.Size = new Size(579, 49);
            label1.TabIndex = 0;
            label1.Text = "AGENDADOR DE TAREFAS";
            // 
            // atividadeBindingSource
            // 
            atividadeBindingSource.DataSource = typeof(Atividade);
            // 
            // AgendamentoApp
            // 
            ClientSize = new Size(1075, 493);
            Controls.Add(panel1);
            Name = "AgendamentoApp";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAtividades).EndInit();
            ((System.ComponentModel.ISupportInitialize)atividadeBindingSource).EndInit();
            ResumeLayout(false);
        }
    }
}
