using Application.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        public BookRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public async Task<Book> AddBook(Book book)
        {
            _bookStoreDbContext.books.Add(book);
            await _bookStoreDbContext.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBook(Guid id)
        {
            var book = _bookStoreDbContext.books.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                return;
            }
            _bookStoreDbContext.books.Remove(book);
            await _bookStoreDbContext.SaveChangesAsync();

        }

        public Task<ICollection<Book>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> GetBookByTitle(string name)
        {
            var book = await _bookStoreDbContext.books.FirstOrDefaultAsync(b => b.Title == name);

            return book;
        }

        public Task<Book> UpdateBook(Guid id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
