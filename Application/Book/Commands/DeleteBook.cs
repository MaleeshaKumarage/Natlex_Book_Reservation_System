using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Commands
{
    public class DeleteBook : IRequest<Domain.Entities.Book>
    {
        public Guid Id { get; set; }
    }
}
