using Application.Abstraction;
using Application.Book.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StatusHistory.Queries
{
    public class GetStatusHistory : IRequest<ICollection<Domain.Entities.StatusHistory>>
    {
        public Guid BookId { get; set; }
    }
}
