namespace GerenciamentodeTarefas_CSharp
{
    partial class loginForm
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
            textBox1 = new TextBox();
            username = new Label();
            senha = new Label();
            textBox2 = new TextBox();
            btnSalvarLogin = new Button();
            btnCancelarLogin = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 34);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(174, 23);
            textBox1.TabIndex = 0;
            // 
            // username
            // 
            username.AutoSize = true;
            username.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            username.Location = new Point(12, 12);
            username.Name = "username";
            username.Size = new Size(70, 19);
            username.TabIndex = 1;
            username.Text = "Username";
            // 
            // senha
            // 
            senha.AutoSize = true;
            senha.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            senha.Location = new Point(12, 75);
            senha.Name = "senha";
            senha.Size = new Size(46, 19);
            senha.TabIndex = 2;
            senha.Text = "Senha";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 97);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(174, 23);
            textBox2.TabIndex = 3;
            // 
            // btnSalvarLogin
            // 
            btnSalvarLogin.Location = new Point(30, 141);
            btnSalvarLogin.Name = "btnSalvarLogin";
            btnSalvarLogin.Size = new Size(138, 37);
            btnSalvarLogin.TabIndex = 4;
            btnSalvarLogin.Text = "Logar";
            btnSalvarLogin.UseVisualStyleBackColor = true;
            // 
            // btnCancelarLogin
            // 
            btnCancelarLogin.Location = new Point(30, 184);
            btnCancelarLogin.Name = "btnCancelarLogin";
            btnCancelarLogin.Size = new Size(138, 37);
            btnCancelarLogin.TabIndex = 6;
            btnCancelarLogin.Text = "Cancelar";
            btnCancelarLogin.UseVisualStyleBackColor = true;
            btnCancelarLogin.Click += btnCancelarLogin_Click;
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(195, 240);
            Controls.Add(btnCancelarLogin);
            Controls.Add(btnSalvarLogin);
            Controls.Add(textBox2);
            Controls.Add(senha);
            Controls.Add(username);
            Controls.Add(textBox1);
            Name = "loginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label username;
        private Label senha;
        private TextBox textBox2;
        private Button btnSalvarLogin;
        private Button btnCancelarLogin;
    }
}