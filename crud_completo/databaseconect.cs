using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;

namespace crud_completo
{
    public static class databaseconect
    {
        private static readonly string _databaseFileName = "crud_notas.db"; // Nome do arquivo do banco
        private static readonly string _databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databaseFileName);
        private static readonly string _connectionString = $"Data Source={_databasePath};Version=3;Foreign Keys=True;";

        public static string ConnectionString => _connectionString;
        public static string DatabasePath => _databasePath;

        public static void InitializeDatabase()
        {
            Debug.WriteLine($"[DB] Tentando inicializar banco: {_databasePath}");
            if (!File.Exists(_databasePath))
            {
                SQLiteConnection.CreateFile(_databasePath);
                Debug.WriteLine($"[DB] Arquivo criado: {_databasePath}");
            }

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                Debug.WriteLine("[DB] Conexão aberta para inicialização.");

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string sqlUsuarios = @"
                        CREATE TABLE IF NOT EXISTS Usuarios (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nome TEXT NOT NULL,
                            Sobrenome TEXT NOT NULL,
                            Usuario TEXT NOT NULL UNIQUE,
                            SenhaHash TEXT NOT NULL,
                            Salt TEXT NOT NULL,
                            DataCadastro TEXT NOT NULL
                        )";
                        new SQLiteCommand(sqlUsuarios, connection, transaction).ExecuteNonQuery();
                        Debug.WriteLine("[DB] Tabela Usuarios verificada/criada.");

                        string sqlNotas = @"
                        CREATE TABLE IF NOT EXISTS Notas (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Titulo TEXT NOT NULL,
                            Conteudo TEXT NOT NULL,
                            DataCriacao TEXT NOT NULL,
                            DataModificacao TEXT,
                            UsuarioId INTEGER NOT NULL,
                            FOREIGN KEY(UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE
                        )";
                        new SQLiteCommand(sqlNotas, connection, transaction).ExecuteNonQuery();
                        Debug.WriteLine("[DB] Tabela Notas verificada/criada.");

                        // Adicionar um usuário padrão se a tabela estiver vazia
                        string countUsersSql = "SELECT COUNT(*) FROM Usuarios";
                        using (var cmdCount = new SQLiteCommand(countUsersSql, connection, transaction))
                        {
                            long userCount = (long)cmdCount.ExecuteScalar();
                            if (userCount == 0)
                            {
                                Debug.WriteLine("[DB] Nenhum usuário encontrado. Criando usuário padrão 'admin'.");
                                var (hash, salt) = PasswordHasher.HashPassword("admin123");
                                string sqlAdmin = @"INSERT INTO Usuarios (Nome, Sobrenome, Usuario, SenhaHash, Salt, DataCadastro)
                                                  VALUES ('Admin', 'User', 'admin', @SenhaHash, @Salt, @DataCadastro)";
                                using (var cmdAdmin = new SQLiteCommand(sqlAdmin, connection, transaction))
                                {
                                    cmdAdmin.Parameters.AddWithValue("@SenhaHash", hash);
                                    cmdAdmin.Parameters.AddWithValue("@Salt", salt);
                                    cmdAdmin.Parameters.AddWithValue("@DataCadastro", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    cmdAdmin.ExecuteNonQuery();
                                    Debug.WriteLine("[DB] Usuário 'admin' criado com senha 'admin123'.");
                                }
                            }
                        }
                        transaction.Commit();
                        Debug.WriteLine("[DB] Transação de inicialização commitada.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Debug.WriteLine($"[DB] ERRO na transação de inicialização: {ex.ToString()}");
                        throw;
                    }
                }
            }
            Debug.WriteLine("[DB] InitializeDatabase concluído.");
        }

        // --- Métodos de Usuário ---
        public static Usuario AutenticarUsuario(string nomeUsuario, string senha)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, Nome, Sobrenome, Usuario, SenhaHash, Salt FROM Usuarios WHERE Usuario = @Usuario";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Usuario", nomeUsuario);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["SenhaHash"].ToString();
                            string storedSalt = reader["Salt"].ToString();
                            if (PasswordHasher.VerifyPassword(senha, storedHash, storedSalt))
                            {
                                return new Usuario(
                                    Convert.ToInt32(reader["Id"]),
                                    $"{reader["Nome"]} {reader["Sobrenome"]}",
                                    reader["Usuario"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            return null; // Falha na autenticação
        }

        public static List<Usuario> GetAllUsuariosSimple()
        {
            var usuarios = new List<Usuario>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, Nome, Sobrenome, Usuario FROM Usuarios ORDER BY Nome, Sobrenome";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuario(
                                Convert.ToInt32(reader["Id"]),
                                $"{reader["Nome"]} {reader["Sobrenome"]}",
                                reader["Usuario"].ToString()
                            ));
                        }
                    }
                }
            }
            return usuarios;
        }


        // --- Métodos de Notas ---
        public static List<NotaDisplayItem> GetAllNotasComNomesDeUsuario()
        {
            var notas = new List<NotaDisplayItem>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string sql = @"SELECT n.Id, n.Titulo, n.DataCriacao, n.DataModificacao, u.Nome || ' ' || u.Sobrenome AS NomeUsuario, n.UsuarioId
                               FROM Notas n
                               JOIN Usuarios u ON n.UsuarioId = u.Id
                               ORDER BY n.DataModificacao DESC, n.DataCriacao DESC";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notas.Add(new NotaDisplayItem
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Titulo = reader["Titulo"].ToString(),
                                DataCriacao = reader["DataCriacao"].ToString(),
                                DataModificacao = reader["DataModificacao"]?.ToString() ?? string.Empty,
                                NomeUsuario = reader["NomeUsuario"].ToString(),
                                UsuarioId = Convert.ToInt32(reader["UsuarioId"])
                            });
                        }
                    }
                }
            }
            return notas;
        }

        public static Nota GetNotaById(int notaId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, Titulo, Conteudo, DataCriacao, DataModificacao, UsuarioId FROM Notas WHERE Id = @Id";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", notaId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Nota
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Titulo = reader["Titulo"].ToString(),
                                Conteudo = reader["Conteudo"].ToString(),
                                DataCriacao = reader["DataCriacao"].ToString(),
                                DataModificacao = reader["DataModificacao"]?.ToString(),
                                UsuarioId = Convert.ToInt32(reader["UsuarioId"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static bool AddNota(Nota nota)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string sql = @"INSERT INTO Notas (Titulo, Conteudo, DataCriacao, DataModificacao, UsuarioId)
                               VALUES (@Titulo, @Conteudo, @DataCriacao, @DataModificacao, @UsuarioId)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Titulo", nota.Titulo);
                    command.Parameters.AddWithValue("@Conteudo", nota.Conteudo);
                    command.Parameters.AddWithValue("@DataCriacao", nota.DataCriacao);
                    command.Parameters.AddWithValue("@DataModificacao", nota.DataModificacao);
                    command.Parameters.AddWithValue("@UsuarioId", nota.UsuarioId);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool UpdateNota(Nota nota)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string sql = @"UPDATE Notas SET Titulo = @Titulo, Conteudo = @Conteudo, DataModificacao = @DataModificacao
                               WHERE Id = @Id";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Titulo", nota.Titulo);
                    command.Parameters.AddWithValue("@Conteudo", nota.Conteudo);
                    command.Parameters.AddWithValue("@DataModificacao", nota.DataModificacao);
                    command.Parameters.AddWithValue("@Id", nota.Id);
                    // UsuarioId e DataCriacao não são alterados na atualização da nota
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeleteNota(int notaId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Notas WHERE Id = @Id";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", notaId);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}