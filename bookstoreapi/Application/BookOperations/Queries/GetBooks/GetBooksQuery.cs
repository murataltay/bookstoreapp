using AutoMapper;
using bookstoreapi.DbOperations;
using bookstoreapi.Entities;
using bookstoreapp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstoreapi.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        private readonly  IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBooksQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BooksViewModel>> Handle()
        {
            var books = await _context.Books.Include(x=>x.Genre).OrderBy(x=>x.Id).ToListAsync<Book>();
            List<BooksViewModel> viewModels = _mapper.Map<List<BooksViewModel>>(books);
            return viewModels;
        }
        public class BooksViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}