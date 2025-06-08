using System;
using System.Windows.Forms;


namespace crud_completo
{
    public partial class FormNotaEditor : Form 
    {
        private readonly int _usuarioIdParaNovaNota;
        private int? _notaIdParaEditar;
        private Nota _notaCarregada;

     
        public FormNotaEditor(int usuarioIdLogado, int? notaId = null)
        {
            InitializeComponent(); 
            _usuarioIdParaNovaNota = usuarioIdLogado;
            _notaIdParaEditar = notaId;

            if (_notaIdParaEditar.HasValue)
            {
                this.Text = "Editar Nota";
                CarregarNotaParaEdicao(_notaIdParaEditar.Value);
            }
            else
            {
                this.Text = "Criar Nova Nota";
            }
        }

        private void CarregarNotaParaEdicao(int notaId)
        {
            try
            {
                _notaCarregada = databaseconect.GetNotaById(notaId);
                if (_notaCarregada != null)
                {
                    txtTituloEditor.Text = _notaCarregada.Titulo;
                    txtConteudoEditor.Text = _notaCarregada.Conteudo;
                }
                else
                {
                    MessageBox.Show("Nota não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel; 
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar nota: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnSalvarNota_Click(object sender, EventArgs e)
        {
            string titulo = txtTituloEditor.Text.Trim();
            string conteudo = txtConteudoEditor.Text.Trim();

            if (string.IsNullOrWhiteSpace(titulo))
            {
                MessageBox.Show("O título não pode estar vazio.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTituloEditor.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(conteudo))
            {
                MessageBox.Show("O conteúdo não pode estar vazio.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConteudoEditor.Focus();
                return;
            }

            string dataAgora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            bool sucesso = false;

            try
            {
                if (_notaIdParaEditar.HasValue)
                {
                    if (_notaCarregada == null)
                    {
                        MessageBox.Show("Erro: Tentando editar uma nota que não foi carregada.", "Erro Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Nota notaAtualizada = new Nota
                    {
                        Id = _notaCarregada.Id,
                        Titulo = titulo,
                        Conteudo = conteudo,
                        DataCriacao = _notaCarregada.DataCriacao,
                        DataModificacao = dataAgora,
                        UsuarioId = _notaCarregada.UsuarioId
                    };
                    sucesso = databaseconect.UpdateNota(notaAtualizada); 
                }
                else
                {
                    Nota novaNota = new Nota
                    {
                        Titulo = titulo,
                        Conteudo = conteudo,
                        DataCriacao = dataAgora,
                        DataModificacao = dataAgora,
                        UsuarioId = _usuarioIdParaNovaNota
                    };
                    sucesso = databaseconect.AddNota(novaNota); 
                }

                if (sucesso)
                {
                   
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Não foi possível salvar a nota.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar nota: {ex.Message}", "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarNota_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}