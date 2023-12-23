using Application.Book.Commands;
using Application.Book.Queries;
using Application.StatusHistory.Queries;
using Domain.Entities;
using Domain.Exceptions;
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
        private readonly ILogger<BookReservationController> _logger;

        public BookReservationController(ILogger<BookReservationController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Reserve a book with reservation comment
        /// </summary>
        /// <returns></returns>
        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveBook(Guid bookId, string reservationComment)
        {
            try
            {

                var reservation = await _mediator.Send(new CreateReservation()
                {
                    BookId = bookId,
                    ReservationComment = reservationComment
                });
                return Ok(reservation);
            }
            catch (NoBookFoundException ex)
            {
                _logger.LogInformation(ex.Message, bookId, reservationComment);
                return NotFound(ex.Message);
            }
            catch (BookAlreadyReservedException ex)
            {
                _logger.LogInformation(ex.Message,bookId,reservationComment);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove existing Reservation
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Get Status History of a book by Book Id
        /// </summary>
        /// <returns></returns>
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
