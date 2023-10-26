using AutoMapper;
using bookstoreapi.Application.UserOperations.Commands.CreateToken;
using bookstoreapi.Application.UserOperations.Commands.CreateUser;
using bookstoreapi.DbOperations;
using bookstoreapi.TokenOperations.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static bookstoreapi.Application.UserOperations.Commands.CreateToken.CreateTokenCommand;
using static bookstoreapi.Application.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace bookstoreapi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class UserController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserController(IMapper mapper, IBookStoreDbContext context, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel model)
        {
            CreateUserCommand vm= new CreateUserCommand(_context,_mapper);
            vm.model= model;
            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            validator.ValidateAndThrow(vm);
            vm.Handle();
            
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel model)
        {
            CreateTokenCommand vm= new CreateTokenCommand(_context,_mapper,_configuration);
            vm.model=model;
            CreateTokenCommandValidator validator = new CreateTokenCommandValidator();
            validator.ValidateAndThrow(vm);
            var token = vm.Handle();
            return Ok(token);
        }
    }
}