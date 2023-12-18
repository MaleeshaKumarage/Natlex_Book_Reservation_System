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
        Task<Domain.Entities.StatusHistory> AddStatusHistory(Guid id,bool isReserved);
        Task<List<Domain.Entities.StatusHistory>> GetStatusHistoryByBookId(Guid id);
    }
}
