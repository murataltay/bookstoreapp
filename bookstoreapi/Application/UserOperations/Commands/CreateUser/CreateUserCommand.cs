using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookstoreapi.DbOperations;
using bookstoreapi.Entities;

namespace bookstoreapi.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateUserModel model { get; set; }
        public CreateUserCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var entity = _context.Users.SingleOrDefault(x=>x.Email==model.Email);
            if(entity is not null) 
                throw new InvalidOperationException("Kullanıcı zaten mevcut.");
            var user = _mapper.Map<User>(model);
            _context.Users.Add(user);
            _context.SaveChanges();     
        }
        public class CreateUserModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}