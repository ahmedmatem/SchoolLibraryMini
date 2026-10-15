namespace SchoolLibraryMini.Data.Entities
{
    public class Loan
    {
        public Guid LoanId { get; set; }

        public Guid BookId { get; set; }
        public Guid ReaderId { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        // Navigation properties
        public Book Book { get; set; } = null!;
        public Reader Reader { get; set; } = null!;
    }
}
