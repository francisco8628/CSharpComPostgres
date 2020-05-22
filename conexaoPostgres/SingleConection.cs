using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace conexaoComDB.conexaoPostgres

{
    class SingleConection
    {
        NpgsqlConnection conexao = new NpgsqlConnection();  //instancia uma conexão o banco postgres

        public SingleConection()//construtor com a string de conexão com o banco
        {
            conexao.ConnectionString = @"Server=localhost;Port=5432;Database=posjava;User Id=postgres;Password=admin;";
        }
        public NpgsqlConnection Conectar() //metodo conects
        {
            if (conexao.State == System.Data.ConnectionState.Closed) //se tiver fechada a conexão
            {
                conexao.Open();// abre a conexão
            }

            return conexao; //retorna a conexão
        }
        public void Desconctar()//desconecta do banco
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
