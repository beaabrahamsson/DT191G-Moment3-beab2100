using System.ComponentModel.DataAnnotations;
namespace CDDirectory.Models {

    public class Artist {
        //properties
        [Display(Name= "ID")]
        public int ArtistId { get; set; }
        [Required(ErrorMessage = "Ange ett namn")]
        [Display(Name= "Artistnamn")]
        public string? Name { get; set; }

        public ICollection<CD>? CD { get; set; } 

    }
}