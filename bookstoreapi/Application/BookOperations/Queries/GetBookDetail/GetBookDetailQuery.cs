using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookstoreapi.Common;
using bookstoreapi.DbOperations;
using bookstoreapp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstoreapi.Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQuery
    {
        public int id { get; set; }
        private IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBookDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BookDetailModel> Handle(){
            var entity = await _context.Books.Include(x=>x.Genre).SingleOrDefaultAsync(x=>x.Id==id);
            if(entity is null)
                throw new InvalidOperationException("Kayıt bulunamdı !");
            var book = _mapper.Map<BookDetailModel>(entity);
            return book;
        }
        public class BookDetailModel
        {
            public int PageCount { get; set; }
            public string Datetime { get; set; }
            public string Genre { get; set; }
            public string Title { get; set; }
        }

    }
}