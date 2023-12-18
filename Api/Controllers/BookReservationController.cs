using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BookReservationController : ControllerBase
    {
        //private readonly IBookService _bookService;

        public BookReservationController(/*IBookService bookService*/)
        {
            //_bookService = bookService;
        }

        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveBook(int id /*,[FromBody] ReserveRequest request*/)
        {
            //var success = await _bookService.ReserveBookAsync(id, request.Comment);
            //if (!success)
            //{
            //    return NotFound($"Book with ID {id} not found or already reserved");
            //}

            return Ok();
        }

        [HttpPost("remove-reservation")]
        public async Task<IActionResult> RemoveReservation(int id)
        {
            //var success = await _bookService.RemoveReservationAsync(id);
            //if (!success)
            //{
            //    return NotFound($"Book with ID {id} not found or not reserved");
            //}

            return Ok();
        }

        [HttpGet("status-history/{id}")]
        public async Task<IActionResult> GetStatusHistory(int id)
        {
            //var statusHistory = await _bookService.GetStatusHistoryAsync(id);
            //if (statusHistory == null)
            //{
            //    return NotFound($"Book with ID {id} not found");
            //}

            return Ok(/*statusHistory*/);
        }
    }
}
