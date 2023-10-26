using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstoreapi.DbOperations;
using bookstoreapp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstoreapi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly IBookStoreDbContext _context;
        public int GenreId { get; set; }
        public DeleteGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }
        public async void Handle()
        {
            var entity= await _context.Genres.SingleOrDefaultAsync(x=>x.Id==GenreId);
            if(entity is null)
                throw new BadHttpRequestException("Kayıt bulunamadı");
            _context.Genres.Remove(entity);
            _context.SaveChanges();
        }
    }
}