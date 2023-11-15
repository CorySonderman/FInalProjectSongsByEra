using FinalProjectSongsByEra.Models;
// This interface defines the contract for data access to songs.
// Key Points:
// - Methods for retrieving, updating, adding, and deleting songs.
namespace FinalProjectSongsByEra
{
    public interface ISongRepository
    {
        public IEnumerable<SongsFrom1950> GetAllSongs();
        public SongsFrom1950 GetSong(int id);
        public void UpdateSong(SongsFrom1950 song);
        //Create and delete code
        public void AddSong(SongsFrom1950 song);
        public void DeleteSong(int id);

    }
}
