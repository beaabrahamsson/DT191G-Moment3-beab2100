using System.ComponentModel.DataAnnotations;
namespace CDDirectory.Models {

    public class User {
        //properties
        [Display(Name= "ID")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Ange ett namn på användare")]
        [Display(Name= "Användare")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Ange ett datum")]
        [Display(Name= "Datum för utlåning")]
        public DateTime Date { get; set; }

        public ICollection<CD>? CD { get; set; } 

    }
}