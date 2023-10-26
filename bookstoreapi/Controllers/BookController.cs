using AutoMapper;
using bookstoreapi.Application.BookOperations.Commands.CreateBook;
using bookstoreapi.Application.BookOperations.Commands.DeleteBook;
using bookstoreapi.Application.BookOperations.Queries.GetBookDetail;
using bookstoreapi.Application.BookOperations.Queries.GetBooks;
using bookstoreapi.Application.BookOperations.Commands.UpdateBook;
using bookstoreapp.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static bookstoreapi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static bookstoreapi.Application.BookOperations.Queries.GetBookDetail.GetBookDetailQuery;
using static bookstoreapi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using bookstoreapi.DbOperations;

namespace bookstoreapi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class BookController : ControllerBase
    {
        IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(IBookStoreDbContext context, IMapper mapper)
        {
            _context= context;
            _mapper= mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            GetBooksQuery vm = new GetBooksQuery(_context,_mapper);
            
            return Ok(await vm.Handle()) ;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var result = new  BookDetailModel();
            var vm = new GetBookDetailQuery(_context, _mapper);
            vm.id = id;
            result = await vm.Handle();

            return Ok(result);
         }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookModel book,CancellationToken cancellationToken)
        {
            CreateBookCommand vm = new CreateBookCommand(_context, _mapper);
            vm.model = book;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(vm);
            vm.Handlle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook (int id, [FromBody] UpdateBookModel book)
        {
            var command = new UpdateBookCommand(_context);
            command.BookId = id;
            command.model = book;
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook (int id)
        {
            var vm = new DeleteBookCommand(_context);
            vm.bookId = id;
            DeleteBookCommandValidation validator = new DeleteBookCommandValidation();
            validator.ValidateAndThrow(vm);
            vm.Handle();

            return Ok();
        }
    }
}