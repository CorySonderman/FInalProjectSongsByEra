using Dapper;
using FinalProjectSongsByEra.Models;
using System.Data;
// This class implements the ISongRepository interface for data access to songs from
// the MySql database.
// Key Points:
// - Implements methods for retrieving, updating, adding, and deleting songs.
// - Uses Dapper for database interactions.
namespace FinalProjectSongsByEra
{
    public class SongsFrom1950Repository : ISongRepository
    {
        private readonly IDbConnection _conn;
        public SongsFrom1950Repository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<SongsFrom1950> GetAllSongs()
        {
            return _conn.Query<SongsFrom1950>("SELECT * FROM songs_1950s;");
        }
        public SongsFrom1950 GetSong(int id)
        {
            return _conn.QuerySingle<SongsFrom1950>("SELECT * FROM songs_1950s WHERE ID = @id", new { id = id });
        }
        public void UpdateSong(SongsFrom1950 song)
        {
            _conn.Execute("UPDATE songs_1950s SET Title = @Title, Artist = @Artist, Genre = @Genre, YearReleased = @YearReleased WHERE ID = @ID", song);
        }

        public void AddSong(SongsFrom1950 song)
        {
            _conn.Execute("INSERT INTO songs_1950s (Title, Artist, Genre, YearReleased) VALUES (@Title, @Artist, @Genre, @YearReleased)", song);
        }

        public void DeleteSong(int id)
        {
            _conn.Execute("DELETE FROM songs_1950s WHERE ID = @id", new { id });
        }


    }
}
