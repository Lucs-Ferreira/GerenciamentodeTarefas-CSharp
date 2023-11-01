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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            usernameLoginText = new TextBox();
            senhaLoginText = new TextBox();
            btnSalvarLogin = new Button();
            btnCancelarLogin = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // usernameLoginText
            // 
            usernameLoginText.BackColor = SystemColors.InactiveCaption;
            usernameLoginText.Location = new Point(560, 122);
            usernameLoginText.Name = "usernameLoginText";
            usernameLoginText.Size = new Size(174, 23);
            usernameLoginText.TabIndex = 0;
            // 
            // senhaLoginText
            // 
            senhaLoginText.BackColor = SystemColors.InactiveCaption;
            senhaLoginText.Location = new Point(560, 194);
            senhaLoginText.Name = "senhaLoginText";
            senhaLoginText.PasswordChar = '*';
            senhaLoginText.Size = new Size(174, 23);
            senhaLoginText.TabIndex = 3;
            // 
            // btnSalvarLogin
            // 
            btnSalvarLogin.Location = new Point(584, 237);
            btnSalvarLogin.Name = "btnSalvarLogin";
            btnSalvarLogin.Size = new Size(138, 37);
            btnSalvarLogin.TabIndex = 4;
            btnSalvarLogin.Text = "Logar";
            btnSalvarLogin.UseVisualStyleBackColor = true;
            btnSalvarLogin.Click += btnSalvarLogin_Click;
            // 
            // btnCancelarLogin
            // 
            btnCancelarLogin.Location = new Point(584, 280);
            btnCancelarLogin.Name = "btnCancelarLogin";
            btnCancelarLogin.Size = new Size(138, 37);
            btnCancelarLogin.TabIndex = 6;
            btnCancelarLogin.Text = "Cancelar";
            btnCancelarLogin.UseVisualStyleBackColor = true;
            btnCancelarLogin.Click += btnCancelarLogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, -78);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(542, 384);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(560, 45);
            label1.Name = "label1";
            label1.Size = new Size(167, 32);
            label1.TabIndex = 8;
            label1.Text = "Bem Vindo";
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(775, 328);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(btnCancelarLogin);
            Controls.Add(btnSalvarLogin);
            Controls.Add(senhaLoginText);
            Controls.Add(usernameLoginText);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "loginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameLoginText;
        private TextBox senhaLoginText;
        private Button btnSalvarLogin;
        private Button btnCancelarLogin;
        private PictureBox pictureBox1;
        private Label label1;
    }
}