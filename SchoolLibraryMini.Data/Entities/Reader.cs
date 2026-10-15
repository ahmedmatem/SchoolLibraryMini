using System.ComponentModel.DataAnnotations;

namespace SchoolLibraryMini.Data.Entities
{
    public class Reader
    {
        [Key]
        public Guid ReaderId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
