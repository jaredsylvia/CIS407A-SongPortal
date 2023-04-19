using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace SongManagement.Models
{
    public class Genre
    {
        //attributes
        private int id;
        private string name;
        private string description;

        //constructors
        public Genre() { 
            id = 0;
            name = "Rock";
            description = "Our amps go to 11, 11 is louder than 10.";
        }

        //getters and setters
        [Key]
        public int Id { get { return id; } set { id = value; } }
        [Required(ErrorMessage = "Please enter a name for this genre.")]
        [StringLength(16, ErrorMessage = "Genre name must be 16 characters or less.")]
        public string Name { get { return name; } set { name = value; } }
        [Required(ErrorMessage = "Please enter a description for this genre.")]
        [StringLength(128, ErrorMessage = "Descriptions must be 128 characters or less.")]
        public string Description { get { return description; } set { description = value; } }
        

    }
}
