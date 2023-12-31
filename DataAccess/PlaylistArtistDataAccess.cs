﻿using BusinessLogic.Abstract;
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
    public class PlaylistArtistDataAccess : IPlaylistArtistDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public PlaylistArtistDataAccess()
        {
            _connection = new NpgsqlConnection("Server=localhost;Database=Tema_1_Schwarz;Port=5432;User id=postgres;Password=12345");
        }
        public void Create(PlaylistArtist playlistArtist)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO playlist_artist(playlist_id, artist_id) VALUES(@playlist_id, @artist_id)";
            command.Parameters.AddWithValue("playlist_id", playlistArtist.PlaylistId);
            command.Parameters.AddWithValue("artist_id", playlistArtist.ArtistId);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(int playlistArtistId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM playlist_artist WHERE playlist_artist_id=@playlist_artist_id";
            command.Parameters.AddWithValue("playlist_artist_id", playlistArtistId);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public List<PlaylistArtist> Read()
        {
            _connection.Open();

            List<PlaylistArtist> result = new List<PlaylistArtist>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT playlist_artist_id, playlist_id, artist_id FROM playlist_artist ORDER BY playlist_artist_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                PlaylistArtist playlistArtist = new PlaylistArtist();
                playlistArtist.PlaylistArtistId = reader.GetInt32(0);
                playlistArtist.PlaylistId=reader.GetInt32(1);
                playlistArtist.ArtistId = reader.GetInt32(2);

                result.Add(playlistArtist);
            }
            _connection.Close();

            return result;
        }

        public PlaylistArtist Read(int playlistArtistId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT playlist_artist_id, playlist_id, artist_id FROM playlist_artist WHERE playlist_artist_id=@playlist_artist_id";
            command.Parameters.AddWithValue("playlist_artist_id", playlistArtistId);

            DbDataReader reader = command.ExecuteReader();
            PlaylistArtist playlistArtist = new PlaylistArtist();

            while (reader.Read())
            {
                playlistArtist.PlaylistArtistId = reader.GetInt32(0);   
                playlistArtist.PlaylistId = reader.GetInt32(1);
                playlistArtist.ArtistId=reader.GetInt32(2);
            }
            _connection.Close();

            return playlistArtist;
        }

        public void Update(PlaylistArtist playlistArtist)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE playlist_artist " +
                                  "SET playlist_id=@playlist_id, artist_id=@artist_id WHERE playlist_artist_id = @playlist_artist_id";

            command.Parameters.AddWithValue("playlist_artist_id ", playlistArtist.PlaylistArtistId);
            command.Parameters.AddWithValue("playlist_id", playlistArtist.PlaylistArtistId);
            command.Parameters.AddWithValue("playlist_id", playlistArtist.PlaylistId);
            command.Parameters.AddWithValue("artist_id", playlistArtist.ArtistId);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
