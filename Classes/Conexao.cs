using System;
using System.Collections.Generic;
using System.Data.SqlClient;  // classen de conexao com banco de dados
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace conexaoComDB.Classes
{
    public class Conexao
    {
        NpgsqlConnection conexao = new NpgsqlConnection();

        public Conexao()
        {
         conexao.ConnectionString = @"Server=localhost;Port=5432;Database=posjava;User Id=postgres;Password=admin;";

        }  
        
        public NpgsqlConnection Conectar()
        {
            if(conexao.State == System.Data.ConnectionState.Closed)
            {
                conexao.Open();

            }

            return conexao; 
        }
       
         public void Desconctar()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();

            }

        }

    }
}

