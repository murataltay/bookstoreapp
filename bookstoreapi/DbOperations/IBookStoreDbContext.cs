using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstoreapi.Entities;
using Microsoft.EntityFrameworkCore;

namespace bookstoreapi.DbOperations
{
    public interface IBookStoreDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}