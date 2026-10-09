namespace SchoolLibraryMini.Data.Entities
{
    public class Loan
    {
        public Guid LoanId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
