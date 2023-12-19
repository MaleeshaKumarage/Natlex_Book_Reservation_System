using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Commands
{
    public class CreateReservation : IRequest<Domain.Entities.StatusHistory>
    {
        public Guid BookId { get; set; }
        public string ReservationComment { get; set; }
    }
}
