﻿using Application.Abstraction;
using Application.Book.Commands;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.CommandHandler
{
    public class CreateReservationHandler : IRequestHandler<CreateReservation, Domain.Entities.StatusHistory>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IStatusHistoryRepository _statusHistoryRepository;
        public CreateReservationHandler(IBookRepository bookRepository, IStatusHistoryRepository statusHistoryRepository)
        {
            _bookRepository = bookRepository;
            _statusHistoryRepository = statusHistoryRepository;
        }

        public async Task<Domain.Entities.StatusHistory> Handle(CreateReservation request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookById(request.BookId);
            if (book != null)
            {
                try
                {
                    await _bookRepository.AddReservation(request.BookId);
                    return await _statusHistoryRepository.AddStatusHistory(request.BookId,true);

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return null;
        }

    }
}
