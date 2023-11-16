namespace FinalProjectSongsByEra.Models
{
    // This class represents the model for songs retrieved from the MySql database.
    // Key Points:
    // - Properties for title, artist, genre, and year released.(It is important that these
    //   names match the names in your MySql columns.)
    public class SongsFrom1970 : ISong
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int YearReleased { get; set; }
    }
}
