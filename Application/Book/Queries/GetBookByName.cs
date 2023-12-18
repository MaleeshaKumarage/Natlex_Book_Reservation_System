using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Queries
{
    public class GetBookByTitle : IRequest<Domain.Entities.Book>
    {
        public string Title { get; set; }
    }
}
