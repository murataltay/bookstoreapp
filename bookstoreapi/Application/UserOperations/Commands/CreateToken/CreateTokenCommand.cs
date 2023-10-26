using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookstoreapi.DbOperations;
using bookstoreapi.TokenOperations;
using bookstoreapi.TokenOperations.Models;

namespace bookstoreapi.Application.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CreateTokenModel model { get; set; }
        public CreateTokenCommand(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public Token Handle()
        {
            var entity = _context.Users.SingleOrDefault(x=>x.Email==model.Email && x.Password==model.Password);
            if(entity is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token =  handler.CreateAccessToken(entity);

                entity.RefreshToken= token.RefreshToken;
                entity.RefresTokenExpireDate= token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            else 
                throw new InvalidOperationException("Kullanıcı adı & parola hatalı.");

        }
        public class CreateTokenModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}