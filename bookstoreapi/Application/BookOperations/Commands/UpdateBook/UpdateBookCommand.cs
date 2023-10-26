using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstoreapi.DbOperations;
using bookstoreapp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstoreapi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        public int BookId { get; set; }
        public UpdateBookModel model { get; set; }
        private IBookStoreDbContext _context;
        public UpdateBookCommand(IBookStoreDbContext context)
        {
            _context = context;
        }
        public async void Handle()
        {
            var entity = await _context.Books.SingleOrDefaultAsync(x=>x.Id==BookId);
            if(entity is null)
                throw new InvalidOperationException("Kayıt Bulunamadı.");
            entity.Genre.Id = model.GenreId != default ? model.GenreId : entity.Genre.Id;
            entity.PageCount = model.PageCount != default ? model.PageCount : entity.PageCount;
            entity.PublishDate = model.PublishDate != default ? model.PublishDate : entity.PublishDate;
            entity.Title = model.Title != default ? model.Title : entity.Title;
            _context.SaveChanges();
        }
        public class UpdateBookModel
        {
            public string Title { get; set; }
            public DateTime PublishDate { get; set; }
            public int PageCount { get; set; }
            public int GenreId { get; set; }
        }
    }
}