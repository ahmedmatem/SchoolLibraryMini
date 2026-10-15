using Microsoft.EntityFrameworkCore;
using SchoolLibraryMini.Data.Entities;

namespace SchoolLibraryMini.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Reader> Readers => Set<Reader>();
        public DbSet<Loan> Loans => Set<Loan>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.AuthorId);
                entity.Property(a => a.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.BookId);

                entity.Property(b => b.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(b => b.ISBN)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.HasIndex(b => b.ISBN).IsUnique();

                // One Author has many Books
                entity.HasOne<Author>()
                    .WithMany(a => a.Books)
                    .HasForeignKey(b => b.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Loan>(entity => {
                entity.HasKey(l => new { l.BookId, l.ReaderId });

                // One Book has many Loans
                entity.HasOne(l => l.Book)
                    .WithMany(b => b.Loans)
                    .HasForeignKey(l => l.BookId)
                    .OnDelete(DeleteBehavior.Cascade);

                // One Reader has many Loans
                entity.HasOne(l => l.Reader)
                    .WithMany(r => r.Loans)
                    .HasForeignKey(l => l.ReaderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
