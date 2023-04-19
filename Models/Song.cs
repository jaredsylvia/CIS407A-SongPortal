using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SongManagement.Models
{
    public class Song
    {
        //attributes
        private int id;
        private string artist;
        private string title;
        private int genreId;
        private DateTime releaseDate;

        //constructors
        public Song() {
            id = 0;
            artist = "Fleetwood Mac";
            title = "Chains";
            genreId = 0;
            releaseDate = new DateTime(1977,2,4);
        }

        //setters and getters
        [Key]
        public int Id { get { return id; } set { id = value; } }
        [Required(ErrorMessage = "Artist name is required.")]
        [StringLength(32, ErrorMessage = "Artist name must be less than 128 characters.")]
        public string Artist { get { return artist; } set { artist = value; } }
        [Required(ErrorMessage = "Song title is required.")]
        [StringLength(32, ErrorMessage = "Song title must be less than 256 characters.")]
        public string Title { get { return title; } set { title = value; } }
        [Required(ErrorMessage = "Genre is required.")]
        [ForeignKey("Genre")]
        public int GenreId { get {  return genreId; } set {  genreId = value; } }
        [Required(ErrorMessage = "Release Date is required.")]
        [Range(typeof(DateTime), "4/9/1860", "12/31/9999", ErrorMessage = "Start Date must be after 4/9/1860.")]
        public DateTime ReleaseDate { get {  return releaseDate; } set {  releaseDate = value; } }


        
        
    }
}
