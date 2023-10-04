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
    public class AlbumDataAccess : IAlbumDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public AlbumDataAccess()
        {
            _connection = new("Server=localhost;Database=Tema_1_Schwarz;Port=5432;User id=postgres;Password=12345");
        }
        public void Create(Album album)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO album(title, release_date, record_label) VALUES (@title, @release_date, @record_label)";
            command.Parameters.AddWithValue("title", album.Title);
            command.Parameters.AddWithValue("release_date", album.ReleaseDate);
            command.Parameters.AddWithValue("record_label", album.RecordLabel);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int albumId)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM album_artist WHERE album_id=@album_id ;" +
                                  "DELETE FROM album_song WHERE album_id=@album_id ;" +
                                  "DELETE FROM playlist_album WHERE album_id=@album_id ;" +
                                  "DELETE FROM album WHERE album_id=@album_id ;";

            command.Parameters.AddWithValue("album_id", albumId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<Album> Read()
        {
            _connection.Open();

            List<Album> result = new List<Album>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT album_id, title, release_date, record_label FROM album ORDER BY album_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Album album = new Album();
                album.AlbumId = reader.GetInt32(0);
                album.Title = reader.GetString(1);
                album.ReleaseDate = reader.GetDateTime(2);
                album.RecordLabel = reader.GetString(3);

                result.Add(album);
            }
            _connection.Close();

            return result;
        }

        public Album Read(int albumId)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT album_id, title, release_date, record_label FROM album WHERE album_id=@album_id";
            command.Parameters.AddWithValue("album_id", albumId);

            DbDataReader reader = command.ExecuteReader();
            Album album = new Album();

            while (reader.Read())
            {
                album.AlbumId = reader.GetInt32(0);
                album.Title = reader.GetString(1);
                album.ReleaseDate = reader.GetDateTime(2);
                album.RecordLabel = reader.GetString(3);
            }

            _connection.Close();

            return album;
        }

        public void Update(Album album)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE album SET title=@title, release_date=@release_date, record_label=@record_label WHERE album_id=@album_id";

            command.Parameters.AddWithValue("title", album.Title);
            command.Parameters.AddWithValue("release_date", album.ReleaseDate);
            command.Parameters.AddWithValue("record_label", album.RecordLabel);
            command.Parameters.AddWithValue("album_id", album.AlbumId);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
