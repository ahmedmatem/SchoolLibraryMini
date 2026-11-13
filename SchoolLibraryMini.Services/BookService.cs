using Microsoft.EntityFrameworkCore;
using SchoolLibraryMini.Data;
using SchoolLibraryMini.Data.Entities;
using SchoolLibraryMini.Services.Contracts;

namespace SchoolLibraryMini.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _db;

        public BookService(LibraryDbContext context)
        {
            _db = context;
        }

        public async Task Create(string title, string author)
        {
            var _author = await _db.Authors.FirstOrDefaultAsync(a => a.Name == author);

            if (_author is null)
            {
                _author = new Author
                {
                    AuthorId = Guid.NewGuid(),
                    Name = author
                };
                _db.Authors.Add(_author);
            }

            var book = new Book
            {
                BookId = Guid.NewGuid(),
                Title = title,
                ISBN = Guid.NewGuid().ToString()[..13],
                PublicationYear = 2026,
                TotalCopies = 10,
                AuthorId = _author.AuthorId,
                Author = _author
            };

            _db.Books.Add(book);
            await _db.SaveChangesAsync();
        }

        public Task<List<Book>> GetAll()
        {
            return _db.Books
                    .OrderBy(b => b.Title)
                    .ToListAsync();
        }
    }
}
