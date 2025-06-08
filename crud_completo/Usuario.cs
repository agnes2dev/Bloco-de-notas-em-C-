namespace crud_completo
{
    public class Usuario 
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeUsuario { get; set; }

        public Usuario(int id, string nomeCompleto, string nomeUsuario)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            NomeUsuario = nomeUsuario;
        }

    }
}