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
    public class RemoveReservationHandler : IRequestHandler<RemoveReservation, Domain.Entities.StatusHistory>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IStatusHistoryRepository _statusHistoryRepository;
        public RemoveReservationHandler(IBookRepository bookRepository, IStatusHistoryRepository statusHistoryRepository)
        {
            _bookRepository = bookRepository;
            _statusHistoryRepository = statusHistoryRepository;
        }

        public async Task<Domain.Entities.StatusHistory> Handle(RemoveReservation request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookById(request.BookId);
            if (book != null)
            {
                await _bookRepository.RemoveReservation(request.BookId);
                return await _statusHistoryRepository.AddStatusHistory(request.BookId,false);

            }

            return null;
        }

    }
}
