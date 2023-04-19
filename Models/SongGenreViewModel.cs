namespace SongManagement.Models
{
    public class SongGenreViewModel
    {
        public List<Song> SongList { get; set; }
        public List<Genre> GenreList { get; set; }

        public SongGenreViewModel() { 
            this.SongList = new List<Song>();
            this.GenreList = new List<Genre>();
        }
    }
}
