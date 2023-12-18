using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstraction
{
    public interface IBookRepository
    {
        Task<List<Domain.Entities.Book>> GetAllBooks();
        Task<Domain.Entities.Book> AddBook(Domain.Entities.Book book);
        Task<Domain.Entities.Book> GetBookById(Guid id);
        Task<Domain.Entities.Book> GetBookByTitle(string name);
        Task<Domain.Entities.Book> UpdateBook(Guid id, Domain.Entities.Book book);
        Task<Domain.Entities.Book> AddReservation(Guid bookId);
        Task<Domain.Entities.Book> RemoveReservation(Guid bookId);
        Task<Domain.Entities.Book> DeleteBook(Guid id);
        Task<List<Domain.Entities.Book>> GetBooksByStatus(bool isReserved);

    }
}
