namespace CDDirectory.Models {

    public class User {
        //properties
        public int UserId { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }

        public ICollection<CD>? CD { get; set; } 

    }
}