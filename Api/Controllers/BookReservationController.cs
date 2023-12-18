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
    public class BookReservationController : ControllerBase
    {
        public readonly IMediator _mediator;

        public BookReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("reserve")]
        public async Task<IResult> ReserveBook(Guid bookId)
        {
            try
            {

                var reservation = await _mediator.Send(new CreateReservation()
                {
                    BookId = bookId
                });
                if (reservation is null)
                {
                    return TypedResults.NotFound();
                }
                return TypedResults.Ok(reservation);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("remove-reservation")]
        public async Task<IResult> RemoveReservation(Guid bookId)
        {
            try
            {
                var removedReservation = await _mediator.Send(new RemoveReservation()
                {
                    BookId = bookId
                });
                if (removedReservation is null)
                {
                    return TypedResults.NotFound();
                }
                return TypedResults.Ok(removedReservation);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpGet("status-history/{bookId}")]
        public async Task<IActionResult> GetStatusHistory(Guid bookId)
        {
            try
            {

                var statusHistory = await _mediator.Send(new GetStatusHistory()
                {
                    BookId = bookId
                });

                return Ok(statusHistory);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
