using SchoolLibraryMini.Data.Entities;

namespace SchoolLibraryMini.Data
{
    public static class DemoData
    {
        public static void Seed(LibraryDbContext db)
        {
            const string demoIsbn = "9780000000002";

            if (db.Books.Any(b => b.ISBN == demoIsbn))
            {
                return;
            }

            var author = db.Authors.FirstOrDefault(a => a.Name == "Иван Вазов");

            if (author is null)
            {
                author = new Author
                {
                    AuthorId = Guid.NewGuid(),
                    Name = "Иван Вазов"
                };
                db.Authors.Add(author);
            }

            var book = new Book
            {
                BookId = Guid.NewGuid(),
                Title = "Под игото",
                ISBN = demoIsbn,
                PublicationYear = 1894,
                TotalCopies = 3,
                AuthorId = author.AuthorId,
                Author = author
            };

            db.Books.Add(book);
            db.SaveChanges();

        }

    }
}
