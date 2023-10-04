using BusinessLogic;
using BusinessLogic.Abstract;
using Domain;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SongDataAccess : ISongDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public SongDataAccess()
        {
            _connection = new("Server=localhost;Database=Tema_1_Schwarz;Port=5432;User id=postgres;Password=12345");
        }

        public void Create(Song song)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO song (title, genre_id, release_date, length_minutes) VALUES (@title, @genre_id, @release_date, @length_minutes)";
            command.Parameters.AddWithValue("title", song.Title);
            command.Parameters.AddWithValue("genre_id", song.GenreId);
            command.Parameters.AddWithValue("release_date", song.ReleaseDate);
            command.Parameters.AddWithValue("length_minutes", song.Length);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int songId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM playlist_song WHERE song_id=@song_id; "+
                                  "DELETE FROM album_song WHERE song_id=@song_id; "+
                                  "DELETE FROM song_artist WHERE song_id=@song_id; "+
                                  "DELETE FROM song WHERE song_id=@song_id;";

            command.Parameters.AddWithValue("song_id", songId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<Song> Read()
        {
            _connection.Open();

            List<Song> result = new List<Song>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT song_id, title, song.genre_id, release_date, length_minutes, likes, genre "+
                                  "FROM song "+
                                  "JOIN music_genre ON song.genre_id = music_genre.genre_id "+
                                  "ORDER BY song_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Song song = new Song();
                song.SongId = reader.GetInt32(0);
                song.Title = reader.GetString(1);
                song.GenreId = reader.GetInt32(2);
                song.ReleaseDate = reader.GetDateTime(3);
                song.Length = Math.Round(reader.GetDouble(4), 2);
                song.Likes = reader.GetInt32(5);
                song.Genre = reader.GetString(6);

                result.Add(song);
            }

            _connection.Close();
            return result;
        }

        public Song Read(int songId)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT song_id, title, song.genre_id, release_date, length_minutes, likes, genre " +
                                  "FROM song " +
                                  "JOIN music_genre ON song.genre_id = music_genre.genre_id "+
                                  "WHERE song_id=@song_id";
            command.Parameters.AddWithValue("song_id", songId);

            DbDataReader reader = command.ExecuteReader();
            Song song = new Song();

            while (reader.Read())
            {
                song.SongId = reader.GetInt32(0);
                song.Title = reader.GetString(1);
                song.GenreId = reader.GetInt32(2);
                song.ReleaseDate = reader.GetDateTime(3);
                song.Length = Math.Round(reader.GetDouble(4), 2);
                song.Likes = reader.GetInt32(5);
                song.Genre=reader.GetString(6);
            }

            _connection.Close();

            return song;
        }

        public void Update(Song song)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE song " +
                                  "SET title=@title, genre_id=@genre_id, release_date=@release_date, length_minutes=@length_minutes " +
                                  "WHERE song_id = @song_id";

            command.Parameters.AddWithValue("song_id", song.SongId);
            command.Parameters.AddWithValue("title", song.Title);
            command.Parameters.AddWithValue("genre_id", song.GenreId);
            command.Parameters.AddWithValue("release_date", song.ReleaseDate);
            command.Parameters.AddWithValue("length_minutes", song.Length);
            command.Parameters.AddWithValue("likes", song.Likes);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void AddLike(int songId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE song " +
                                  "SET likes = likes + 1 " +
                                  "WHERE song_id = @song_id";

            command.Parameters.AddWithValue("song_id", songId);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
