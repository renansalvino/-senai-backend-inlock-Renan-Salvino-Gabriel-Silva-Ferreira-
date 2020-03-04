using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=OFF-WHITE\\SQLEXPRESS; initial catalog=Inlock_Games_Tarde; integrated security=true;";

        public void Atualizar(int id, JogoDomain JogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdate = "UPDATE Jogo " +
                                    "SET NomeJogo = @NomeJogo, Descricao = @Descricao, DataLancamento = @DataLancamento, Valor = @Valor " +
                                    "WHERE IdJogo = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", JogoAtualizado.NomeJogo);
                    cmd.Parameters.AddWithValue("@Sobrenome", JogoAtualizado.Descricao);
                    cmd.Parameters.AddWithValue("@DataNascimento", JogoAtualizado.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", JogoAtualizado.Valor);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Define a query a ser executada no banco
                string querySelect = "SELECT IdJogo, NomeJogo, Descricao,DataLancamento,Valor" +
                                     "WHERE IdJogo = @ID";

                // Define o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define o valor dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Instancia um objeto usuario 
                        JogoDomain jogo = new JogoDomain
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdJogo = Convert.ToInt32(rdr["IdJogo"])
                            ,
                            Descricao = rdr["Descricao"].ToString()
                            ,
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"])
                            ,
                            Valor = rdr["Valor"].ToString()
                        };

                        // Retorna o jogo buscado
                        return jogo;
                    }
                }

                // Caso não encontre um email e senha correspondente, retorna null
                return null;
            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO Jogo(NomeJogo,Descricao,DataLancamento,Valor)" +
                                         "VALUES (@NomeJogo, @Descricao, @DataLancamento, @Valor)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Sobrenome", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @ID";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
        

        public List<JogoDomain> Listar()
        {
            var listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT Jogo.NomeJogo, Estudio.NomeEstudio, Jogo.Valor, Jogo.Descricao, Jogo.DataLancamento FROM Jogo INNER JOIN Estudio ON Estudio.IdEstudio = Jogo.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var jogo = new JogoDomain
                        {
                            NomeJogo = rdr["NomeJogo"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"].ToString()),
                            Valor = rdr["Valor"].ToString(),
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };
                        listaJogos.Add(jogo);
                    }
                }
                return listaJogos;
            }
        }


           
        }
    }


