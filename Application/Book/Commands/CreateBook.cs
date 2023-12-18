using MediatR;

namespace Application.Book.Commands
{
    public class CreateBook : IRequest<Domain.Entities.Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }

    }
}
