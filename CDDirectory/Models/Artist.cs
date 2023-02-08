namespace CDDirectory.Models {

    public class Artist {
        //properties
        public int ArtistId { get; set; }
        public string? Name { get; set; }

        public ICollection<CD>? CD { get; set; } 

    }
}