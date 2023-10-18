﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Tarefas
{
    public class AgendamentoRepository
    {
        private readonly string connectionString;

        public AgendamentoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Atividade> ObterTodasAtividades()
        {
            List<Atividade> atividades = new List<Atividade>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Atividades";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Atividade atividade = new Atividade
                            {
                                id = Convert.ToInt32(reader["ID"]),
                                nome = reader["Nome"].ToString(),
                                descricao = reader["Descricao"].ToString(),
                                prazo = Convert.ToDateTime(reader["Data"]),
                                situacao = Convert.ToInt32(reader["Concluida"])
                            };

                            atividades.Add(atividade);
                        }
                    }
                }
            }

            return atividades;
        }

        public void AdicionarAtividade(Atividade atividade)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Atividades (Nome, Descricao, Data, situacao) VALUES (@Nome, @Descricao, @Data, @situacao)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", atividade.nome);
                    command.Parameters.AddWithValue("@Descricao", atividade.descricao);
                    command.Parameters.AddWithValue("@Data", atividade.prazo);
                    command.Parameters.AddWithValue("@situacao", atividade.situacao);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditarAtividade(Atividade atividade)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Atividades SET Nome = @Nome, Descricao = @Descricao, Data = @Data, Concluida = @Concluida WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", atividade.id);
                    command.Parameters.AddWithValue("@Nome", atividade.nome);
                    command.Parameters.AddWithValue("@Descricao", atividade.descricao);
                    command.Parameters.AddWithValue("@Data", atividade.prazo);
                    command.Parameters.AddWithValue("@Concluida", atividade.situacao);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ExcluirAtividade(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Atividades WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}