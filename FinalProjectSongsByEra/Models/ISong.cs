namespace FinalProjectSongsByEra.Models
{    // This is a common interface that each table in MySql will conform to.
    // Key Points:
    // - This allows each model to be implented through ISongRepository.  This will 
    //   significantly reduce coding redundancy.
    public interface ISong
    {
        int ID { get; set; }
        string Title { get; set; }
        string Artist { get; set; }
        string Genre { get; set; }
        int YearReleased { get; set; }
    }
}
