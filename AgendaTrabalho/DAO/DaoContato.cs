using AgendaContato.Model;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace AgendaContato.DAO
{
    public class DaoContato : ConexaoBancoMySql
    {
                public void Salvar(Contato contato)
        {

            try
            {

                MySqlConnection conn = new ConexaoBancoMySql().getConnection();
                conn = new MySqlConnection(connectionString);
                String insertDados = "INSERT INTO contato(nome, telefone)" +
                    "VALUES (?,?);";
                conn.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(insertDados, conn);
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("nome", contato.nome));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("telefone", contato.telefone));


                cmd.Prepare();

                cmd.ExecuteNonQuery();

                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar contato, verifique a conexão com o banco de dados: " + ex.ToString());

            }
        }


        public List<Contato> BuscarTodos(Contato contato)
        {
            List<Contato> todos = new List<Contato>();
            MySqlConnection conn = new ConexaoBancoMySql().getConnection();
            conn = new MySqlConnection(connectionString);
            String selecionaTodos = "select id, nome, telefone from contato ";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(selecionaTodos, conn);

            try
            {

                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Contato novo = new Contato();


                    novo.id = (int)reader["id"];
                    novo.nome = reader["nome"].ToString();
                    novo.telefone = reader["telefone"].ToString();
                    todos.Add(novo);


                }

                conn.Close();
                return todos;
            }
            finally
            {
                conn.Close();
            }
        }

       
    }
}
