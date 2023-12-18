using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction
{
    public interface IStatusHistoryRepository
    {
        Task<StatusHistory> GetStatusHistoryByBookId(Guid id);
        Task<StatusHistory> UpdateStatusHistoryByBookId(Guid id, StatusHistory statusHistory);
    }
}
