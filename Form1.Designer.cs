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
            usernameLoginText = new TextBox();
            username = new Label();
            senha = new Label();
            senhaLoginText = new TextBox();
            btnSalvarLogin = new Button();
            btnCancelarLogin = new Button();
            SuspendLayout();
            // 
            // usernameLoginText
            // 
            usernameLoginText.Location = new Point(12, 34);
            usernameLoginText.Name = "usernameLoginText";
            usernameLoginText.Size = new Size(174, 23);
            usernameLoginText.TabIndex = 0;
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
            // senhaLoginText
            // 
            senhaLoginText.Location = new Point(12, 97);
            senhaLoginText.Name = "senhaLoginText";
            senhaLoginText.PasswordChar = '*';
            senhaLoginText.Size = new Size(174, 23);
            senhaLoginText.TabIndex = 3;
            // 
            // btnSalvarLogin
            // 
            btnSalvarLogin.Location = new Point(30, 141);
            btnSalvarLogin.Name = "btnSalvarLogin";
            btnSalvarLogin.Size = new Size(138, 37);
            btnSalvarLogin.TabIndex = 4;
            btnSalvarLogin.Text = "Logar";
            btnSalvarLogin.UseVisualStyleBackColor = true;
            btnSalvarLogin.Click += btnSalvarLogin_Click;
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
            Controls.Add(senhaLoginText);
            Controls.Add(senha);
            Controls.Add(username);
            Controls.Add(usernameLoginText);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "loginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameLoginText;
        private Label username;
        private Label senha;
        private TextBox senhaLoginText;
        private Button btnSalvarLogin;
        private Button btnCancelarLogin;
    }
}