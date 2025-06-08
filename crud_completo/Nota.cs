namespace crud_completo
{
    public class Nota
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string DataCriacao { get; set; }
        public string DataModificacao { get; set; }
        public int UsuarioId { get; set; }

       
        public Nota() { }

     
        public Nota(int id, string titulo, string conteudo, string dataCriacao, string dataModificacao, int usuarioId)
        {
            Id = id;
            Titulo = titulo;
            Conteudo = conteudo;
            DataCriacao = dataCriacao;
            DataModificacao = dataModificacao;
            UsuarioId = usuarioId;
        }
    }
}