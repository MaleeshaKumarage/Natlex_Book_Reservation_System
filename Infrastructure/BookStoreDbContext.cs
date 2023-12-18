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

    }
}
