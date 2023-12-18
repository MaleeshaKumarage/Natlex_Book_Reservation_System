using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class StatusHistory
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public bool IsReserved { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
