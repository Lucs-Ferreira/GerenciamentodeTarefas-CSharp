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
            label2 = new Label();
            txtUsernameCadastro = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            button2 = new Button();
            btnCancelar = new Button();
            btnSalvarCadastro = new Button();
            txtSenhaCadastro = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(16, 9);
            label2.Name = "label2";
            label2.Size = new Size(84, 21);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // txtUsernameCadastro
            // 
            txtUsernameCadastro.Location = new Point(20, 33);
            txtUsernameCadastro.Name = "txtUsernameCadastro";
            txtUsernameCadastro.Size = new Size(146, 23);
            txtUsernameCadastro.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(182, 9);
            label3.Name = "label3";
            label3.Size = new Size(55, 21);
            label3.TabIndex = 4;
            label3.Text = "Senha";
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnSalvarCadastro);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 78);
            panel1.Name = "panel1";
            panel1.Size = new Size(347, 53);
            panel1.TabIndex = 11;
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(248, 0);
            button2.Name = "button2";
            button2.Size = new Size(80, 39);
            button2.TabIndex = 2;
            button2.Text = "Salvar";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.Location = new Point(106, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(84, 39);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvarCadastro
            // 
            btnSalvarCadastro.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalvarCadastro.Location = new Point(20, 0);
            btnSalvarCadastro.Name = "btnSalvarCadastro";
            btnSalvarCadastro.Size = new Size(80, 39);
            btnSalvarCadastro.TabIndex = 0;
            btnSalvarCadastro.Text = "Salvar";
            btnSalvarCadastro.UseVisualStyleBackColor = true;
            btnSalvarCadastro.Click += btnSalvarCadastro_Click;
            // 
            // txtSenhaCadastro
            // 
            txtSenhaCadastro.Location = new Point(182, 33);
            txtSenhaCadastro.Name = "txtSenhaCadastro";
            txtSenhaCadastro.Size = new Size(146, 23);
            txtSenhaCadastro.TabIndex = 12;
            // 
            // cadastroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(347, 131);
            Controls.Add(txtSenhaCadastro);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(txtUsernameCadastro);
            Controls.Add(label2);
            Name = "cadastroForm";
            Text = "Cadastro";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtUsernameCadastro;
        private Label label3;
        private Panel panel1;
        private Button btnSalvarCadastro;
        private TextBox txtSenhaCadastro;
        private Button button2;
        private Button btnCancelar;
    }
}