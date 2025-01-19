namespace BookDetailsAPI.Data
{
    public class GoogleBookDTO
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public List<string> Categories { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ISBN { get; set; }
    }
}
