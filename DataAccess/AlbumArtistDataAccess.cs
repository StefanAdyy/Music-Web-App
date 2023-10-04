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
    public class AlbumArtistDataAccess : IAlbumArtistDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public AlbumArtistDataAccess()
        {
            _connection = new("Server=localhost;Database=Tema_1_Schwarz;Port=5432;User id=postgres;Password=12345");
        }
        public void Create(AlbumArtist albumArtist)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO album_artist(album_id, artist_id) VALUES (@album_id, @artist_id)";
            command.Parameters.AddWithValue("album_id", albumArtist.AlbumId);
            command.Parameters.AddWithValue("artist_id", albumArtist.ArtistId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int albumArtistId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM album_artist WHERE album_artist_id=@album_artist_id";

            command.Parameters.AddWithValue("album_artist_id", albumArtistId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<AlbumArtist> Read()
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            List<AlbumArtist> result = new List<AlbumArtist>();

            command.CommandText = "SELECT album_artist_id, album_artist.album_id, album_artist.artist_id, album.title, artist.first_name, artist.second_name FROM album_artist " +
                                  "JOIN album ON album.album_id = album_artist.album_id " +
                                  "JOIN artist ON artist.artist_id = album_artist.artist_id "+
                                  "ORDER BY album_artist_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                AlbumArtist albumArtist = new AlbumArtist();
                albumArtist.AlbumArtistId = reader.GetInt32(0);
                albumArtist.AlbumId = reader.GetInt32(1);
                albumArtist.ArtistId = reader.GetInt32(2);
                albumArtist.AlbumTitle = reader.GetString(3);
                albumArtist.ArtistName = reader.GetString(4) + " " + reader.GetString(5);

                result.Add(albumArtist);
            }

            _connection.Close();

            return result;
        }

        public AlbumArtist Read(int albumArtistId)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT album_artist_id, album_artist.album_id, album_artist.artist_id, album.title, artist.first_name, artist.second_name FROM album_artist " +
                                  "JOIN album ON album.album_id = album_artist.album_id " +
                                  "JOIN artist ON artist.artist_id = album_artist.artist_id " +
                                  "WHERE album_artist_id = @album_artist_id ";

            command.Parameters.AddWithValue("album_artist_id", albumArtistId);

            DbDataReader reader = command.ExecuteReader();
            AlbumArtist albumArtist = new AlbumArtist();

            while (reader.Read())
            {
                albumArtist.AlbumArtistId = reader.GetInt32(0);
                albumArtist.AlbumId = reader.GetInt32(1);
                albumArtist.ArtistId = reader.GetInt32(2);
                albumArtist.AlbumTitle = reader.GetString(3);
                albumArtist.ArtistName = reader.GetString(4) + " " + reader.GetString(5);
            }

            _connection.Close();

            return albumArtist;
        }

        public List<AlbumArtist> ReadByAlbumId(int albumId)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT album_artist_id, album_id, artist_id FROM album_artist WHERE album_id=@album_id";
            command.Parameters.AddWithValue("album_id", albumId);

            DbDataReader reader = command.ExecuteReader();
            List<AlbumArtist> result = new List<AlbumArtist>();

            while (reader.Read())
            {
                AlbumArtist albumArtist = new AlbumArtist();
                albumArtist.AlbumArtistId = reader.GetInt32(0);
                albumArtist.AlbumId = reader.GetInt32(1);
                albumArtist.ArtistId = reader.GetInt32(2);
                result.Add(albumArtist);
            }

            _connection.Close();

            return result;
        }

        public List<AlbumArtist> ReadByArtistId(int artistId)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT album_artist_id, album_id, artist_id FROM album_artist WHERE artist_id=@artist_id";
            command.Parameters.AddWithValue("album_id", artistId);

            DbDataReader reader = command.ExecuteReader();
            List<AlbumArtist> result = new List<AlbumArtist>();

            while (reader.Read())
            {
                AlbumArtist albumArtist = new AlbumArtist();
                albumArtist.AlbumArtistId = reader.GetInt32(0);
                albumArtist.AlbumId = reader.GetInt32(1);
                albumArtist.ArtistId = reader.GetInt32(2);
                result.Add(albumArtist);
            }

            _connection.Close();

            return result;
        }

        public void Update(AlbumArtist albumArtist)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE album_artist SET album_id=@album_id, artist_id=@artist_id WHERE album_artist_id=@album_artist_id";

            command.Parameters.AddWithValue("album_id", albumArtist.AlbumId);
            command.Parameters.AddWithValue("artist_id", albumArtist.ArtistId);
            command.Parameters.AddWithValue("album_artist_id", albumArtist.AlbumArtistId);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
