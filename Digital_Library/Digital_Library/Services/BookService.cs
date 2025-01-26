using Microsoft.CodeAnalysis.CSharp.Syntax;
using SharedModels;

namespace Digital_Library.Services
{
    public class BookService
    {
        private readonly HttpClient _httpClient;
        public BookService(HttpClient httpClient) { _httpClient = httpClient; }

        public async Task<List<Book>> GetBooksAsync()
        {
            var response = await _httpClient.GetAsync("https://bookdetailsapi.azurewebsites.net/api/Books");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<Book>>();

            throw new HttpRequestException($"Failed to fetch books: {response.ReasonPhrase}");
        }

        public async Task<Book> GetBookByISBNAsync(string isbn)
        {
            return await _httpClient.GetFromJsonAsync<Book>($"api/Books/{isbn}");
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Books", book);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Book>();
        }

        public async Task<List<Book>> SearchBookByTitleAsync(string title)
        {
            var response = await _httpClient.GetAsync($"api/Books/search?title={Uri.EscapeDataString(title)}");
            
            if(response.IsSuccessStatusCode)
            {
                var books = await response.Content.ReadFromJsonAsync<List<Book>>();
                return books ?? new List<Book>();
            }
            else
            {
                throw new Exception("Failed to fetch books from the API");
            }
        }
    }
}
