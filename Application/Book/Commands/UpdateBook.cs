using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Commands
{
    public class UpdateBook : IRequest<Domain.Entities.Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsReserved { get; set; }
        public string? ReservationComment { get; set; }

    }
}
