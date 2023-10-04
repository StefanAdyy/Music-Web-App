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
    public class PlaylistAlbumDataAccess : IPlaylistAlbumDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public PlaylistAlbumDataAccess()
        {
            _connection = new NpgsqlConnection("Server=localhost;Database=Tema_1_Schwarz;Port=5432;User id=postgres;Password=12345");
        }

        public void Create(PlaylistAlbum playlistAlbum)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO playlist_album(playlist_id, album_id) VALUES (@playlist_id, @album_id)";
            command.Parameters.AddWithValue("playlist_id", playlistAlbum.PlaylistId);
            command.Parameters.AddWithValue("album_id", playlistAlbum.AlbumId);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(int playlistAlbumId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM playlist_album WHERE playlist_album_id=@playlist_album_id";
            command.Parameters.AddWithValue("playlist_album_id", playlistAlbumId);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public List<PlaylistAlbum> Read()
        {
            _connection.Open();

            List<PlaylistAlbum> result = new List<PlaylistAlbum>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT playlist_album_id, playlist_id, album_id FROM playlist_album ORDER BY playlist_album_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                PlaylistAlbum playlistAlbum = new PlaylistAlbum();
                playlistAlbum.PlaylistAlbumId = reader.GetInt32(0);
                playlistAlbum.PlaylistId = reader.GetInt32(1);
                playlistAlbum.AlbumId = reader.GetInt32(2);
                result.Add(playlistAlbum);
            }
            _connection.Close();

            return result;
        }

        public PlaylistAlbum Read(int playlistAlbumId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT playlist_album_id, playlist_id, album_id FROM playlist_album WHERE playlist_album_id=@playlist_album_id";
            command.Parameters.AddWithValue("playlist_album_id", playlistAlbumId);

            DbDataReader reader = command.ExecuteReader();
            PlaylistAlbum playlistAlbum = new PlaylistAlbum();

            while (reader.Read())
            {
                playlistAlbum.PlaylistAlbumId = reader.GetInt32(0);
                playlistAlbum.PlaylistId = reader.GetInt32(1);
                playlistAlbum.AlbumId = reader.GetInt32(3);
            }
            _connection.Close();

            return playlistAlbum;
        }

        public void Update(PlaylistAlbum playlistAlbum)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE playlist_album " +
                                  "SET playlist_id=@playlist_id, album_id=@album_id WHERE playlist_album_id = @playlist_album_id";

            command.Parameters.AddWithValue("playlist_album_id ", playlistAlbum.PlaylistAlbumId);
            command.Parameters.AddWithValue("playlist_id ", playlistAlbum.PlaylistId);
            command.Parameters.AddWithValue("album_id ", playlistAlbum.AlbumId);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
