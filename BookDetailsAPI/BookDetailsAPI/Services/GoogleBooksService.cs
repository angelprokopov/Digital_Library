using BookDetailsAPI.Data;
using BookDetailsAPI.Models;
using System.Text.Json;

namespace BookDetailsAPI.Services
{
    public class GoogleBooksService
    {
        private readonly HttpClient _httpClient;

        public GoogleBooksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GoogleBookDTO>> GetBooksByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Title cannot be null or empty", nameof(title));
            var apiUrl = $"https://www.googleapis.com/books/v1/volumes?q=intitle:{Uri.EscapeDataString(title)}";

            var response = await _httpClient.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Google Books API request failed: {response.ReasonPhrase}");

            var googleBooksResponse = await response.Content.ReadFromJsonAsync<GoogleBooksApiResponse>();
            var books = new List<GoogleBookDTO>();
            if(googleBooksResponse?.Items != null)
            {
                foreach(var item in googleBooksResponse.Items)
                {
                    books.Add(new GoogleBookDTO
                    {
                        Title = item.VolumeInfo.Title,
                        Authors = item.VolumeInfo.Authors ?? new List<string>(),
                        Categories = item.VolumeInfo.Categories ?? new List<string>(),
                        ThumbnailUrl = item.VolumeInfo.ImageLinks?.Thumbnail,
                        ISBN = item.VolumeInfo.IndustryIdentifiers?.FirstOrDefault().Identifier
                    });
                }
            }

            return books;
        }

        public async Task<Book> GetBookByISBN(string isbn)
        {
            var response = await _httpClient.GetAsync($"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(content);

            var volumeInfo = json.RootElement.GetProperty("items")[0].GetProperty("volumeInfo");

            return new Book
            {
                ISBN = isbn,
                Title = volumeInfo.GetProperty("title").GetString(),
                Author = string.Join(", ",volumeInfo.GetProperty("authors").EnumerateArray()),
                Genre = volumeInfo.GetProperty("categories").EnumerateArray().FirstOrDefault().GetString(),
                CoverUrl = volumeInfo.GetProperty("imageLinks").GetProperty("thumbnail").GetString()
            };
        }
    }
}
