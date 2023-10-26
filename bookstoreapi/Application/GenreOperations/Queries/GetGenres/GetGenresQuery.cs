using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookstoreapi.DbOperations;
using bookstoreapi.Entities;
using bookstoreapp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstoreapi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenresQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GenresViewModel>> Handle()
        {
            var entities = await _context.Genres.OrderBy(x=>x.Id).ToListAsync();
            List<GenresViewModel> genres = _mapper.Map<List<GenresViewModel>>(entities);
            return genres;
        }
        public class GenresViewModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    }
}