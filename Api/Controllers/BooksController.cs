﻿using Application.Book.Commands;
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
        public async Task<IResult> GetAllBooks()
        {
            var getAllBooks = new GetAllBooks();


            var books = await _mediator.Send(getAllBooks);
            if (books == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(books);
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

            await _mediator.Send(book);

            return TypedResults.Ok(book);
        }

        // PUT api/<BooksController>/5
        [HttpPut]
        public async Task<IResult> Put([FromBody] UpdateBook updateBook)
        {
            var updatedBook = await _mediator.Send(updateBook);
            return TypedResults.Ok(updatedBook);
        }

        // DELETE api/<BooksController>/5
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
