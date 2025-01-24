using Newtonsoft.Json;

namespace BookDetailsAPI.Data
{
    public class OpenLibraryBookDTO
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string CoverUrl { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public string PublishDate { get; set; }
        public List<string> Subjects { get; set; }
    }

    public class OpenLibraryResponse
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("authors")]
        public List<OpenLibraryAuthor> Authors { get; set; }

        [JsonProperty("identifiers")]
        public OpenLibraryIdentifiers Identifiers { get; set; }

        [JsonProperty("publishers")]
        public List<OpenLibraryPublisher> Publishers { get; set; }

        [JsonProperty("publish_date")]
        public string PublishDate { get; set; }

        [JsonProperty("subjects")]
        public List<OpenLibrarySubject> Subjects { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class OpenLibraryAuthor
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class OpenLibraryIdentifiers
    {
        [JsonProperty("isbn_13")]
        public List<string> Isbn13 { get; set; }
    }

    public class OpenLibraryPublisher
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class OpenLibrarySubject
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

}
