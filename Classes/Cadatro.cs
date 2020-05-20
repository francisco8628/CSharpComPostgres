using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace conexaoComDB.Classes
{
    class Cadatro
    {
        NpgsqlCommand comando = new NpgsqlCommand();

        Conexao conexao = new Conexao();

        public string mensagem;

        public Cadatro(String nome, String email)
        {
            try
            {
                //comando Sql insert - update -delete  --sqlocomand
                comando.CommandText= "INSERT INTO userposjava(nome,email)values(@nome, @email) ";
                //parametros
                comando.Parameters.AddWithValue(" @nome",nome);
                comando.Parameters.AddWithValue(" @email", email);
                //conectar
                try
                {
                    comando.Connection = conexao.Conectar(); //abre a conexão
                                              
                    comando.ExecuteNonQuery();              //executar 

                    conexao.Desconctar();                   //desconecta

                    this.mensagem = "Cadastrado com sucesso";


                }
                catch(SqlException )
                {
                    this.mensagem = "Erro de conexão";

                }
                          
                //desconetar
               
                conexao.Desconctar();
                //mostrar mensagem

                mensagem = "Cadastrado com sucesso";
            }
            catch (Exception e)
            {
                this.mensagem = "nao conectou";

            }

        }
    }
}
