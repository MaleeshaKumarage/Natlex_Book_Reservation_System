using Application.Abstraction;
using Application.StatusHistory.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StatusHistory.QueryHandler
{
    public class GetStatusHistoryHandler : IRequestHandler<GetStatusHistory, ICollection<Domain.Entities.StatusHistory>>
    {
        private readonly IStatusHistoryRepository _statusHistoryRepository;
        public GetStatusHistoryHandler(IStatusHistoryRepository statusHistoryRepository)
        {
            _statusHistoryRepository = statusHistoryRepository;
        }

        public async Task<ICollection<Domain.Entities.StatusHistory>> Handle(GetStatusHistory request, CancellationToken cancellationToken)
        {
           return await _statusHistoryRepository.GetStatusHistoryByBookId(request.BookId);
        }
    }

}
