using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Queries
{
    public class GetBookById : IRequest<Domain.Entities.Book>
    {
        public Guid Id { get; set; }
    }
}
