using bookstoreapi.Entities;
using bookstoreapp.Models;
using Microsoft.EntityFrameworkCore;

namespace murat.altay.Desktop.Project.bookstoreapp.DbOperations
{
    public class DataGenerator
    {
        public static void  Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }
                context.Genres.AddRange(
                    new Genre
                    {
                        Name="Personel Growth"    
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Roman"
                    }
                );
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
                context.SaveChanges();
            }
        }
        
    }
}