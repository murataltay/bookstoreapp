using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstoreapi.DbOperations;
using bookstoreapp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstoreapi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        public int bookId { get; set; }
        private IBookStoreDbContext _context;
        public DeleteBookCommand(IBookStoreDbContext context)
        {
            _context= context;            
        }
        public async void Handle()
        {
            var entity = await _context.Books.SingleOrDefaultAsync(x=>x.Id== bookId);
            if(entity is null)
                throw new InvalidOperationException("Kayıt bulunamadı.");
             _context.Books.Remove(entity);
             _context.SaveChanges();
        }
    }
}