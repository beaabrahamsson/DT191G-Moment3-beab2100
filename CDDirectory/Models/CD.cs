namespace CDDirectory.Models {
    public class CD {
        //properties
        public int CDId { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }

    }
}