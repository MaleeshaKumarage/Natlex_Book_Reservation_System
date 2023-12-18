using Application.Book.Commands;
using Application.Book.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var request = new GetAllBooks();

            var books = await _mediator.Send(request);
            return books.Count > 0
            ? Ok(books)
            : NotFound("Oops! It seems like the bookstore is currently empty. We searched high and low, but couldn't find any books");
        }

        [HttpGet("status/{isReserved}")]
        public async Task<IActionResult> GetBooksByStatus([FromRoute] bool isReserved)
        {
            var request = new GetBooksByStatus()
            {
                isReserved = isReserved
            };

            var books = await _mediator.Send(request);
            if (books == null || !books.Any())
            {
                string statusMessage = isReserved ? "No reserved books were found" : "No non-reserved books were found";
                return NotFound(statusMessage);
            }
            return Ok(books);
        }

        [HttpGet("{title}")]
        public async Task<IActionResult> GetBookByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest("Title cannot be empty or null.");
            }

            var request = new GetBookByTitle
            {
                Title = title
            };
            var book = await _mediator.Send(request);

            if (book == null)
            {
                return NotFound($"No book found with the title: {title}");
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBook book)
        {
            if (book == null)
            {
                return BadRequest("Invalid request. The book data is missing.");
            }

            var createdBook = await _mediator.Send(book);
            if (createdBook == null)
            {
                return BadRequest("The request to create the book failed");
            }
            return Ok(createdBook);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateBook updateBook)
        {
            var updatedBook = await _mediator.Send(updateBook);
            if (updatedBook == null)
            {
                return NotFound("The specified book was not found.");
            }
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            var deleteBook = new DeleteBook()
            {
                Id = id
            };
            await _mediator.Send(deleteBook);
        }
    }
}
