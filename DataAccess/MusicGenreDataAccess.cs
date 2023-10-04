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
    public class MusicGenreDataAccess : IMusicGenreDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public MusicGenreDataAccess()
        {
            _connection = new("Server=localhost;Database=Tema_1_Schwarz;Port=5432;User id=postgres;Password=12345");
        }
        public void Create(MusicGenre musicGenre)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO music_genre (genre) VALUES (@genre)";
            command.Parameters.AddWithValue("genre", musicGenre.Genre);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int musicGenreId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM music_genre WHERE genre_id=@genre_id";

            command.Parameters.AddWithValue("genre_id", musicGenreId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<MusicGenre> Read()
        {
            _connection.Open();

            List<MusicGenre> result = new List<MusicGenre>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT genre_id, genre FROM music_genre ORDER BY genre_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MusicGenre musicGenre = new MusicGenre();
                musicGenre.MusicGenreId = reader.GetInt32(0);
                musicGenre.Genre = reader.GetString(1);

                result.Add(musicGenre);
            }
            _connection.Close();

            return result;
        }

        public MusicGenre Read(int musicGenreId)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT genre_id, genre FROM music_genre WHERE genre_id=@genre_id";
            command.Parameters.AddWithValue("genre_id", musicGenreId);

            DbDataReader reader = command.ExecuteReader();
            MusicGenre musicGenre = new MusicGenre();

            while (reader.Read())
            {
                musicGenre.MusicGenreId = reader.GetInt32(0);
                musicGenre.Genre = reader.GetString(1);
            }

            _connection.Close();

            return musicGenre;
        }

        public void Update(MusicGenre musicGenre)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE music_genre " +
                                  "SET genre=@genre " +
                                  "WHERE genre_id = @genre_id";

            command.Parameters.AddWithValue("genre_id", musicGenre.MusicGenreId);
            command.Parameters.AddWithValue("genre", musicGenre.Genre);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
