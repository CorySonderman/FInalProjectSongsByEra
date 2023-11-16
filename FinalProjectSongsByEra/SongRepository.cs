using Dapper;
using FinalProjectSongsByEra.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
// This class implements the ISongRepository interface for data access to songs from
// the MySql database.
// Key Points:
// - Implements methods for retrieving, updating, adding, and deleting songs.
// - Uses Dapper for database interactions.
namespace FinalProjectSongsByEra.Models
{
    public class SongRepository : ISongRepository
    {
        private readonly IDbConnection _conn;

        public SongRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        //public IEnumerable<ISong> GetAllSongs(string tableName)
        //{
        //    return _conn.Query<ISong>($"SELECT * FROM {tableName};");
        //}
        //public IEnumerable<ISong> GetAllSongs(string tableName)
        //{
        //    try
        //    {
        //        string query = $"SELECT * FROM {tableName};";
        //        Console.WriteLine($"Executing query: {query}");
        //        return _conn.Query<ISong>(query);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error executing query: {ex.Message}");
        //        throw; 
        //    }
        //}
        public IEnumerable<ISong> GetAllSongs(string tableName)
        {
            try
            {
                string query = $"SELECT * FROM {tableName};";
                Console.WriteLine($"Executing query: {query}");

                // Using a concrete class instead of the interface
                return _conn.Query<SongsFrom2010>(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
                throw;
            }
        }

        //public ISong GetSong(string tableName, int id)
        //{
        //    return _conn.QuerySingle<ISong>($"SELECT * FROM {tableName} WHERE ID = @id", new { id = id });
        //}
        //public ISong GetSong(string tableName, int id)
        //{
        //    try
        //    {
        //        var query = $"SELECT * FROM {tableName} WHERE ID = @id";
        //        Console.WriteLine($"Executing query: {query}"); // Add this line for logging
        //        return _conn.QuerySingle<ISong>(query, new { id = id });
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error executing query: {ex.Message}");
        //        throw;
        //    }
        //}

        public void UpdateSong(string tableName, ISong song)
        {
            _conn.Execute($"UPDATE {tableName} SET Title = @title, Artist = @artist, Genre = @genre, YearReleased = @yearReleased WHERE ID = @id",
                new { Title = song.Title, Artist = song.Artist, Genre = song.Genre, YearReleased = song.YearReleased, id = song.ID });
        }

        public void AddSong(string tableName, ISong song)
        {
            _conn.Execute($"INSERT INTO {tableName} (Title, Artist, Genre, YearReleased) VALUES (@title, @artist, @genre, @yearReleased)",
                new { Title = song.Title, Artist = song.Artist, Genre = song.Genre, YearReleased = song.YearReleased });
        }

        public void DeleteSong(string tableName, int id)
        {
            _conn.Execute($"DELETE FROM {tableName} WHERE ID = @id", new { id });
        }
    }
}