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
    public class EntryDateDataAccess : IEntryDateDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public EntryDateDataAccess()
        {
            _connection = new("Server=localhost;Database=Tema_1_Schwarz;Port=5432;User id=postgres;Password=12345");
        }

        public void Create(EntryDate entryDate)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO entry_date(entry_date, last_entry_hour, has_exited) VALUES (@entry_date, @last_entry_hour, @has_exited)";
            command.Parameters.AddWithValue("entry_date", entryDate.Date);
            command.Parameters.AddWithValue("last_entry_hour", entryDate.LastEntryHour);
            command.Parameters.AddWithValue("has_exited", entryDate.HasExited);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int entryDateId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM entry_date WHERE entry_date_id=@entry_date_id";

            command.Parameters.AddWithValue("entry_date_id", entryDateId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<EntryDate> Read()
        {
            _connection.Open();

            List<EntryDate> result = new List<EntryDate>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT entry_date_id, entry_date, last_entry_hour, minutes, has_exited FROM entry_date ORDER BY entry_date_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                EntryDate entryDate = new EntryDate();
                entryDate.EntryDateId = reader.GetInt32(0);
                entryDate.Date = reader.GetDateTime(1);
                entryDate.LastEntryHour = reader.GetDateTime(2);
                entryDate.Minutes = reader.GetInt32(3);
                entryDate.HasExited = reader.GetBoolean(4);

                result.Add(entryDate);
            }
            _connection.Close();

            return result;
        }

        public EntryDate Read(int entryDateId)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT entry_date_id, entry_date, last_entry_hour, minutes, has_exited FROM entry_date WHERE entry_date_id=@entry_date_id";
            command.Parameters.AddWithValue("entry_date_id", entryDateId);

            DbDataReader reader = command.ExecuteReader();
            EntryDate entryDate = new EntryDate();

            while (reader.Read())
            {
                entryDate.EntryDateId = reader.GetInt32(0);
                entryDate.Date = reader.GetDateTime(1);
                entryDate.LastEntryHour = reader.GetDateTime(2);
                entryDate.Minutes = reader.GetInt32(3);
                entryDate.HasExited = reader.GetBoolean(4);
            }

            _connection.Close();

            return entryDate;
        }

        public EntryDate ReadLastEntry()
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT entry_date_id, entry_date, last_entry_hour, minutes, has_exited FROM entry_date " +
                                  "ORDER BY entry_date_id DESC " +
                                  "LIMIT 1 ";

            DbDataReader reader = command.ExecuteReader();
            EntryDate entryDate = new EntryDate();

            while (reader.Read())
            {
                entryDate.EntryDateId = reader.GetInt32(0);
                entryDate.Date = reader.GetDateTime(1);
                entryDate.LastEntryHour = reader.GetDateTime(2);
                entryDate.Minutes = reader.GetInt32(3);
                entryDate.HasExited = reader.GetBoolean(4);
            }

            _connection.Close();

            return entryDate;
        }

        public void Update(EntryDate entryDate)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE entry_date SET entry_date=@entry_date, last_entry_hour=@last_entry_hour,minutes=@minutes, has_exited=@has_exited WHERE entry_date_id=@entry_date_id";

            command.Parameters.AddWithValue("entry_date_id", entryDate.EntryDateId);
            command.Parameters.AddWithValue("entry_date", entryDate.Date);
            command.Parameters.AddWithValue("last_entry_hour", entryDate.LastEntryHour);
            command.Parameters.AddWithValue("minutes", entryDate.Minutes);
            command.Parameters.AddWithValue("has_exited", entryDate.HasExited);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public int DailyAverageTime()
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT AVG(minutes) FROM entry_date";

            DbDataReader reader = command.ExecuteReader();
            int average = new int();

            while (reader.Read())
            {
                average = Convert.ToInt32(reader.GetDouble(0));
            }

            _connection.Close();

            return average;
        }
    }
}
