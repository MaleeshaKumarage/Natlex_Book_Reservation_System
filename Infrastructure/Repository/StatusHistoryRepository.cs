using Application.Abstraction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class StatusHistoryRepository : IStatusHistoryRepository
    {

        private readonly BookStoreDbContext _bookStoreDbContext;

        public StatusHistoryRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public async Task<StatusHistory> AddStatusHistory(Guid id, bool isReserved)
        {
            var statusHistory = new StatusHistory()
            {
                Id = Guid.NewGuid(),
                BookId = id,
                IsReserved = isReserved,
                Timestamp = DateTime.Now,
            };

            _bookStoreDbContext.statusHistory.Add(statusHistory);
            _bookStoreDbContext.SaveChanges();

            return statusHistory;

        }

        public async Task<List<StatusHistory>> GetStatusHistoryByBookId(Guid id)
        {
            var x = _bookStoreDbContext.statusHistory.ToList();
            return _bookStoreDbContext.statusHistory.Where(b => b.BookId == id).ToList();
        }
    }
}
