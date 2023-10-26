using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookstoreapi.DbOperations;
using bookstoreapp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstoreapi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly IBookStoreDbContext _context;
        public int GenreId { get; set; }
        public UpdateGenreModel  model { get; set; }
        public UpdateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }
        public async void Handle()
        {
            var entity = await _context.Genres.SingleOrDefaultAsync(x=>x.Id== GenreId);
            if(entity is null)
                throw new BadHttpRequestException("Kayıt bulunamadı.");
            if(_context.Genres.Any(x=>x.Name.ToLower()==model.Name.ToLower() && x.Id !=GenreId))
                throw new BadHttpRequestException("Kayıt daha önce eklenmiştir.");
            entity.Name= model.Name != default ? model.Name : entity.Name;
            entity.IsActive= model.IsActive !=default ? model.IsActive: entity.IsActive;
            _context.SaveChanges();
        }
        public class UpdateGenreModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    }
}