using SchoolLibraryMini.Data.Entities;

namespace SchoolLibraryMini.Services.Contracts
{
    public interface IBookService
    {
        Task<List<Book>> GetAll();

        Task Create(string title, string author);
    }
}
