using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace crud_completo
{
    public partial class FormPrincipal : Form 
    {
        private Usuario _usuarioLogado;
      

        public FormPrincipal(Usuario usuarioLogado)
        {
            _usuarioLogado = usuarioLogado;
            InitializeComponent();
            lblUsuarioInfo.Text = $"Usuário: {_usuarioLogado.NomeCompleto} ({_usuarioLogado.NomeUsuario})";
            CarregarNotas();
        }

        private void CarregarNotas()
        {
            try
            {
                List<NotaDisplayItem> notas = databaseconect.GetAllNotasComNomesDeUsuario(); 
                dgvNotas.DataSource = null;
                dgvNotas.DataSource = notas;

                if (dgvNotas.Columns.Count > 0)
                {
                    if (dgvNotas.Columns["Id"] != null) dgvNotas.Columns["Id"].Visible = false;
                    if (dgvNotas.Columns["UsuarioId"] != null) dgvNotas.Columns["UsuarioId"].Visible = false;

                    if (dgvNotas.Columns["Titulo"] != null) dgvNotas.Columns["Titulo"].HeaderText = "Título";
                    if (dgvNotas.Columns["DataCriacao"] != null) dgvNotas.Columns["DataCriacao"].HeaderText = "Criação";
                    if (dgvNotas.Columns["DataModificacao"] != null) dgvNotas.Columns["DataModificacao"].HeaderText = "Modificação";
                    if (dgvNotas.Columns["NomeUsuario"] != null) dgvNotas.Columns["NomeUsuario"].HeaderText = "Autor";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar notas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovaNota_Click(object sender, EventArgs e)
        {
            using (FormNotaEditor formEditor = new FormNotaEditor(_usuarioLogado.Id))
            {
                if (formEditor.ShowDialog(this) == DialogResult.OK)
                {
                    CarregarNotas();
                }
            }
        }

        private void btnEditarNota_Click(object sender, EventArgs e)
        {
            if (dgvNotas.CurrentRow == null || dgvNotas.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Selecione uma nota para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            NotaDisplayItem notaSelecionada = (NotaDisplayItem)dgvNotas.CurrentRow.DataBoundItem;
            using (FormNotaEditor formEditor = new FormNotaEditor(_usuarioLogado.Id, notaSelecionada.Id))
            {
                if (formEditor.ShowDialog(this) == DialogResult.OK)
                {
                    CarregarNotas();
                }
            }
        }

        private void btnExcluirNota_Click(object sender, EventArgs e)
        {
            if (dgvNotas.CurrentRow == null || dgvNotas.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Selecione uma nota para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            NotaDisplayItem notaSelecionada = (NotaDisplayItem)dgvNotas.CurrentRow.DataBoundItem;

            DialogResult confirmacao = MessageBox.Show($"Tem certeza que deseja excluir a nota '{notaSelecionada.Titulo}'?",
                                                      "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    if (databaseconect.DeleteNota(notaSelecionada.Id)) 
                    {
                      
                        CarregarNotas();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível excluir a nota.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir nota: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAtualizarLista_Click(object sender, EventArgs e)
        {
            CarregarNotas();
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}