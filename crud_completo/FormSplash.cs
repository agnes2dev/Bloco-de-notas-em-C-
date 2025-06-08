using System;

using System.Windows.Forms;

namespace crud_completo
{
    public partial class FormSplash : Form 
    {
        private bool loginLaunched = false;

        public FormSplash()
        {
            InitializeComponent(); 

         
            this.splashTimer.Start();
        }

        private void SplashTimer_Tick(object sender, EventArgs e)
        {
            splashTimer.Stop();

            if (loginLaunched)
                return;

            loginLaunched = true;

            this.Hide();

            FormLogin loginForm = new FormLogin();
            loginForm.ShowDialog(); 

            this.Close();
        }
    }
}