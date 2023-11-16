using System.Collections.Generic;
using FinalProjectSongsByEra.Models;
// This interface defines the contract for data access to songs.
// Key Points:
// - Methods for retrieving, updating, adding, and deleting songs.

namespace FinalProjectSongsByEra.Models
{
    public interface ISongRepository
    {
        IEnumerable<ISong> GetAllSongs(string tableName);
        //ISong GetSong(string tableName, int id);
        void UpdateSong(string tableName, ISong song);
        void AddSong(string tableName, ISong song);
        void DeleteSong(string tableName, int id);
    }
}

