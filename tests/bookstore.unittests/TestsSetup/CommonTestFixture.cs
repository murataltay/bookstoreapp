using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookstoreapi.Common;
using bookstoreapp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore.unittests.TestsSetup
{
    public class CommonTestFixture
    {
        public BookStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDB").Options;
            Context = new BookStoreDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => {cfg.AddProfile<MappingProfile>();}).CreateMapper();
        }

    }
}