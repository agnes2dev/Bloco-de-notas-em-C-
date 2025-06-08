namespace crud_completo
{
    public class NotaDisplayItem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string DataCriacao { get; set; }
        public string DataModificacao { get; set; }
        public string NomeUsuario { get; set; } 
        public int UsuarioId { get; set; } 
    }
}