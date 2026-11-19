using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolLibraryMini.Data.Entities
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; } = string.Empty;

        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }

        [Required]
        [MaxLength(13)]
        public string ISBN { get; set; } = string.Empty;

        [Required]
        public int PublicationYear { get; set; }
        public int TotalCopies { get; set; }

        // Navigation properties
        public Author Author { get; set; } = null!;

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
