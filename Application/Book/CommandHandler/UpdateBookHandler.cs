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
    public class UpdateBookHandler : IRequestHandler<UpdateBook, Domain.Entities.Book>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Domain.Entities.Book> Handle(UpdateBook request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var toBeUpdated = new Domain.Entities.Book()
                {
                    Id = request.Id,
                    Title = request.Title,
                    Author = request.Author,
                    IsReserved = request.IsReserved,
                    ReservationComment = request.ReservationComment
                };
                await _bookRepository.UpdateBook(request.Id,toBeUpdated);
                return toBeUpdated;
            }
            else
            {
                // You might want to throw an exception or handle it according to your requirements.
                return null;
            }
        }
    }
}
