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
    public class GetBookByIdHandler : IRequestHandler<GetBookById, Domain.Entities.Book>
    {
        private readonly IBookRepository _bookRepository;
        public GetBookByIdHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Domain.Entities.Book> Handle(GetBookById request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetBookById(request.Id);
        }
    }
}
