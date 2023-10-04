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
    public class NationalityDataAccess : INationalityDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public NationalityDataAccess()
        {
            _connection = new("Server=localhost;Database=Tema_1_Schwarz;Port=5432;User id=postgres;Password=12345");
        }

        public void Create(Nationality nationality)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO nationality (nationality) VALUES (@nationality)";
            command.Parameters.AddWithValue("nationality", nationality.NationalityName);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int nationalityId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM nationality WHERE nationality_id=@nationality_id";

            command.Parameters.AddWithValue("nationality_id", nationalityId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<Nationality> Read()
        {
            _connection.Open();

            List<Nationality> result = new List<Nationality>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT nationality_id, nationality FROM nationality ORDER BY nationality_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Nationality nationality = new Nationality();
                nationality.NationalityId = reader.GetInt32(0);
                nationality.NationalityName = reader.GetString(1);

                result.Add(nationality);
            }
            _connection.Close();

            return result;
        }

        public Nationality Read(int nationalityId)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT nationality_id, nationality FROM nationality WHERE nationality_id=@nationality_id";
            command.Parameters.AddWithValue("nationality_id", nationalityId);

            DbDataReader reader = command.ExecuteReader();
            Nationality nationality = new Nationality();

            while (reader.Read())
            {
                nationality.NationalityId = reader.GetInt32(0);
                nationality.NationalityName = reader.GetString(1);
            }

            _connection.Close();

            return nationality;
        }

        public void Update(Nationality nationality)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE nationality " +
                                  "SET nationality=@nationality " +
                                  "WHERE nationality_id = @nationality_id";

            command.Parameters.AddWithValue("nationality_id", nationality.NationalityId);
            command.Parameters.AddWithValue("nationality", nationality.NationalityName);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
