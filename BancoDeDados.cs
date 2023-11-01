using GerenciamentodeTarefas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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

        public void NovoUsuario(Usuarios u)
        {
            if (existeUsername(u))
            {
                MessageBox.Show("Username já existe!!");
                return;
            }
            try
            {
                using (Microsoft.Data.Sqlite.SqliteConnection connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString))
                {
                    SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

                    connection.Open();

                    string query = "INSERT INTO tb_usuarios (C_USERNAME, C_SENHA, C_ACESSO) VALUES (@username, @senha, @acesso)";
                    using (Microsoft.Data.Sqlite.SqliteCommand command = new Microsoft.Data.Sqlite.SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", u.cadastroUsername);
                        command.Parameters.AddWithValue("@senha", u.cadastroSenha);
                        command.Parameters.AddWithValue("@acesso", u.nivel);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Novo usuário inserido com sucesso!");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir dados de usuario " + ex.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool existeUsername(Usuarios u)
        {
            bool res = false;
            using (Microsoft.Data.Sqlite.SqliteConnection connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString))
            {
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

                connection.Open();

                string query = "SELECT C_USERNAME FROM tb_usuarios WHERE C_USERNAME = @Username";
                using (Microsoft.Data.Sqlite.SqliteCommand command = new Microsoft.Data.Sqlite.SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", u.cadastroUsername);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            res = true;
                        }
                    }
                }

                return res;
            }
        }

        public List<Usuarios> obterTodosUsuarios()
        {
            List<Usuarios> usuarios = new List<Usuarios>();

            try
            {
                using (Microsoft.Data.Sqlite.SqliteConnection connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString))
                {
                    SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

                    connection.Open();

                    string query = "SELECT * FROM tb_usuarios";
                    using (Microsoft.Data.Sqlite.SqliteCommand command = new Microsoft.Data.Sqlite.SqliteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Usuarios usuario = new Usuarios
                                {
                                    cadastroUsername = reader["C_USERNAME"].ToString(),
                                    cadastroSenha = reader["C_SENHA"].ToString()
                                };
                                usuarios.Add(usuario);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter dados do usuário " + ex.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return usuarios;
        }
        public DataTable Consulta(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Microsoft.Data.Sqlite.SqliteConnection connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString))
                {
                    SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

                    connection.Open();

                    string query = sql;
                    using (Microsoft.Data.Sqlite.SqliteCommand command = new Microsoft.Data.Sqlite.SqliteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            dt.Load(reader); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter dados da consulta: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

    }


}

