using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public bool IsReserved { get; set; }

        public string? ReservationComment { get; set; }

        public virtual ICollection<StatusHistory> StatusHistories { get; set; } // One-to-many relationship
    }
}
