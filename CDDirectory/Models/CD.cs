using System.ComponentModel.DataAnnotations;

namespace CDDirectory.Models {
    public class CD {
        //properties
        public int CDId { get; set; }
        [Required(ErrorMessage = "Ange en titel")]
        [Display(Name= "Titel")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Ange en genre")]
        [Display(Name= "Genre")]
        public string? Genre { get; set; }
        [Required(ErrorMessage = "Ange en artist")]
        [Display(Name= "Artist")]
        public int ArtistId { get; set; }
        [Display(Name= "Artist")]
        public Artist? Artist { get; set; }
        [Display(Name= "Användare")]
        public int? UserId { get; set; }
        [Display(Name= "Användare")]
        public User? User { get; set; }

    }
}