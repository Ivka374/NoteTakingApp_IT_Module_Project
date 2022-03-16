using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using NoteTakingApp_UI.Models;

namespace NoteTakingApp_UI.Data
{
    class NoteData
    {
        //Commands were written in a separate file so i can test them more easily, that's why it shows that i changed the entire class
        //Kendrick Lamar - untested unfinished.

        public List<NoteModel> GetAll()
        {
            var noteList = new List<NoteModel>();
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM notemodel", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var note = new NoteModel(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetBoolean(3),
                            reader.GetString(4)
                        );

                        noteList.Add(note);
                    }

                }
                connection.Close();
            }

            return noteList;
        }

        public NoteModel Get(string title)
        {
            NoteModel note = null;
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM notemodel WHERE notetitle=@title", connection);
                command.Parameters.AddWithValue("notetitle", title);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        note = new NoteModel(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetBoolean(3),
                            reader.GetString(4)
                        );
                    }
                }

                connection.Close();
            }

            return note;
        }

        public void Add(NoteModel note)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("INSERT INTO notemodel (notetitle, notecontent, noteisfav, notetheme) VALUES(@notetitle, @notecontent, @noteisfav, @notetheme)", connection);
                command.Parameters.AddWithValue("notetitle", note.Title);
                command.Parameters.AddWithValue("notecontent", note.Content.TextContent);
                command.Parameters.AddWithValue("noteisfav", note.IsFavourite);
                command.Parameters.AddWithValue("notetheme", note.ThemeName);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                foreach (var tag in note.NoteTags)
                {
                    this.AddTag(tag, note);
                }
            }
        }

        public void AddTag(TagModel tag, NoteModel note)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("INSERT INTO tagmodel (tagname, tagcolor, noteid) VALUES(@tagname, @tagcolor, @noteid)", connection);
                command.Parameters.AddWithValue("tagname", tag.Name);
                command.Parameters.AddWithValue("tagcolor", tag.Colour);
                command.Parameters.AddWithValue("noteid", note.ID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(NoteModel note)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("UPDATE notemodel SET notetitle=@notetitle, notecontent=@notecontent, noteisfav=@noteisfav, notethemename=@notethemename WHERE noteid=@id", connection);
                command.Parameters.AddWithValue("id", note.ID);
                command.Parameters.AddWithValue("notetitle", note.Title);
                command.Parameters.AddWithValue("notecontent", note.Content);
                command.Parameters.AddWithValue("noteisfav", note.IsFavourite);
                command.Parameters.AddWithValue("notethemename", note.ThemeName);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public void UpdateTag(TagModel tag, NoteModel note)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("UPDATE tagmodel SET tagname=@tagname, tagcolor=@tagcolor WHERE noteid=@noteid", connection);
                command.Parameters.AddWithValue("tagname", tag.Name);
                command.Parameters.AddWithValue("tagcolor", tag.Colour);
                command.Parameters.AddWithValue("noteid", note.ID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("DELETE product WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}
