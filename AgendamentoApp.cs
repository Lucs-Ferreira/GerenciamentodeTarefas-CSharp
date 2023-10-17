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
        private AgendamentoRepository repository;

        public AgendamentoApp()
        {
            InitializeComponent();
            string connectionString = "SuaStringDeConexãoSQL";
            repository = new AgendamentoRepository(connectionString);
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

        private int pegarCheckBoxValor()
        {
            if (checkBoxConcluida.Checked)
            {
                return (int)checkBoxConcluida.Tag;
            }
            else if (checkBoxExecucao.Checked)
            {
                return (int)checkBoxExecucao.Tag;
            }

            return 0;
        }

        private void btnEditar_Click(object sender, EventArgs e)
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridViewAtividades.SelectedRows.Count > 0)
            {
                int id = (int)dataGridViewAtividades.SelectedRows[0].Cells["ID"].Value;
                repository.ExcluirAtividade(id);
                RefreshDataGrid();
                ClearForm();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewAtividades = new System.Windows.Forms.DataGridView();
            this.checkBoxExecucao = new System.Windows.Forms.CheckBox();
            this.checkBoxConcluida = new System.Windows.Forms.CheckBox();
            this.monthCalendarData = new System.Windows.Forms.MonthCalendar();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtividades)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.dataGridViewAtividades);
            this.panel1.Controls.Add(this.checkBoxExecucao);
            this.panel1.Controls.Add(this.checkBoxConcluida);
            this.panel1.Controls.Add(this.monthCalendarData);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1075, 493);
            this.panel1.TabIndex = 2;
            // 
            // dataGridViewAtividades
            // 
            this.dataGridViewAtividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAtividades.Location = new System.Drawing.Point(517, 63);
            this.dataGridViewAtividades.Name = "dataGridViewAtividades";
            this.dataGridViewAtividades.RowHeadersWidth = 51;
            this.dataGridViewAtividades.RowTemplate.Height = 24;
            this.dataGridViewAtividades.Size = new System.Drawing.Size(548, 353);
            this.dataGridViewAtividades.TabIndex = 11;
            // 
            // checkBoxExecucao
            // 
            this.checkBoxExecucao.AutoSize = true;
            this.checkBoxExecucao.Location = new System.Drawing.Point(342, 262);
            this.checkBoxExecucao.Name = "checkBoxExecucao";
            this.checkBoxExecucao.Size = new System.Drawing.Size(125, 20);
            this.checkBoxExecucao.TabIndex = 10;
            this.checkBoxExecucao.Tag = "2";
            this.checkBoxExecucao.Text = "EM EXECUÇÃO";
            this.checkBoxExecucao.UseVisualStyleBackColor = true;
            // 
            // checkBoxConcluida
            // 
            this.checkBoxConcluida.AutoSize = true;
            this.checkBoxConcluida.Location = new System.Drawing.Point(342, 288);
            this.checkBoxConcluida.Name = "checkBoxConcluida";
            this.checkBoxConcluida.Size = new System.Drawing.Size(106, 20);
            this.checkBoxConcluida.TabIndex = 9;
            this.checkBoxConcluida.Tag = "1";
            this.checkBoxConcluida.Text = "CONCLUIDA";
            this.checkBoxConcluida.UseVisualStyleBackColor = true;
            // 
            // monthCalendarData
            // 
            this.monthCalendarData.Location = new System.Drawing.Point(17, 262);
            this.monthCalendarData.Name = "monthCalendarData";
            this.monthCalendarData.TabIndex = 8;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(17, 153);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(462, 62);
            this.txtDescricao.TabIndex = 6;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(17, 92);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(462, 22);
            this.txtNome.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(342, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "SITUAÇÃO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "PRAZO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "DESCRIÇÃO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "NOME:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(579, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "AGENDADOR DE TAREFAS";
            // 
            // AgendamentoApp
            // 
            this.ClientSize = new System.Drawing.Size(1075, 493);
            this.Controls.Add(this.panel1);
            this.Name = "AgendamentoApp";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtividades)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
