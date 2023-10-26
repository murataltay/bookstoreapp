 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookstoreapi.DbOperations;
using bookstoreapi.Entities;
using bookstoreapp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstoreapi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        private readonly IBookStoreDbContext _context;
        public CreateBookModel model { get; set; }
        private readonly IMapper _mapper;
        public CreateBookCommand(IBookStoreDbContext context, IMapper mapper)
        { 
            _context = context;
            _mapper = mapper;
        }
        public  void Handlle()
        {
           var book =  _context.Books.Single(x=>x.Title==model.Title);
           if(book is not null)
           {
                throw new InvalidOperationException("Kitap zaten mevcut");
           }    
            book = _mapper.Map<Book>(model);
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public class CreateBookModel
        {
            public int PageCount { get; set; }
            public int GenreId { get; set; }
            public DateTime PublishDate { get; set; }
            public string Title { get; set; }
        }
    }

}