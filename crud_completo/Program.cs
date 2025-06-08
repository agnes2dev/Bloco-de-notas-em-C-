using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace crud_completo
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                databaseconect.InitializeDatabase();
                Debug.WriteLine("[Program] Banco de dados inicializado com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha cr�tica ao inicializar o banco de dados: {ex.Message}\nA aplica��o ser� encerrada.",
                                "Erro de Inicializa��o", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"[Program] ERRO em InitializeDatabase(): {ex.ToString()}");
                return;
            }

    
            Application.Run(new FormSplash());
   
        }
    }
}