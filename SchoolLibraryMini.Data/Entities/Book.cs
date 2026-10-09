namespace SchoolLibraryMini.Data.Entities
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public DateOnly PublicationYear { get; set; }
        public int TotalCopies { get; set; }
    }
}
