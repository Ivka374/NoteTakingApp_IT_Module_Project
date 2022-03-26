using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using NoteTakingApp_IT_Module_Project.Models;

namespace NoteTakingApp_IT_Module_Project.Data
{
    class NoteData
    {
        //DB Commands for Three Tables approach
        //Everything has been tested except the CheckForDuplicate_ Methods

        /// <summary>
        /// Returns a list with every note in the DB
        /// </summary>
        /// <returns></returns>
        public List<NoteModel> GetAllNotes()
        {
            var noteList = new List<NoteModel>();
            string music = null;
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
                        if (!reader.IsDBNull(5)) music = reader.GetString(5);
                        if (music != null)
                        {
                            MusicContent musicContent = JsonConvert.DeserializeObject<MusicContent>(music);
                            note.Content.MusicContent = musicContent;
                        }
                        note.NoteTags = GetTagsForNote(note.ID);

                        noteList.Add(note);
                    }

                }
                connection.Close();
            }

            return noteList;
        }

        /// <summary>
        /// Returns a list with all tags in the db
        /// </summary>
        /// <returns></returns>
        public List<TagModel> GetAllTags()
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

        /// <summary>
        /// Returns all notes labeled as 'favorite' (bool: IsFavorite == true)
        /// </summary>
        /// <returns></returns>
        public List<NoteModel> GetFavoriteNotes()
        {
            var noteList = new List<NoteModel>();
            string music = null;
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
                        if (!reader.IsDBNull(5)) music = reader.GetString(5);
                        if (music != null)
                        {
                            MusicContent musicContent = JsonConvert.DeserializeObject<MusicContent>(music);
                            note.Content.MusicContent = musicContent;
                        }
                        note.NoteTags = GetTagsForNote(note.ID);

                        noteList.Add(note);
                    }

                }
                connection.Close();
            }

            return noteList;
        }

        /// <summary>
        /// Returns a note with the given title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public NoteModel GetNoteByTitle(string title)
        {
            NoteModel note = null;
            string music = null;
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
                        if(!reader.IsDBNull(5)) music = reader.GetString(5);
                        if (music != null)
                        {
                            MusicContent musicContent = JsonConvert.DeserializeObject<MusicContent>(music);
                            note.Content.MusicContent = musicContent;
                        }
                        note.NoteTags = GetTagsForNote(note.ID);
                    }
                }

                connection.Close();
            }

            return note;
        }

        /// <summary>
        /// Returns a note with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NoteModel GetNoteById(int id)
        {
            NoteModel note = null;
            string music = null;
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
                        if (music != null)
                        {
                            MusicContent musicContent = JsonConvert.DeserializeObject<MusicContent>(music);
                            note.Content.MusicContent = musicContent;
                        }
                        note.NoteTags = GetTagsForNote(note.ID);
                    }
                }

                connection.Close();
            }

            return note;
        }

        /// <summary>
        /// Returns every tag for a note with the id 'int id'
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<TagModel> GetTagsForNote(int id)
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

        /// <summary>
        /// Returns every note that has a tag with an id 'int id'
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<NoteModel> GetNotesForTag(int id)
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

        /// <summary>
        /// Returns a tag with an id 'int id'
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TagModel GetTagById(int id)
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

        /// <summary>
        /// Returns a tag with the given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TagModel GetTagByName(string name)
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

        /// <summary>
        /// Adds a note to the DB
        /// </summary>
        /// <param name="note"></param>
        public void AddNote(NoteModel note)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("INSERT INTO notemodel (notetitle, notecontent, noteisfav, notethemename, notemusiccontent) VALUES(@notetitle, @notecontent, @noteisfav, @notetheme, @notemusiccontent)", connection);
                command.Parameters.AddWithValue("notetitle", note.Title);
                NoteContentModel noteContent = note.Content;
                command.Parameters.AddWithValue("notecontent", noteContent.TextContent);
                command.Parameters.AddWithValue("noteisfav", note.IsFavourite);
                command.Parameters.AddWithValue("notetheme", note.ThemeName);
                command.Parameters.AddWithValue("notemusiccontent", JsonConvert.SerializeObject(noteContent.MusicContent));
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

        /// <summary>
        /// Adds a tag to the DB
        /// </summary>
        /// <param name="tag"></param>
        public void AddTag(TagModel tag)
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

        /// <summary>
        /// Connects an existing Note and an existing Tag
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="note"></param>
        public void AddTagToNote(TagModel tag, NoteModel note)
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

        /// <summary>
        /// Checks if there already exists a note with the given title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public NoteModel CheckForDuplicateTitles(string title)
        {
            NoteModel note = null;
            string music = null;
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
                        if (!reader.IsDBNull(5)) music = reader.GetString(5);
                        if (music != null)
                        {
                            MusicContent musicContent = JsonConvert.DeserializeObject<MusicContent>(music);
                            note.Content.MusicContent = musicContent;
                        }
                        note.NoteTags = GetTagsForNote(note.ID);
                    }
                }

                connection.Close();
            }

            return note;
        }

        /// <summary>
        /// Checks if there already exists a tag with the given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TagModel CheckForDuplicateTagNames(string name)
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

        /// <summary>
        /// Updates the fields of a note (without changing its tags)
        /// </summary>
        /// <param name="note"></param>
        public void UpdateNote(NoteModel note)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new MySqlCommand("UPDATE notemodel SET notetitle=@notetitle, notecontent=@notecontent, noteisfav=@noteisfav, notethemename=@notethemename, notemusiccontent=@notemusiccontent WHERE noteid=@id", connection);
                command.Parameters.AddWithValue("id", note.ID);
                command.Parameters.AddWithValue("notetitle", note.Title);
                command.Parameters.AddWithValue("notecontent", note.Content.TextContent);
                command.Parameters.AddWithValue("noteisfav", note.IsFavourite);
                command.Parameters.AddWithValue("notethemename", note.ThemeName);
                command.Parameters.AddWithValue("notemusiccontent", JsonConvert.SerializeObject(note.Content.MusicContent));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        /// <summary>
        /// Updates the fields of a tag (without adding or removing it from notes)
        /// </summary>
        /// <param name="tag"></param>
        public void UpdateTag(TagModel tag)
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

        /// <summary>
        /// Removes a Note-Tag relationship from the DB
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="note"></param>
        public void RemoveTagToNote(TagModel tag, NoteModel note)
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

        /// <summary>
        /// Deletes a note from the DB
        /// </summary>
        /// <param name="id"></param>
        public void DeleteNote(int id)
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

        /// <summary>
        /// Deletes the note-tag relationships for a deleted note
        /// </summary>
        /// <param name="note"></param>
        public void DeleteConnectionsForNote(NoteModel note)
        {
            foreach (var tag in note.NoteTags)
            {
                RemoveTagToNote(tag, note);
            }
        }

        /// <summary>
        /// Deletes a tag from the db
        /// </summary>
        /// <param name="id"></param>
        public void DeleteTag(int id)
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

        /// <summary>
        /// Deletes the note-tag relationships for a deleted tag
        /// </summary>
        /// <param name="tag"></param>
        public void DeleteConnectionsForTag(TagModel tag)
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
