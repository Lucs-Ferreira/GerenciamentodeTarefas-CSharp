namespace GerenciamentodeTarefas_CSharp
{
    partial class cadastroForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cadastroForm));
            label2 = new Label();
            txtUsernameCadastro = new TextBox();
            panel1 = new Panel();
            btnFechar = new Button();
            btnCancelar = new Button();
            btnSalvarCadastro = new Button();
            n_nivel = new NumericUpDown();
            label1 = new Label();
            txtSenhaCadastro = new TextBox();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)n_nivel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(62, 55);
            label2.Name = "label2";
            label2.Size = new Size(98, 22);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // txtUsernameCadastro
            // 
            txtUsernameCadastro.BackColor = SystemColors.InactiveCaption;
            txtUsernameCadastro.Location = new Point(62, 79);
            txtUsernameCadastro.Name = "txtUsernameCadastro";
            txtUsernameCadastro.Size = new Size(166, 23);
            txtUsernameCadastro.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InactiveCaption;
            panel1.Controls.Add(btnFechar);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnSalvarCadastro);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 262);
            panel1.Name = "panel1";
            panel1.Size = new Size(598, 43);
            panel1.TabIndex = 11;
            // 
            // btnFechar
            // 
            btnFechar.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnFechar.Location = new Point(506, 3);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(80, 39);
            btnFechar.TabIndex = 6;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.Location = new Point(106, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(84, 39);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvarCadastro
            // 
            btnSalvarCadastro.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalvarCadastro.Location = new Point(12, 3);
            btnSalvarCadastro.Name = "btnSalvarCadastro";
            btnSalvarCadastro.Size = new Size(80, 39);
            btnSalvarCadastro.TabIndex = 4;
            btnSalvarCadastro.Text = "Salvar";
            btnSalvarCadastro.UseVisualStyleBackColor = true;
            btnSalvarCadastro.Click += btnSalvarCadastro_Click;
            // 
            // n_nivel
            // 
            n_nivel.BackColor = SystemColors.InactiveCaption;
            n_nivel.Location = new Point(62, 178);
            n_nivel.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            n_nivel.Name = "n_nivel";
            n_nivel.Size = new Size(166, 23);
            n_nivel.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(62, 154);
            label1.Name = "label1";
            label1.Size = new Size(76, 22);
            label1.TabIndex = 14;
            label1.Text = "Acesso";
            // 
            // txtSenhaCadastro
            // 
            txtSenhaCadastro.BackColor = SystemColors.InactiveCaption;
            txtSenhaCadastro.Location = new Point(62, 128);
            txtSenhaCadastro.Name = "txtSenhaCadastro";
            txtSenhaCadastro.PasswordChar = '*';
            txtSenhaCadastro.Size = new Size(166, 23);
            txtSenhaCadastro.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Courier New", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(62, 104);
            label3.Name = "label3";
            label3.Size = new Size(65, 22);
            label3.TabIndex = 4;
            label3.Text = "Senha";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(264, -37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(283, 283);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // cadastroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(598, 305);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(n_nivel);
            Controls.Add(txtSenhaCadastro);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(txtUsernameCadastro);
            Controls.Add(label2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "cadastroForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)n_nivel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtUsernameCadastro;
        private Panel panel1;
        private Button btnSalvarCadastro;
        private Button btnFechar;
        private Button btnCancelar;
        private NumericUpDown n_nivel;
        private Label label1;
        private TextBox txtSenhaCadastro;
        private Label label3;
        private PictureBox pictureBox1;
    }
}