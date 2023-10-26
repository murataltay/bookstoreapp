using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookstoreapi.DbOperations;
using bookstoreapi.Entities;
using bookstoreapp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstoreapi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreModel model { get; set; }
        public CreateGenreCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async void Handle()
        {
            var entity = await _context.Genres.SingleOrDefaultAsync(x=>x.Name== model.Name);
            if(entity is not  null)
                throw new BadHttpRequestException("Kayıt daha önce eklenmiştir.");
            Genre genre= _mapper.Map<Genre>(model);
            await _context.Genres.AddAsync(genre);
            _context.SaveChanges();
        }
        public class CreateGenreModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    }
}