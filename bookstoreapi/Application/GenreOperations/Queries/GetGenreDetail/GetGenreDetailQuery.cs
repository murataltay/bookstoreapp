using AutoMapper;
using bookstoreapi.DbOperations;
using bookstoreapp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstoreapi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }
        public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GenreDetailModel> Handle()
        {
            var entity = await _context.Genres.SingleOrDefaultAsync(x=>x.Id==GenreId);
            if(entity is null)
                throw new BadHttpRequestException("Kayıt bulanamadı !");
            GenreDetailModel model = _mapper.Map<GenreDetailModel>(entity);
            return model;
        }
        public class GenreDetailModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    }
}