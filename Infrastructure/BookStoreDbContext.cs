using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Book> books { get; set; }
        public DbSet<StatusHistory> statusHistory { get; set; }

        public void SeedData()
        {
            if (!books.Any())
            {
                var testData = new List<Book>
                {
                new Book {
                    Id = Guid.NewGuid(),
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    IsReserved = true,
                    ReservationComment = "Reserved for book club meeting",
                },
                new Book {
                    Id = Guid.NewGuid(),
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    IsReserved = false,
                    ReservationComment = "",
                },
                new Book {
                    Id = Guid.NewGuid(),
                    Title = "1984",
                    Author = "George Orwell",
                    IsReserved = true,
                    ReservationComment = "Reserved for university assignment",
                },
                new Book {
                    Id = Guid.NewGuid(),
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    IsReserved = false,
                    ReservationComment = "",
                },
                new Book {
                    Id = Guid.NewGuid(),
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    IsReserved = true,
                    ReservationComment = "Reserved for Jane's book club",
                },
                new Book {
                    Id = Guid.NewGuid(),
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    IsReserved = false,
                    ReservationComment = "",
                },
                new Book {
                    Id = Guid.NewGuid(),
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Author = "J.K. Rowling",
                    IsReserved = true,
                    ReservationComment = "Reserved for library event",
                },
                new Book {
                    Id = Guid.NewGuid(),
                    Title = "The Shining",
                    Author = "Stephen King",
                    IsReserved = false,
                    ReservationComment = "",
                },
                new Book {
                    Id = Guid.NewGuid(),
                    Title = "The Da Vinci Code",
                    Author = "Dan Brown",
                    IsReserved = true,
                    ReservationComment = "Reserved for book discussion group",
                },
                new Book {
                    Id = Guid.NewGuid(),
                    Title = "The Alchemist",
                    Author = "Paulo Coelho",
                    IsReserved = false,
                    ReservationComment = "",
                }
            };

                books.AddRange(testData);
                SaveChanges();
            }
        }

    }
}
