﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Commands
{
    public class RemoveReservation : IRequest<Domain.Entities.StatusHistory>
    {
        public Guid BookId { get; set; }
    }
}
