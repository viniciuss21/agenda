using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContato.DAO
{
    public class ConexaoBancoMySql
    {
        public MySqlConnection conn = null;
        public String connectionString = @"server=localhost;port = 3306; User Id = root; password=root;database=agenda_trabalho; SslMode = none";
        public MySqlConnection getConnection()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            Console.WriteLine("Cadastro Realizado com sucesso!");
            return conn;
        }
    }
}
