using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstoreapi.Entities;
using bookstoreapp.Models;

namespace bookstore.unittests.TestsSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                new Book
                {
                    Id = 1,
                    Title = "Lean Startup",
                    GenreId = 1,
                    PageCount = 200,
                    PublishDate = new DateTime(2021, 12, 16)
                },
                new Book
                {
                    Id = 2,
                    Title = "Hearland",
                    GenreId = 1,
                    PageCount = 300,
                    PublishDate = new DateTime(2006, 5, 14)
                },
                new Book
                {
                    Id = 3,
                    Title = "Done",
                    GenreId = 1,
                    PageCount = 400,
                    PublishDate = new DateTime(2011, 11, 11)
                }
            );
        }
    }
}