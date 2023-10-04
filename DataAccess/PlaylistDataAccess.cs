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
    public class PlaylistDataAccess : IPlaylistDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public PlaylistDataAccess()
        {
            _connection = new NpgsqlConnection("Server=localhost;Database=Tema_1_Schwarz;Port=5432;User id=postgres;Password=12345");
        }

        public void Create(Playlist playlist)
        {
            _connection.Open();

            NpgsqlCommand command=_connection.CreateCommand();

            command.CommandText = "INSERT INTO playlist(name) VALUES(@name)";
            command.Parameters.AddWithValue("name", playlist.Name);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(int playlistId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM playlist_song WHERE playlist_id=@playlist_id; "+
                                  "DELETE FROM playlist_artist WHERE playlist_id=@playlist_id; " +
                                  "DELETE FROM playlist_album WHERE playlist_id=@playlist_id; " +
                                  "DELETE FROM playlist WHERE playlist_id=@playlist_id";

            command.Parameters.AddWithValue("playlist_id", playlistId);
            command.ExecuteNonQuery();

            _connection.Close();
        }

        public Playlist GetLastAddedPlaylist()
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT playlist_id FROM playlist "+
                                  "ORDER BY playlist_id DESC "+
                                  "LIMIT 1";

            DbDataReader reader = command.ExecuteReader();
            Playlist playlist = new Playlist();

            while (reader.Read())
            {
                playlist.PlaylistId = reader.GetInt32(0);
            }

            _connection.Close();

            return playlist;
        }

        public List<Playlist> Read()
        {
            _connection.Open();

            List<Playlist> result = new List<Playlist>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT playlist_id, name FROM playlist ORDER BY playlist_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Playlist playlist= new Playlist();
                playlist.PlaylistId = reader.GetInt32(0);
                playlist.Name = reader.GetString(1);

                result.Add(playlist);
            }
            _connection.Close();

            return result;
        }

        public Playlist Read(int playlistId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT playlist_id, name FROM playlist WHERE playlist_id=@playlist_id";
            command.Parameters.AddWithValue("playlist_id", playlistId);

            DbDataReader reader = command.ExecuteReader();
            Playlist playlist = new Playlist();

            while (reader.Read())
            {
                playlist.PlaylistId = reader.GetInt32(0);
                playlist.Name = reader.GetString(1);

            }
            _connection.Close();

            return playlist;
        }

        public void Update(Playlist playlist)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE playlist " +
                                  "SET name=@name WHERE playlist_id = @playlist_id";

            command.Parameters.AddWithValue("name", playlist.Name);
            command.Parameters.AddWithValue("playlist_id", playlist.PlaylistId);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
