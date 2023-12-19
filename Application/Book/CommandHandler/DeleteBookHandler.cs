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
    public class DeleteBookHandler : IRequestHandler<DeleteBook, Domain.Entities.Book>
    {
        public readonly IBookRepository _bookRepository;
        public DeleteBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Domain.Entities.Book> Handle(DeleteBook request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookById(request.Id);

            if (book != null)
            {
                await _bookRepository.DeleteBook(request.Id);
                return book;
            }
            else
            {
                return null;
            }
        }
    }
}
