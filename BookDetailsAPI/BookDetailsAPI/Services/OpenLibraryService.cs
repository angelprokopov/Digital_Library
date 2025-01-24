using BookDetailsAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using static BookDetailsAPI.Data.OpenLibraryBookDTO;

namespace BookDetailsAPI.Services
{
    public class OpenLibraryService
    {
        private readonly HttpClient _httpClient;
        public OpenLibraryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OpenLibraryBookDTO> GetBooksByISBN(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
                throw new ArgumentException("ISBN cannot be null or empty", nameof(isbn));

            var apiUrl = $"https://openlibrary.org/api/books?bibkeys=ISBN:{isbn}&format=json&jscmd=data";

            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Open Library API request failed: {response.ReasonPhrase}");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<Dictionary<string, OpenLibraryResponse>>(jsonResponse);
            if (data == null || !data.ContainsKey($"ISBN:{isbn}")) return null;

            var bookData = data[$"ISBN:{isbn}"];

            return new OpenLibraryBookDTO
            {
                Title = bookData.Title,
                Authors = bookData.Authors?.Select(a=>a.Name).ToList(),
                CoverUrl = bookData.Url,
                ISBN = isbn,
                Publisher = bookData.Publishers?.FirstOrDefault()?.Name,
                PublishDate = bookData.PublishDate,
                Subjects = bookData?.Subjects.Select(s=>s.Name).ToList()
            };
        }
    }
}
