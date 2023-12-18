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

        public Task<List<Book>> GetAllBooks()
        {
            return _bookStoreDbContext.books.ToListAsync();

        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _bookStoreDbContext.books.FirstOrDefaultAsync(b => b.Id == id);

        }

        public async Task<Book> GetBookByTitle(string name)
        {
            var book = await _bookStoreDbContext.books.FirstOrDefaultAsync(b => b.Title == name);

            return book;
        }

        public async Task<Book> UpdateBook(Guid Id, Book book)
        {
            var existingBook = await _bookStoreDbContext.books.FindAsync(Id);
            if (existingBook == null)
            {
                return null;
            }
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.IsReserved = book.IsReserved;
            existingBook.ReservationComment = book.ReservationComment;


            await _bookStoreDbContext.SaveChangesAsync();
            return existingBook;
        }
    }
}
