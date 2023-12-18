using Application.Abstraction;
using Application.Book.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.QueryHandler
{
    public class GetBooksByStatusHandler : IRequestHandler<GetBooksByStatus, ICollection<Domain.Entities.Book>>
    {
        private readonly IBookRepository _bookRepository;
        public GetBooksByStatusHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ICollection<Domain.Entities.Book>> Handle(GetBooksByStatus request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetBooksByStatus(request.isReserved);
        }
    }
}
