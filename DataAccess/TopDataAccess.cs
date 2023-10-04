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
    public class TopDataAccess : ITopDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public TopDataAccess()
        {
            _connection = new("Server=localhost;Database=Tema_1_Schwarz;Port=5432;User id=postgres;Password=12345");
        }

        public List<Top> ReadFavouriteAlbums()
        {
            _connection.Open();

            List<Top> result = new List<Top>();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT album.title, SUM(likes) as likes FROM album_song "+
                                  "JOIN album ON album.album_id = album_song.album_id "+
                                  "JOIN song ON song.song_id = album_song.song_id "+
                                  "GROUP BY album.album_id "+
                                  "ORDER BY SUM(likes) DESC "+
                                  "LIMIT 5";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Top top = new Top();
                top.AlbumTitle = reader.GetString(0);
                top.Likes = reader.GetInt32(1);
                result.Add(top);
            }

            _connection.Close();

            return result;
        }

        public List<Top> ReadFavouriteArtists()
        {
            _connection.Open();

            List<Top> result = new List<Top>();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT artist.first_name, artist.second_name, sum(likes) as likes FROM song_artist " +
                                  "INNER JOIN artist ON artist.artist_id = song_artist.artist_id " +
                                  "INNER JOIN song ON song.song_id = song_artist.song_id " +
                                  "GROUP BY artist.artist_id " +
                                  "ORDER BY sum(likes) DESC " +
                                  "LIMIT 5;";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Top top = new Top();
                top.ArtistName = reader.GetString(0)+" "+reader.GetString(1);
                top.Likes = reader.GetInt32(2);
                result.Add(top);
            }

            _connection.Close();

            return result;
        }

        public List<Top> ReadFavouriteGenres()
        {
            _connection.Open();

            List<Top> result = new List<Top>();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT music_genre.genre, SUM(likes) as likes FROM music_genre "+
                                  "JOIN song ON song.genre_id = music_genre.genre_id "+
                                  "GROUP BY music_genre.genre "+
                                  "ORDER BY SUM(likes) DESC "+
                                  "LIMIT 5";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Top top = new Top();
                top.GenreName = reader.GetString(0);
                top.Likes = reader.GetInt32(1);
                result.Add(top);
            }

            _connection.Close();

            return result;
        }

        public List<Top> ReadFavouriteSongs()
        {
            _connection.Open();

            List<Top> result = new List<Top>();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT song.title, artist.first_name, artist.second_name, song.likes FROM song " +
                                  "JOIN song_artist ON song_artist.song_id = song.song_id " +
                                  "JOIN artist ON artist.artist_id = song_artist.artist_id " +
                                  "ORDER BY likes DESC "+
                                  "LIMIT 5";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Top top = new Top();
                top.SongTitle = reader.GetString(0);
                top.ArtistName = reader.GetString(1) + " " + reader.GetString(2);
                top.Likes = reader.GetInt32(3);
                result.Add(top);
            }

            _connection.Close();

            return result;
        }

        public List<Top> ReadMostLikedSongPerAlbum()
        {
            _connection.Open();

            List<Top> result = new List<Top>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT album_title, song_title, likes FROM " +
                                  "(SELECT album.title as album_title, song.title as song_title, song.likes, ROW_NUMBER() OVER " +
                                  "(PARTITION BY album.album_id ORDER BY song.likes DESC)AS ROW_NUMBER " +
                                  "FROM song " +
                                  "JOIN album_song ON album_song.song_id = song.song_id " +
                                  "JOIN album ON album.album_id = album_song.album_id) TEMP WHERE ROW_NUMBER = 1; ";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Top top = new Top();
                top.AlbumTitle = reader.GetString(0);
                top.SongTitle = reader.GetString(1);
                top.Likes = reader.GetInt32(2);

                result.Add(top);
            }

            _connection.Close();
            return result;
        }

        public List<Top> ReadMostLikedSongPerArtist()
        {
            _connection.Open();

            List<Top> result = new List<Top>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT first_name, second_name, title, likes FROM " +
                                  "(SELECT artist.first_name, artist.second_name, song.title, song.likes, ROW_NUMBER() OVER " +
                                  "(PARTITION BY artist.artist_id ORDER BY song.likes DESC)AS ROW_NUMBER " +
                                  "FROM song " +
                                  "JOIN song_artist ON song_artist.song_id = song.song_id " +
                                  "JOIN artist ON artist.artist_id = song_artist.artist_id) TEMP WHERE ROW_NUMBER = 1; ";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Top top = new Top();
                top.ArtistName = reader.GetString(0) + " " + reader.GetString(1);
                top.SongTitle = reader.GetString(2);
                top.Likes = reader.GetInt32(3);

                result.Add(top);
            }

            _connection.Close();
            return result;
        }

        public List<Top> ReadMostLikedSongPerGenre()
        {
            _connection.Open();

            List<Top> result = new List<Top>();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT genre, title, likes FROM " +
                                  "(SELECT music_genre.genre, song.title, song.likes, ROW_NUMBER() OVER " +
                                  "(PARTITION BY music_genre.genre ORDER BY song.likes DESC)AS ROW_NUMBER " +
                                  "FROM song " +
                                  "JOIN music_genre ON music_genre.genre_id = song.genre_id) TEMP WHERE ROW_NUMBER = 1; ";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Top top = new Top();
                top.GenreName = reader.GetString(0);
                top.SongTitle = reader.GetString(1);
                top.Likes = reader.GetInt32(2);

                result.Add(top);
            }

            _connection.Close();
            return result;
        }
    }
}
