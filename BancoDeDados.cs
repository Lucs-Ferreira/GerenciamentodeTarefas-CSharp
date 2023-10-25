using System;
using System.Collections.Generic;
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

            using (Microsoft.Data.Sqlite.SqliteConnection connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString))
            {
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

                connection.Open();

                string query = "SELECT * FROM atividades";
                using (Microsoft.Data.Sqlite.SqliteCommand command = new Microsoft.Data.Sqlite.SqliteCommand(query, connection))
                {
                    using (Microsoft.Data.Sqlite.SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Atividade atividade = new Atividade
                            {
                                id = Convert.ToInt32(reader["id"]),
                                nome = reader["nome"].ToString(),
                                descricao = reader["descricao"].ToString(),
                                prazo = Convert.ToDateTime(reader["prazo"])
                            };

                            if (int.TryParse(reader["situacao"].ToString(), out int situacao))
                            {
                                atividade.situacao = situacao;
                            }
                            else
                            {
                                // Trate o caso em que o valor não pôde ser convertido para int.
                                // Por exemplo, defina um valor padrão, como 0.
                                atividade.situacao = 0;
                            }

                            atividades.Add(atividade);
                        }
                    }
                }
            }

            return atividades;
        }

        public void AdicionarAtividade(Atividade atividade)
        {
            using (Microsoft.Data.Sqlite.SqliteConnection connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString))
            {
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

                connection.Open();

                string query = "INSERT INTO atividades (nome, descricao, prazo, situacao) VALUES (@Nome, @Descricao, @Prazo, @situacao)";
                using (Microsoft.Data.Sqlite.SqliteCommand command = new Microsoft.Data.Sqlite.SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", atividade.nome);
                    command.Parameters.AddWithValue("@Descricao", atividade.descricao);
                    command.Parameters.AddWithValue("@Prazo", atividade.prazo);
                    command.Parameters.AddWithValue("@situacao", atividade.situacao);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditarAtividade(Atividade atividade)
        {
            using (Microsoft.Data.Sqlite.SqliteConnection connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString))
            {
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

                connection.Open();

                string query = "UPDATE atividades SET nome = @Nome, descricao = @Descricao, prazo = @Prazo, situacao = @Concluida WHERE id = @ID";
                using (Microsoft.Data.Sqlite.SqliteCommand command = new Microsoft.Data.Sqlite.SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", atividade.id);
                    command.Parameters.AddWithValue("@Nome", atividade.nome);
                    command.Parameters.AddWithValue("@Descricao", atividade.descricao);
                    command.Parameters.AddWithValue("@Prazo", atividade.prazo);
                    command.Parameters.AddWithValue("@Concluida", atividade.situacao);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ExcluirAtividade(int id)
        {
            using (Microsoft.Data.Sqlite.SqliteConnection connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString))
            {
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

                connection.Open();

                string query = "DELETE FROM atividades WHERE id = @ID";
                using (Microsoft.Data.Sqlite.SqliteCommand command = new Microsoft.Data.Sqlite.SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}