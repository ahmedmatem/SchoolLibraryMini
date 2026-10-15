using System.ComponentModel.DataAnnotations;

namespace SchoolLibraryMini.Data.Entities
{
    public class Author
    {
        //[Key]
        public Guid AuthorId { get; set; }

        //[Required]
        //[MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
