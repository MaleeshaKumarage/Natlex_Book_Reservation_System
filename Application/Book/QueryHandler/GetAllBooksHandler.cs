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
    public class GetAllBooksHandler : IRequestHandler<GetAllBooks, ICollection<Domain.Entities.Book>>
    {
        private readonly IBookRepository _bookRepository;
        public GetAllBooksHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        async Task<ICollection<Domain.Entities.Book>> IRequestHandler<GetAllBooks, ICollection<Domain.Entities.Book>>.Handle(GetAllBooks request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetAllBooks();
        }
    }
}
