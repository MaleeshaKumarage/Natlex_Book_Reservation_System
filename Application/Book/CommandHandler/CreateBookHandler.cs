using Application.Abstraction;
using Application.Book.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.CommandHandler
{
    public class CreateBookHandler : IRequestHandler<CreateBook, Domain.Entities.Book>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Domain.Entities.Book> Handle(CreateBook request, CancellationToken cancellationToken)
        {
            var newBook = new Domain.Entities.Book
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Author = request.Author,
                //IsReserved = request.IsReserved,
                //ReservationComment = request.ReservationComment
            };
            return await _bookRepository.AddBook(newBook);

    }
}
}
