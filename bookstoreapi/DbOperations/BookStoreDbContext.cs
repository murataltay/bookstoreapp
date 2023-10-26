using bookstoreapi.DbOperations;
using bookstoreapi.Entities;

using Microsoft.EntityFrameworkCore;

namespace bookstoreapp.Models {
    public class BookStoreDbContext : DbContext, IBookStoreDbContext {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base (options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}