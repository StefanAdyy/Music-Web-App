using BusinessLogic.Abstract;
using Domain;
using Npgsql;
using System.Collections.Generic;
using System.Data.Common;

namespace DataAccess
{
    public class PlaylistSongDataAccess : IPlaylistSongDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public PlaylistSongDataAccess()
        {
            _connection = new NpgsqlConnection("Server=localhost;Database=Tema_1_Schwarz;Port=5432;User id=postgres;Password=12345");
        }

        public void AddSongsFromAlbum(int playlistId, int albumId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO playlist_song (playlist_id, song_id) " +
                                  "SELECT @playlist_id,album_song.song_id FROM album_song " +
                                  "WHERE album_song.album_id = @album_id " +
                                  "ON CONFLICT DO NOTHING";

            command.Parameters.AddWithValue("playlist_id", playlistId);
            command.Parameters.AddWithValue("album_id", albumId);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void AddSongsFromArtist(int playlistId, int artistId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO playlist_song (playlist_id, song_id) "+
                                  "SELECT @playlist_id,song_artist.song_id FROM song_artist " +
                                  "WHERE song_artist.artist_id = @artist_id "+
                                  "ON CONFLICT DO NOTHING";

            command.Parameters.AddWithValue("playlist_id", playlistId);
            command.Parameters.AddWithValue("artist_id", artistId);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Create(PlaylistSong playlistSong)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO playlist_song(playlist_id, song_id) VALUES (@playlist_id, @song_id) ON CONFLICT DO NOTHING";
            command.Parameters.AddWithValue("playlist_id", playlistSong.PlaylistId);
            command.Parameters.AddWithValue("song_id", playlistSong.SongId);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(int playlistSongId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM playlist_song WHERE playlist_song_id=@playlist_song_id";
            command.Parameters.AddWithValue("playlist_song_id", playlistSongId);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public List<PlaylistSong> Read()
        {
            _connection.Open();

            List<PlaylistSong> result = new List<PlaylistSong>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT playlist_song_id, playlist_id, song_id FROM playlist_song ORDER BY playlist_song_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                PlaylistSong playlistSong = new PlaylistSong();
                playlistSong.PlaylistSongId = reader.GetInt32(0);
                playlistSong.PlaylistId=reader.GetInt32(1);
                playlistSong.SongId = reader.GetInt32(2);

                result.Add(playlistSong);
            }
            _connection.Close();

            return result;
        }

        public PlaylistSong Read(int playlistSongId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT playlist_song_id, playlist_id, song_id FROM playlist_song WHERE playlist_song_id=@playlist_song_id";
            command.Parameters.AddWithValue("playlist_song_id", playlistSongId);

            DbDataReader reader = command.ExecuteReader();
            PlaylistSong playlistSong = new PlaylistSong();

            while (reader.Read())
            {
                playlistSong.PlaylistSongId = reader.GetInt32(0);
                playlistSong.PlaylistId = reader.GetInt32(1);
                playlistSong.SongId = reader.GetInt32(3);
            }
            _connection.Close();

            return playlistSong;
        }

        public List<PlaylistSong> ReadByPlaylistId(int playlistId)
        {
            _connection.Open();

            List<PlaylistSong> result = new List<PlaylistSong>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT playlist_song.playlist_song_id, playlist_song.playlist_id, playlist_song.song_id, artist.first_name, artist.second_name, song.title " +
                                  "FROM playlist_song " +
                                  "JOIN song_artist ON song_artist.song_id = playlist_song.song_id " +
                                  "JOIN artist ON artist.artist_id = song_artist.artist_id " +
                                  "JOIN song ON song.song_id = playlist_song.song_id " +
                                  "WHERE playlist_id = @playlist_id " +
                                  "ORDER BY playlist_song_id";

            command.Parameters.AddWithValue("playlist_id", playlistId);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                PlaylistSong playlistSong = new PlaylistSong();
                playlistSong.PlaylistSongId = reader.GetInt32(0);
                playlistSong.PlaylistId = reader.GetInt32(1);
                playlistSong.SongId = reader.GetInt32(2);
                playlistSong.SongArtistName=reader.GetString(3)+" "+reader.GetString(4);
                playlistSong.SongTitle = reader.GetString(5);

                result.Add(playlistSong);
            }
            _connection.Close();

            return result;
        }

        public void Update(PlaylistSong playlistSong)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE playlist_song " +
                                  "SET playlist_id=@playlist_id, song_id=@song_id WHERE playlist_song_id = @playlist_song_id";

            command.Parameters.AddWithValue("playlist_song_id ", playlistSong.PlaylistSongId);
            command.Parameters.AddWithValue("playlist_id ", playlistSong.PlaylistId);
            command.Parameters.AddWithValue("song_id ", playlistSong.SongId);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
