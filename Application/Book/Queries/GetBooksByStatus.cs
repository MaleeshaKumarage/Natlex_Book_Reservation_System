using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Queries
{
    public class GetBooksByStatus : IRequest<ICollection<Domain.Entities.Book>>
    {
        public bool isReserved { get; set; }
    }
}
