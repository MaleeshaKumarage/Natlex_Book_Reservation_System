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
    public class GetBookByTitleHandler : IRequestHandler<GetBookByTitle, Domain.Entities.Book>
    {
        private readonly IBookRepository _bookRepository;
        public GetBookByTitleHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Domain.Entities.Book> Handle(GetBookByTitle request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetBookByTitle(request.Title);
        }
    }
}
