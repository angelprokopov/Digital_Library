using AutoMapper;
using BookDetailsAPI.Data;
using BookDetailsAPI.Models;
using BookDetailsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace BookDetailsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookContext _context;
        private readonly GoogleBooksService _google;
        private readonly IMapper _mapper;

        public BooksController(BookContext context, GoogleBooksService google, IMapper mapper)
        {
            _context = context;
            _google = google;
            _mapper = mapper;
        }

        [HttpGet("{isbn}")]
        public async Task<ActionResult<SharedModels.Book>> GetBookByISBN(string isbn)
        {
            var externalBook = await _google.GetBookByISBN(isbn);
            
            var apiBook = _mapper.Map<BookDetailsAPI.Models.Book>(externalBook);
            _context.Books.Add(apiBook);
            await _context.SaveChangesAsync();

            var sharedBook = _mapper.Map<SharedModels.Book>(externalBook);
            return Ok(sharedBook);
        }
        
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SharedModels.Book>>> SearchBooksByTitle([FromQuery] string title)
        {
            if (string.IsNullOrEmpty(title))
                return BadRequest("Title cannot be empty");

            var googleBooks = await _google.GetBooksByTitle(title);
            if (googleBooks == null || !googleBooks.Any())
                return NotFound("No books found matching the title");

            var books = googleBooks.Select(MapDtoToEntity).ToList();

            var existingISBN = _context.Books.Select(b=>b.ISBN).ToHashSet();

            foreach(var book in books)
            {
                if(!existingISBN.Contains(book.ISBN))
                {
                    var dbBook = _mapper.Map<BookDetailsAPI.Models.Book>(book);
                    _context.Books.Add(dbBook);
                }
                   
            }

            await _context.SaveChangesAsync();

            return Ok(books);
        }

        private Models.Book MapDtoToEntity(GoogleBookDTO dto)
        {
            return new Models.Book
            {
                Title = dto.Title,
                Author = string.Join(", ", dto.Authors),
                Genre = string.Join(", ",dto.Categories),
                ISBN = dto.ISBN,
                CoverUrl = dto.ThumbnailUrl
            };
        }
    }
}
