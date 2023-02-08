using System.ComponentModel.DataAnnotations;

namespace CDDirectory.Models {
    public class CD {
        //properties
        public int CDId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Genre { get; set; }
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

    }
}