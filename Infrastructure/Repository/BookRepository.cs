using Application.Abstraction;
using Domain.Entities;
using Domain.Exceptions;
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
            var savedBook = await _bookStoreDbContext.books.AddAsync(book);
            await _bookStoreDbContext.SaveChangesAsync();
            return savedBook.Entity;
        }

        public async Task<Book> AddReservation(Guid bookId, string reservationComment)
        {
            var existingBook = await _bookStoreDbContext.books.FindAsync(bookId);
            if (existingBook == null)
            {
                throw new NoBookFoundException("Unable to find the specified book");
            }
            else if (existingBook.IsReserved)
            {
                throw new BookAlreadyReservedException("The requested book has already been reserved by another user");
            }
            
            existingBook.IsReserved = true;
            existingBook.ReservationComment = reservationComment;


            await _bookStoreDbContext.SaveChangesAsync();
            return existingBook;
        }

        public async Task<Book> DeleteBook(Guid id)
        {
            var book = _bookStoreDbContext.books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                var deletedBook = _bookStoreDbContext.books.Remove(book);
                await _bookStoreDbContext.SaveChangesAsync();
                return deletedBook.Entity;
            }
            return null;
        }

        public Task<List<Book>> GetAllBooks()
        {
            return _bookStoreDbContext.books.ToListAsync();

        }

        public async Task<Book?> GetBookById(Guid id)
        {
            var book = await _bookStoreDbContext.books.FirstOrDefaultAsync(b => b.Id == id);
            if (book != null)
            {
                return book;
            }
            return null;
        }

        public async Task<Book> GetBookByTitle(string name)
        {
            var book = await _bookStoreDbContext.books.Where(b => b.Title == name).FirstOrDefaultAsync();
            return book;
        }

        public async Task<List<Book>> GetBooksByStatus(bool isReserved)
        {
            return _bookStoreDbContext.books.Where(a => a.IsReserved == isReserved).ToList();
        }

        public async Task<Book> RemoveReservation(Guid bookId)
        {
            var existingBook = await _bookStoreDbContext.books.FindAsync(bookId);
            if (existingBook == null)
            {
                return null;
            }
            existingBook.IsReserved = false;

            await _bookStoreDbContext.SaveChangesAsync();
            return existingBook;
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
