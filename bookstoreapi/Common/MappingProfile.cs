using AutoMapper;
using bookstoreapi.Entities;
using static bookstoreapi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static bookstoreapi.Application.BookOperations.Queries.GetBookDetail.GetBookDetailQuery;
using static bookstoreapi.Application.BookOperations.Queries.GetBooks.GetBooksQuery;
using static bookstoreapi.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using static bookstoreapi.Application.GenreOperations.Queries.GetGenreDetail.GetGenreDetailQuery;
using static bookstoreapi.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;
using static bookstoreapi.Application.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace bookstoreapi.Common
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailModel>().ForMember(dest => dest.Genre, opt=>opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<CreateGenreModel, Genre>();
            CreateMap<Genre,GenreDetailModel>();
            CreateMap<Genre,GenresViewModel>();

            CreateMap<CreateUserModel, User>();
        }
    }
}