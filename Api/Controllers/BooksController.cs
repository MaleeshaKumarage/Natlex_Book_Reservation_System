using Application.Book.Commands;
using Application.Book.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BooksController>/5
        [HttpGet("{title}")]
        public async Task<IResult> GetBookByTitle(string title)
        {
            var getBook = new GetBookByTitle
            {
                Title = title
            };
            var book = await _mediator.Send(getBook);
            if (book == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] CreateBook book)
        {
            try
            {

                await _mediator.Send(book);
            }
            catch (Exception ex)
            {

                throw;
            }
            return TypedResults.Ok(book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
