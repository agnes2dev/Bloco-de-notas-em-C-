using System;
using System.Drawing; 
using System.Windows.Forms;

namespace crud_completo
{
    public partial class FormLogin : Form 
    {


        public FormLogin()
        {
            InitializeComponent(); 

        
            try
            {
                var usuarios = databaseconect.GetAllUsuariosSimple(); 
                if (usuarios.Count == 0)
                {
                    lblInfo.Text = "Nenhum usuário. Verifique a inicialização do DB.";
                    lblInfo.ForeColor = Color.Red;
                }
                else if (usuarios.Exists(u => u.NomeUsuario == "admin"))
                {
                    lblInfo.Text = "Padrão: admin / admin123";
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Erro ao carregar usuários.";
                lblInfo.ForeColor = Color.Red;
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar usuários para FormLogin: {ex.Message}");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nomeUsuario = txtUsuario.Text.Trim();
            string senha = txtSenha.Text;

            if (string.IsNullOrWhiteSpace(nomeUsuario) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha usuário e senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usuarioLogado = databaseconect.AutenticarUsuario(nomeUsuario, senha); 

            if (usuarioLogado != null)
            {
              
                FormPrincipal formPrincipal = new FormPrincipal(usuarioLogado);
                this.Hide();
                formPrincipal.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.", "Falha no Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Clear();
                txtUsuario.Focus();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}