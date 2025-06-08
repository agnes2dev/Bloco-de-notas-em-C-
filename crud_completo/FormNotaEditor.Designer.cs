namespace crud_completo
{
    partial class FormNotaEditor
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
            lblTituloEditor = new Label();
            txtTituloEditor = new TextBox();
            lblConteudoEditor = new Label();
            txtConteudoEditor = new TextBox();
            btnSalvarNota = new Button();
            btnCancelarNota = new Button();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // lblTituloEditor
            // 
            lblTituloEditor.AutoSize = true;
            lblTituloEditor.BackColor = SystemColors.ControlLightLight;
            lblTituloEditor.Location = new Point(29, 21);
            lblTituloEditor.Margin = new Padding(4, 0, 4, 0);
            lblTituloEditor.Name = "lblTituloEditor";
            lblTituloEditor.Size = new Size(50, 20);
            lblTituloEditor.TabIndex = 4;
            lblTituloEditor.Text = "Título:";
            // 
            // txtTituloEditor
            // 
            txtTituloEditor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTituloEditor.Location = new Point(93, 18);
            txtTituloEditor.Margin = new Padding(4, 5, 4, 5);
            txtTituloEditor.Name = "txtTituloEditor";
            txtTituloEditor.Size = new Size(638, 27);
            txtTituloEditor.TabIndex = 0;
            // 
            // lblConteudoEditor
            // 
            lblConteudoEditor.AutoSize = true;
            lblConteudoEditor.BackColor = SystemColors.Window;
            lblConteudoEditor.Location = new Point(225, 50);
            lblConteudoEditor.Margin = new Padding(4, 0, 4, 0);
            lblConteudoEditor.Name = "lblConteudoEditor";
            lblConteudoEditor.Size = new Size(77, 20);
            lblConteudoEditor.TabIndex = 5;
            lblConteudoEditor.Text = "Conteúdo:";
            // 
            // txtConteudoEditor
            // 
            txtConteudoEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtConteudoEditor.Location = new Point(225, 81);
            txtConteudoEditor.Margin = new Padding(4, 5, 4, 5);
            txtConteudoEditor.Multiline = true;
            txtConteudoEditor.Name = "txtConteudoEditor";
            txtConteudoEditor.ScrollBars = ScrollBars.Vertical;
            txtConteudoEditor.Size = new Size(511, 288);
            txtConteudoEditor.TabIndex = 1;
            // 
            // btnSalvarNota
            // 
            btnSalvarNota.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvarNota.Location = new Point(502, 379);
            btnSalvarNota.Margin = new Padding(4, 5, 4, 5);
            btnSalvarNota.Name = "btnSalvarNota";
            btnSalvarNota.Size = new Size(113, 68);
            btnSalvarNota.TabIndex = 2;
            btnSalvarNota.Text = "Salvar";
            btnSalvarNota.UseVisualStyleBackColor = true;
            btnSalvarNota.Click += btnSalvarNota_Click;
            // 
            // btnCancelarNota
            // 
            btnCancelarNota.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelarNota.DialogResult = DialogResult.Cancel;
            btnCancelarNota.Location = new Point(636, 379);
            btnCancelarNota.Margin = new Padding(4, 5, 4, 5);
            btnCancelarNota.Name = "btnCancelarNota";
            btnCancelarNota.Size = new Size(100, 68);
            btnCancelarNota.TabIndex = 3;
            btnCancelarNota.Text = "Cancelar";
            btnCancelarNota.UseVisualStyleBackColor = true;
            btnCancelarNota.Click += btnCancelarNota_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 413);
            label1.Name = "label1";
            label1.Size = new Size(186, 20);
            label1.TabIndex = 6;
            label1.Text = "Tente escrever uma nota! :)";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources._4281e72685d53347fd41e54478969beb;
            pictureBox3.Location = new Point(12, 81);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(191, 288);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // FormNotaEditor
            // 
            AcceptButton = btnSalvarNota;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Pink;
            CancelButton = btnCancelarNota;
            ClientSize = new Size(749, 461);
            Controls.Add(pictureBox3);
            Controls.Add(label1);
            Controls.Add(btnCancelarNota);
            Controls.Add(btnSalvarNota);
            Controls.Add(txtConteudoEditor);
            Controls.Add(lblConteudoEditor);
            Controls.Add(txtTituloEditor);
            Controls.Add(lblTituloEditor);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(421, 359);
            Name = "FormNotaEditor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editor de Nota";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblTituloEditor;
        private System.Windows.Forms.TextBox txtTituloEditor;
        private System.Windows.Forms.Label lblConteudoEditor;
        private System.Windows.Forms.TextBox txtConteudoEditor;
        private System.Windows.Forms.Button btnSalvarNota;
        private System.Windows.Forms.Button btnCancelarNota;
        private Label label1;
        private PictureBox pictureBox3;
    }
}