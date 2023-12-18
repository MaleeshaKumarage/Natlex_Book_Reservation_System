using Application.Book.Commands;
using Application.Book.Queries;
using Application.StatusHistory.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReservationController : ControllerBase
    {
        public readonly IMediator _mediator;

        public BookReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveBook(Guid bookId)
        {


            var reservation = await _mediator.Send(new CreateReservation()
            {
                BookId = bookId
            });
            if (reservation != null)
            {
                return NotFound("The specified book was not found.");
            }
            return Ok(reservation);
        }



        [HttpPost("remove-reservation")]
        public async Task<IActionResult> RemoveReservation(Guid bookId)
        {
            var removedReservation = await _mediator.Send(new RemoveReservation()
            {
                BookId = bookId
            });
            if (removedReservation is null)
            {
                return NotFound("The specified book was not found.");
            }
            return Ok(removedReservation);
        }



        [HttpGet("status-history/{bookId}")]
        public async Task<IActionResult> GetStatusHistory(Guid bookId)
        {

            var statusHistory = await _mediator.Send(new GetStatusHistory()
            {
                BookId = bookId
            });

            if (statusHistory == null)
            {
                return NotFound($"No status history found for BookId: {bookId}");
            }

            return Ok(statusHistory);
        }
    }
}
