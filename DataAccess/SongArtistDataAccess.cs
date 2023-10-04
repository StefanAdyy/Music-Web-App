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
    public class SongArtistDataAccess : ISongArtistDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public SongArtistDataAccess()
        {
            _connection = new("Server=localhost;Database=Tema_1_Schwarz;Port=5432;User id=postgres;Password=12345");
        }
        public void Create(SongArtist songArtist)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO song_artist (song_id, artist_id) VALUES (@song_id, @artist_id)";
            command.Parameters.AddWithValue("song_id", songArtist.SongId);
            command.Parameters.AddWithValue("artist_id", songArtist.ArtistId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int songArtistId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM song_artist WHERE song_artist_id=@song_artist_id";

            command.Parameters.AddWithValue("song_artist_id", songArtistId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<SongArtist> Read()
        {
            _connection.Open();

            List<SongArtist> result = new List<SongArtist>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT song_artist_id, song_artist.song_id, song_artist.artist_id, song.title, artist.first_name, artist.second_name " +
                                  "FROM song_artist " +
                                  "JOIN song ON song.song_id = song_artist.song_id " +
                                  "JOIN artist ON artist.artist_id = song_artist.artist_id "+
                                  "ORDER BY song_artist_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                SongArtist songArtist = new SongArtist();
                songArtist.SongArtistId = reader.GetInt32(0);
                songArtist.SongId = reader.GetInt32(1);
                songArtist.ArtistId = reader.GetInt32(2);
                songArtist.SongTitle = reader.GetString(3);
                songArtist.ArtistName = reader.GetString(4) + " " + reader.GetString(5);

                result.Add(songArtist);
            }
            _connection.Close();

            return result;
        }

        public SongArtist Read(int songArtistId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT song_artist_id, song_artist.song_id, song_artist.artist_id, song.title, artist.first_name, artist.second_name " +
                                  "FROM song_artist " +
                                  "JOIN song ON song.song_id = song_artist.song_id " +
                                  "JOIN artist ON artist.artist_id = song_artist.artist_id "+
                                  "WHERE song_artist_id=@song_artist_id";

            command.Parameters.AddWithValue("song_artist_id", songArtistId);
            DbDataReader reader = command.ExecuteReader();
            
            SongArtist songArtist = new SongArtist();
            
            while (reader.Read())
            {
                songArtist.SongArtistId = reader.GetInt32(0);
                songArtist.SongId = reader.GetInt32(1);
                songArtist.ArtistId = reader.GetInt32(2);
                songArtist.SongTitle = reader.GetString(3);
                songArtist.ArtistName = reader.GetString(4) + " " + reader.GetString(5);
            }

            _connection.Close();

            return songArtist;
        }
        
        public void Update(SongArtist songArtist)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE song_artist SET song_id=@song_id, artist_id=@artist_id WHERE song_artist_id = @song_artist_id ";

            command.Parameters.AddWithValue("song_artist_id", songArtist.SongArtistId);
            command.Parameters.AddWithValue("song_id", songArtist.SongId);
            command.Parameters.AddWithValue("artist_id", songArtist.ArtistId);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
