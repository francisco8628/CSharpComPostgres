using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using conexaoComDB.model;
using conexaoComDB.conexaoPostgres;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data; /* Add this Namespace */
namespace conexaoComDB.dao
{
    class UserDao
    {
        SingleConection conexao = new SingleConection();
        string menssagem;
        public UserCsharp Salvar(UserCsharp userCharp)
        {
            UserCsharp user = new UserCsharp();
            NpgsqlCommand inseirUsuario = new NpgsqlCommand();

            try
            {
                inseirUsuario.CommandText = "INSERT INTO userposjava(nome,email)values(@nome, @email) ";
                inseirUsuario.Parameters.AddWithValue(" @nome", userCharp.getNome());
                inseirUsuario.Parameters.AddWithValue(" @email", userCharp.getEmail());
                //conectar
                try
                {
                    inseirUsuario.Connection = conexao.Conectar(); //abre a conexão

                    inseirUsuario.ExecuteNonQuery();              //executar 

                    conexao.Desconctar();                   //desconecta

                    this.menssagem = "Cadastrado com sucesso";
                }
                catch (SqlException)
                {
                    this.menssagem = "Erro de conexão";
                }

                conexao.Desconctar();
            }
            catch (Exception e)
            {
                this.menssagem = "nao conectou";
            }
            return user;
        }//fim salvar

        public UserCsharp Mostrar(long id) 
        {
            string nome;
            string email;
            bool erroId;
            string sql = "select * from userposjava where id = " + id;   //comandp select
            UserCsharp user = new UserCsharp();
            NpgsqlCommand comando = new NpgsqlCommand(sql,conexao.Conectar());
            comando.CommandType = CommandType.Text;
            NpgsqlDataReader reader;
            try
            {
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    erroId = false;
                    user.SetErroId(erroId);
                    nome = reader[1].ToString();
                    email = reader[2].ToString();
                    id = long.Parse(reader[0].ToString());

                    user.setNome(nome);
                    user.setEmail(email);
                }
                else
                {
                    erroId = true;
                    user.SetErroId(erroId);
                }

            }
            catch (Exception)
            {
                this.menssagem = "Este Id não existe";
            }
            return user;
        }//end mostrar
    }


}



