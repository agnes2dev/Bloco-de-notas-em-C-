using System.Diagnostics;

namespace crud_completo
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    partial class FormSplash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Timer splashTimer;

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
            components = new System.ComponentModel.Container();
            lblAppName = new Label();
            lblLoading = new Label();
            splashTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.SteelBlue;
            lblAppName.Location = new Point(16, 46);
            lblAppName.Margin = new Padding(4, 0, 4, 0);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(421, 46);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "CUTE (CRUD) notes >.<";
            lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLoading
            // 
            lblLoading.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLoading.ForeColor = Color.DimGray;
            lblLoading.Location = new Point(16, 123);
            lblLoading.Margin = new Padding(4, 0, 4, 0);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(421, 35);
            lblLoading.TabIndex = 1;
            lblLoading.Text = "Carregando...";
            lblLoading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splashTimer
            // 
            splashTimer.Interval = 3000;
            splashTimer.Tick += SplashTimer_Tick;
            // 
            // FormSplash
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(447, 247);
            Controls.Add(lblLoading);
            Controls.Add(lblAppName);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormSplash";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSplash";
            ResumeLayout(false);

        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        #endregion
    }
}