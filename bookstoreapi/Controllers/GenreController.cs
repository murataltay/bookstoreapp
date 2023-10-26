using AutoMapper;
using bookstoreapi.Application.BookOperations.Commands.CreateBook;
using bookstoreapi.Application.GenreOperations.Commands.CreateGenre;
using bookstoreapi.Application.GenreOperations.Commands.DeleteGenre;
using bookstoreapi.Application.GenreOperations.Commands.UpdateGenre;
using bookstoreapi.Application.GenreOperations.Queries.GetGenreDetail;
using bookstoreapi.Application.GenreOperations.Queries.GetGenres;
using bookstoreapp.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static bookstoreapi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static bookstoreapi.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using static bookstoreapi.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;

namespace bookstoreapi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
          GetGenresQuery vm = new GetGenresQuery(_context,_mapper);
          return Ok(await vm.Handle());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
          GetGenreDetailQuery vm= new GetGenreDetailQuery(_context,_mapper);
          vm.GenreId=id;
          GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
          validator.ValidateAndThrow(vm);

          return Ok(await vm.Handle());
        }
        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreModel model)
        {
            CreateGenreCommand vm = new CreateGenreCommand(_context,_mapper);
            vm.model= model;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(vm);
            vm.Handle();

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] UpdateGenreModel model)
        {
            UpdateGenreCommand vm =  new UpdateGenreCommand(_context);
            vm.GenreId=id;
            vm.model= model;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(vm);
            vm.Handle();

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            DeleteGenreCommand vm=  new DeleteGenreCommand(_context);
            vm.GenreId= id;
            DeleteGenreCommandValidator validator= new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(vm);
            vm.Handle();

            return Ok();
        }
    }
}