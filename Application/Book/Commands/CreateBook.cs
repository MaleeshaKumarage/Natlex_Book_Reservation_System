using MediatR;

namespace Application.Book.Commands
{
    public class CreateBook : IRequest<Domain.Entities.Book>
    {
        public Guid BookId { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsReserved { get; set; } = false;
        public string? ReservationComment { get; set; } = string.Empty;

    }
}
