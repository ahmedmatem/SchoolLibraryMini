using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolLibraryMini.Data.Entities
{
    public class Loan
    {
        [ForeignKey("Book")]
        public Guid BookId { get; set; }

        [ForeignKey("Reader")]
        public Guid ReaderId { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        // Navigation properties
        public Book Book { get; set; } = null!;
        public Reader Reader { get; set; } = null!;

    }
}
