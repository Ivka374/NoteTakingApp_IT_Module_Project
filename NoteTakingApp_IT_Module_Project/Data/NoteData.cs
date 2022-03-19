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
        //DB Commands for Three Tables approach
        //Everything has been tested except the CheckForDuplicate_ Methods

        public List<NoteModel> GetAllNotes() //returns a list with every note in the DB
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
                            reader.GetInt32(4)
                        );
                        note.NoteTags = GetTagsForNote(note.ID);

                        noteList.Add(note);
                    }

                }
                connection.Close();
            }

            return noteList;
        }

        public List<TagModel> GetAllTags() //returns a list with all tags in the db
        {
            var tagList = new List<TagModel>();
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM tagmodel", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tag = new TagModel(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            (ConsoleColor)reader.GetInt32(2)
                        );

                        tagList.Add(tag);
                    }

                }
                connection.Close();
            }

            return tagList;
        }

        public List<NoteModel> GetFavoriteNotes() //returns all notes labeled as 'favorite' (bool: IsFavorite == true)
        {
            var noteList = new List<NoteModel>();
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM notemodel WHERE noteisfav = 1", connection);
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
                            reader.GetInt32(4)
                        );
                        note.NoteTags = GetTagsForNote(note.ID);

                        noteList.Add(note);
                    }

                }
                connection.Close();
            }

            return noteList;
        }

        public NoteModel GetNoteByTitle(string title) //returns a note with the given title
        {
            NoteModel note = null;
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM notemodel WHERE notetitle=@notetitle", connection);
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
                            reader.GetInt32(4)
                        );
                        note.NoteTags = GetTagsForNote(note.ID);
                    }
                }

                connection.Close();
            }

            return note;
        }

        public NoteModel GetNoteById(int id) //returns a note with the given id
        {
            NoteModel note = null;
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM notemodel WHERE noteid=@noteid", connection);
                command.Parameters.AddWithValue("noteid", id);
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
                            reader.GetInt32(4)
                        );
                        note.NoteTags = GetTagsForNote(note.ID);
                    }
                }

                connection.Close();
            }

            return note;
        }

        public List<TagModel> GetTagsForNote(int id) //returns every tag for a note with the id 'int id'
        {
            List<TagModel> tagList = new List<TagModel>();
            TagModel tag = null;
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM tagtonote WHERE noteid=@noteid", connection);
                command.Parameters.AddWithValue("noteid", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int tagId = reader.GetInt32(1);
                        tag = GetTagById(tagId);
                        tagList.Add(tag);
                    }
                }

                connection.Close();
            }

            return tagList;
        }

        public List<NoteModel> GetNotesForTag(int id) //returns every note that has a tag with an id 'int id'
        {
            List<NoteModel> tagList = new List<NoteModel>();
            NoteModel note = null;
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM tagtonote WHERE tagid=@tagid", connection);
                command.Parameters.AddWithValue("tagid", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int noteId = reader.GetInt32(2);
                        note = GetNoteById(noteId);
                        tagList.Add(note);
                    }
                }

                connection.Close();
            }

            return tagList;
        }

        public TagModel GetTagById(int id) //returns a tag with an id 'int id'
        {
            TagModel tag = null;
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM tagmodel WHERE tagid=@tagid", connection);
                command.Parameters.AddWithValue("tagid", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tag = new TagModel(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            (ConsoleColor)reader.GetInt32(2)
                        );
                    }
                }

                connection.Close();
            }

            return tag;
        }

        public TagModel GetTagByName(string name) //returns a tag with the given name
        {
            TagModel tag = null;
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM tagmodel WHERE tagname=@tagname", connection);
                command.Parameters.AddWithValue("tagname", name);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tag = new TagModel(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            (ConsoleColor)reader.GetInt32(2)
                        );
                    }
                }

                connection.Close();
            }

            return tag;
        }

        public void AddNote(NoteModel note) //adds a note to the DB
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("INSERT INTO notemodel (notetitle, notecontent, noteisfav, notethemename) VALUES(@notetitle, @notecontent, @noteisfav, @notetheme)", connection);
                command.Parameters.AddWithValue("notetitle", note.Title);
                NoteContentModel noteContent = note.Content;
                command.Parameters.AddWithValue("notecontent", noteContent.TextContent);
                command.Parameters.AddWithValue("noteisfav", note.IsFavourite);
                command.Parameters.AddWithValue("notetheme", note.ThemeName);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                NoteModel note1 = GetNoteByTitle(note.Title);
                foreach(var tag in note.NoteTags)
                {
                    AddTagToNote(tag, note1);
                }
            }
        }
        
        public void AddTag(TagModel tag) //Adds a tag to the DB
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("INSERT INTO tagmodel (tagname, tagcolor) VALUES(@tagname, @tagcolor)", connection);
                command.Parameters.AddWithValue("tagname", tag.Name);
                command.Parameters.AddWithValue("tagcolor", (int)tag.Colour);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AddTagToNote(TagModel tag, NoteModel note) //Connects an existing Note and an existing Tag
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("INSERT INTO tagtonote (tagid, noteid) VALUES(@tagid, @noteid)", connection);
                command.Parameters.AddWithValue("tagid", tag.ID);
                command.Parameters.AddWithValue("noteid", note.ID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public NoteModel CheckForDuplicateTitles(string title) //Checks if there already exists a note with the given title
        {
            NoteModel note = null;
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM notemodel WHERE notetitle=@notetitle", connection);
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
                            reader.GetInt32(4)
                        );
                        note.NoteTags = GetTagsForNote(note.ID);
                    }
                }

                connection.Close();
            }

            return note;
        }

        public TagModel CheckForDuplicateTagNames(string name) //Checks if there already exists a tag with the given name
        {
            TagModel tag = null;
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM tagmodel WHERE tagname=@tagname", connection);
                command.Parameters.AddWithValue("tagname", name);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tag = new TagModel(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            (ConsoleColor)reader.GetInt32(2)
                        );
                    }
                }

                connection.Close();
            }

            return tag;
        }

        public void UpdateNote(NoteModel note) //updates the fields of a note (without changing its tags)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("UPDATE notemodel SET notetitle=@notetitle, notecontent=@notecontent, noteisfav=@noteisfav, notethemename=@notethemename WHERE noteid=@id", connection);
                command.Parameters.AddWithValue("id", note.ID);
                command.Parameters.AddWithValue("notetitle", note.Title);
                command.Parameters.AddWithValue("notecontent", note.Content.TextContent);
                command.Parameters.AddWithValue("noteisfav", note.IsFavourite);
                command.Parameters.AddWithValue("notethemename", note.ThemeName);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public void UpdateTag(TagModel tag) //updates the fields of a tag (without adding or removing it from notes)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("UPDATE tagmodel SET tagname=@tagname, tagcolor=@tagcolor WHERE tagid=@tagid", connection);
                command.Parameters.AddWithValue("tagname", tag.Name);
                command.Parameters.AddWithValue("tagcolor", (int)tag.Colour);
                command.Parameters.AddWithValue("tagid", tag.ID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void RemoveTagToNote(TagModel tag, NoteModel note) //removes a Note-Tag relationship from the DB
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("DELETE FROM tagtonote WHERE tagid = @tagid AND noteid=@noteid", connection);
                command.Parameters.AddWithValue("tagid", tag.ID);
                command.Parameters.AddWithValue("noteid", note.ID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteNote(int id) //deletes a note from the DB
        {
            NoteModel note = GetNoteById(id);
            DeleteConnectionsForNote(note);
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("DELETE FROM notemodel WHERE noteid=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteConnectionsForNote(NoteModel note) //deletes the note-tag relationships for a deleted note
        {
            foreach (var tag in note.NoteTags)
            {
                RemoveTagToNote(tag, note);
            }
        }

        public void DeleteTag(int id) //deletes a tag from the db
        {
            TagModel tag = GetTagById(id);
            DeleteConnectionsForTag(tag);
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("DELETE FROM tagmodel WHERE tagid=@tagid", connection);
                command.Parameters.AddWithValue("tagid", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteConnectionsForTag(TagModel tag) //deletes the note-tag relationships for a deleted tag
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("DELETE FROM tagtonote WHERE tagid=@tagid", connection);
                command.Parameters.AddWithValue("tagid", tag.ID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
