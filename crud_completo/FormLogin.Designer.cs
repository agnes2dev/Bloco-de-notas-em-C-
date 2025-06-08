namespace crud_completo
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblSenha = new Label();
            txtSenha = new TextBox();
            btnLogin = new Button();
            btnSair = new Button();
            lblInfo = new Label();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(92, 110);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Usuário:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(152, 107);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(180, 27);
            txtUsuario.TabIndex = 0;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(92, 140);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(52, 20);
            lblSenha.TabIndex = 5;
            lblSenha.Text = "Senha:";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(152, 137);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(180, 27);
            txtSenha.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(109, 200);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(89, 60);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnSair
            // 
            btnSair.DialogResult = DialogResult.Cancel;
            btnSair.Location = new Point(247, 200);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(85, 60);
            btnSair.TabIndex = 3;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.ForeColor = SystemColors.ControlDarkDark;
            lblInfo.Location = new Point(12, 9);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(0, 20);
            lblInfo.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Window;
            groupBox1.Location = new Point(-10, -3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(485, 83);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._669f362ec92af42bdb1747f2abb59e7a;
            pictureBox1.Location = new Point(338, 86);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 92);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            AcceptButton = btnLogin;
            BackColor = SystemColors.InactiveCaption;
            CancelButton = btnSair;
            ClientSize = new Size(460, 320);
            Controls.Add(pictureBox1);
            Controls.Add(lblInfo);
            Controls.Add(btnSair);
            Controls.Add(btnLogin);
            Controls.Add(txtSenha);
            Controls.Add(lblSenha);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - Bloco de Notas";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblInfo;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
    }
}