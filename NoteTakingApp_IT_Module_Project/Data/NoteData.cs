using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace NoteTakingApp_UI.Data
{
    class NoteData
    {
        //Template for SQL Commands from previous projects
        /*
        public List<NotesClass> GetAll()
        {
            var notesList = new List<NotesClass>();
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM notes", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                        while (reader.Read())
                        {
                            var note = new Note(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetDecimal(2),
                                reader.GetInt32(3)
                            );

                            notesList.Add(note);
                        }

                }
                connection.Close();
            }

            return notesList;
        }

        public Note Get(int id)
        {
            Note note = null;
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM notes WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        note = new Note(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetDecimal(2),
                                reader.GetInt32(3)
                        );
                    }
                }

                connection.Close();
            }

            return note;
        }

        public void Add(Note note)
        {
            using (var connection = Database.GetConnection()){
                var command = new MySqlCommand("INSERT INTO note (someAttributes) VALUES(@someAttributes)", connection);
                command.Parameters.AddWithValue("name", product.Name);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Note note)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("UPDATE product SET Name=@name,...  WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", note.Id);
                command.Parameters.AddWithValue("name", note.Name);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public void Delete(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("DELETE note WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
        */
    }
}
