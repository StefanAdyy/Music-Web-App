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
    public class ArtistDataAccess : IArtistDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public ArtistDataAccess()
        {
            _connection = new("Server=localhost;Database=Tema_1_Schwarz;Port=5432;User id=postgres;Password=12345");
        }

        public void Create(Artist artist)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO artist(first_name, second_name, birthdate, gender, nationality_id) VALUES (@first_name, @second_name, @birthdate, @gender, @nationality_id)";
            command.Parameters.AddWithValue("first_name", artist.FirstName);
            command.Parameters.AddWithValue("second_name", artist.SecondName);
            command.Parameters.AddWithValue("birthdate", artist.Birthdate);
            command.Parameters.AddWithValue("gender", artist.Gender);
            command.Parameters.AddWithValue("nationality_id", artist.NationalityId);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(int artistId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM playlist_artist WHERE artist_id=@artist_id; " +
                                  "DELETE FROM album_artist WHERE artist_id=@artist_id; " +
                                  "DELETE FROM song_artist WHERE artist_id=@artist_id; " +
                                  "DELETE FROM artist WHERE artist_id=@artist_id; ";

            command.Parameters.AddWithValue("artist_id", artistId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<Artist> Read()
        {
            _connection.Open();

            List<Artist> result = new List<Artist>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT artist_id, first_name, second_name, birthdate, gender, artist.nationality_id, nationality.nationality "+
                                  "FROM artist "+
                                  "JOIN nationality ON artist.nationality_id = nationality.nationality_id "+
                                  "ORDER BY artist_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Artist artist = new Artist();
                artist.ArtistId = reader.GetInt32(0);
                artist.FirstName = reader.GetString(1);
                artist.SecondName = reader.GetString(2);
                artist.Birthdate = reader.GetDateTime(3);
                artist.Gender = reader.GetString(4);
                artist.NationalityId = reader.GetInt32(5);
                artist.Nationality=reader.GetString(6);

                result.Add(artist);
            }
            _connection.Close();

            return result;
        }

        public Artist Read(int artistId)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT artist_id, first_name, second_name, birthdate, gender, artist.nationality_id, nationality.nationality " +
                                  "FROM artist " +
                                  "JOIN nationality ON artist.nationality_id = nationality.nationality_id "+
                                  "WHERE artist_id=@artist_id";

            command.Parameters.AddWithValue("artist_id", artistId);

            DbDataReader reader = command.ExecuteReader();
            Artist artist = new Artist();

            while (reader.Read())
            {
                artist.ArtistId = reader.GetInt32(0);
                artist.FirstName = reader.GetString(1);
                artist.SecondName = reader.GetString(2);
                artist.Birthdate = reader.GetDateTime(3);
                artist.Gender = reader.GetString(4);
                artist.NationalityId = reader.GetInt32(5);
                artist.Nationality = reader.GetString(6);
            }
            _connection.Close();

            return artist;
        }

        public void Update(Artist artist)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE artist " +
                                  "SET first_name=@first_name, second_name=@second_name, birthdate=@birthdate, gender=@gender, nationality_id=@nationality_id " +
                                  "WHERE artist_id = @artist_id";

            command.Parameters.AddWithValue("first_name", artist.FirstName);
            command.Parameters.AddWithValue("second_name", artist.SecondName);
            command.Parameters.AddWithValue("birthdate", artist.Birthdate);
            command.Parameters.AddWithValue("gender", artist.Gender);
            command.Parameters.AddWithValue("nationality_id", artist.NationalityId);
            command.Parameters.AddWithValue("artist_id", artist.ArtistId);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
