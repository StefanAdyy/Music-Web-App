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
    public class AlbumSongDataAccess : IAlbumSongDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public AlbumSongDataAccess()
        {
            _connection = new("Server=localhost;Database=Tema_1_Schwarz;Port=5432;User id=postgres;Password=12345");
        }
        public void Create(AlbumSong albumSong)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO album_song(album_id, song_id) VALUES (@album_id, @song_id)";
            command.Parameters.AddWithValue("album_id", albumSong.AlbumId);
            command.Parameters.AddWithValue("song_id", albumSong.SongId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int albumSongId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM album_song WHERE album_song_id=@album_song";

            command.Parameters.AddWithValue("album_song", albumSongId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<AlbumSong> Read()
        {
            _connection.Open();

            List<AlbumSong> result = new List<AlbumSong>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT album_song_id, album_song.album_id, album_song.song_id, album.title, song.title FROM album_song "+
                                  "JOIN album ON album.album_id = album_song.album_id "+
                                  "JOIN song ON song.song_id = album_song.song_id "+
                                  "ORDER BY album_song_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                AlbumSong albumSong = new AlbumSong();
                albumSong.AlbumSongId = reader.GetInt32(0);
                albumSong.AlbumId = reader.GetInt32(1);
                albumSong.SongId = reader.GetInt32(2);
                albumSong.AlbumTitle = reader.GetString(3);
                albumSong.SongTitle=reader.GetString(4);

                result.Add(albumSong);
            }
            _connection.Close();

            return result;
        }

        public AlbumSong Read(int albumSongId)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT album_song_id, album_song.album_id, album_song.song_id, album.title, song.title FROM album_song " +
                                  "JOIN album ON album.album_id = album_song.album_id " +
                                  "JOIN song ON song.song_id = album_song.song_id "+
                                  "WHERE album_song_id=@album_song_id";
            command.Parameters.AddWithValue("album_song_id", albumSongId);

            DbDataReader reader = command.ExecuteReader();
            AlbumSong albumSong = new AlbumSong();

            while (reader.Read())
            {
                albumSong.AlbumSongId = reader.GetInt32(0);
                albumSong.AlbumId = reader.GetInt32(1);
                albumSong.SongId = reader.GetInt32(2);
                albumSong.AlbumTitle = reader.GetString(3);
                albumSong.SongTitle = reader.GetString(4);
            }

            _connection.Close();

            return albumSong;
        }

        public void Update(AlbumSong albumSong)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE album_song SET album_id=@album_id, song_id=@song_id WHERE album_song_id=@album_song_id";

            command.Parameters.AddWithValue("album_song_id", albumSong.AlbumSongId);
            command.Parameters.AddWithValue("album_id", albumSong.AlbumId);
            command.Parameters.AddWithValue("song_id", albumSong.SongId);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
