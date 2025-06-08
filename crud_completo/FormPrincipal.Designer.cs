namespace crud_completo
{
    partial class FormPrincipal
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
            dgvNotas = new DataGridView();
            btnNovaNota = new Button();
            btnEditarNota = new Button();
            btnExcluirNota = new Button();
            btnAtualizarLista = new Button();
            lblUsuarioInfo = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvNotas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvNotas
            // 
            dgvNotas.AllowUserToAddRows = false;
            dgvNotas.AllowUserToDeleteRows = false;
            dgvNotas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNotas.BackgroundColor = SystemColors.ActiveCaption;
            dgvNotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotas.Location = new Point(12, 45);
            dgvNotas.MultiSelect = false;
            dgvNotas.Name = "dgvNotas";
            dgvNotas.ReadOnly = true;
            dgvNotas.RowHeadersWidth = 51;
            dgvNotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotas.Size = new Size(760, 363);
            dgvNotas.TabIndex = 0;
            dgvNotas.DoubleClick += btnEditarNota_Click;
            // 
            // btnNovaNota
            // 
            btnNovaNota.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNovaNota.Location = new Point(29, 414);
            btnNovaNota.Name = "btnNovaNota";
            btnNovaNota.Size = new Size(100, 74);
            btnNovaNota.TabIndex = 1;
            btnNovaNota.Text = "Nova Nota";
            btnNovaNota.UseVisualStyleBackColor = true;
            btnNovaNota.Click += btnNovaNota_Click;
            // 
            // btnEditarNota
            // 
            btnEditarNota.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditarNota.Location = new Point(177, 414);
            btnEditarNota.Name = "btnEditarNota";
            btnEditarNota.Size = new Size(100, 74);
            btnEditarNota.TabIndex = 2;
            btnEditarNota.Text = "Editar Nota";
            btnEditarNota.UseVisualStyleBackColor = true;
            btnEditarNota.Click += btnEditarNota_Click;
            // 
            // btnExcluirNota
            // 
            btnExcluirNota.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExcluirNota.Location = new Point(523, 414);
            btnExcluirNota.Name = "btnExcluirNota";
            btnExcluirNota.Size = new Size(100, 74);
            btnExcluirNota.TabIndex = 3;
            btnExcluirNota.Text = "Excluir Nota";
            btnExcluirNota.UseVisualStyleBackColor = true;
            btnExcluirNota.Click += btnExcluirNota_Click;
            // 
            // btnAtualizarLista
            // 
            btnAtualizarLista.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAtualizarLista.Location = new Point(655, 414);
            btnAtualizarLista.Name = "btnAtualizarLista";
            btnAtualizarLista.Size = new Size(100, 74);
            btnAtualizarLista.TabIndex = 4;
            btnAtualizarLista.Text = "Atualizar";
            btnAtualizarLista.UseVisualStyleBackColor = true;
            btnAtualizarLista.Click += btnAtualizarLista_Click;
            // 
            // lblUsuarioInfo
            // 
            lblUsuarioInfo.AutoSize = true;
            lblUsuarioInfo.Location = new Point(12, 9);
            lblUsuarioInfo.Name = "lblUsuarioInfo";
            lblUsuarioInfo.Size = new Size(117, 20);
            lblUsuarioInfo.TabIndex = 5;
            lblUsuarioInfo.Text = "Usuário: [Nome]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(315, 7);
            label1.Name = "label1";
            label1.Size = new Size(173, 20);
            label1.TabIndex = 6;
            label1.Text = "Bem vindo de volta!! >.<";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Window;
            groupBox1.Location = new Point(-3, -7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(803, 176);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.adf6369919ab63c0bba99d9b80752629;
            pictureBox1.Location = new Point(635, 228);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(137, 180);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // FormPrincipal
            // 
            BackColor = Color.Pink;
            ClientSize = new Size(784, 518);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(lblUsuarioInfo);
            Controls.Add(btnAtualizarLista);
            Controls.Add(btnExcluirNota);
            Controls.Add(btnEditarNota);
            Controls.Add(btnNovaNota);
            Controls.Add(dgvNotas);
            Controls.Add(groupBox1);
            MinimumSize = new Size(600, 300);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bloco de Notas - CRUD";
            FormClosed += FormPrincipal_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dgvNotas).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.DataGridView dgvNotas;
        private System.Windows.Forms.Button btnNovaNota;
        private System.Windows.Forms.Button btnEditarNota;
        private System.Windows.Forms.Button btnExcluirNota;
        private System.Windows.Forms.Button btnAtualizarLista;
        private System.Windows.Forms.Label lblUsuarioInfo;
        private Label label1;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
    }
}